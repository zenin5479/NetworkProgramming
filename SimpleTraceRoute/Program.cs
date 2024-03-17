using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleTraceRoute
{
   class Traceroute
   {
      // Размер буфера в 32 байта обычно используется для эхо-запросов ICMP,
      // и этого обычно достаточно для целей базовых операций ping.
      private const int BufferSize = 32;
      // Этот массив байтов содержит данные, отправленные в пакете ICMP Echo Request.
      // Эти данные обычно используются для диагностических целей   эти данные полезной нагрузки подобны полезному сообщению,
      // содержащему конкретные сведения о перемещении пакета по сети.
      // Эти сведения помогают находить и устранять проблемы, такие как выяснение скорости передачи данных
      // или определение мест, где сеть может замедляться.
      private static readonly byte[] Buffer = new byte[BufferSize];
      private const int Timeout = 1000;
      private const int MaxHops = 30;

      static async Task Main()
      {
         Console.WriteLine("Пожалуйста, введите целевое доменное имя, которое хотите отследить, примеры ya.ru, mail.ru");
         var destination = GetDestination();
         var tasks = new Task<PingReply>[MaxHops];
         // Время жизни (TTL) относится к полю в заголовке пакета, которое определяет максимальное количество времени,
         // в течение которого пакету разрешено жить.
         // ttl здесь означает (время жизни) максимальное количество переходов (маршрутизаторов или сетевых устройств),
         // которое может пройти пакет до того, как программа отбросит его, в случае, если этот пакет не достигнет места назначения
         // до максимального значения по умолчанию (30), тогда пакет удален.
         for (int ttl = 1; ttl <= MaxHops; ttl++)
         {
            Ping pingSender = new Ping();
            // Установка флага "Не фрагментировать" в значение true означает, что пакет не должен фрагментироваться при его перемещении по сети.
            // Если размер пакета превышает максимальную единицу передачи (MTU) сетевого канала, и "Не фрагментировать" флаг установлен в значение true,
            // маршрутизатор отбросит пакет и отправит ICMP-сообщение "Требуется фрагментация" обратно отправителю.
            // Флаг "Не фрагментировать" (DF), это параметр в IP-заголовке пакета, который предписывает
            // маршрутизаторам не фрагментировать пакет на более мелкие фрагменты по мере его прохождения по сети.
            PingOptions pingOptions = new PingOptions(ttl, true);
            // Эхо-запрос ICMP;
            tasks[ttl - 1] = pingSender.SendPingAsync(destination, Timeout, Buffer, pingOptions);
         }

         PingReply[] replies = null!;
         Task<PingReply[]> allTasks = Task.WhenAll(tasks);
         try
         {
            replies = await allTasks;
         }
         // Не учтены все исключения. Достаточно отреагировать только на первую выданную ошибку, а не на все из них.
         catch (PingException e)
         {
            Console.WriteLine($"Произошла ошибка: {e.InnerException!.Message}");
            Environment.Exit(1);
         }

         for (int i = 0; i < replies.Length; i++)
         {
            PingReply reply = replies[i];
            if (reply.Status == IPStatus.TimedOut)
            {
               Console.WriteLine($"Прыжок {i + 1}: Статус: {reply.Status} *");
            }
            else
            {
               Console.WriteLine($"Прыжок {i + 1}: Адрес: {reply.Address} Статус: {reply.Status} RTT: {reply.RoundtripTime}");
               Console.WriteLine($"Прыжок {i + 1}: Статус: {reply.Status}");
            }

            if (reply.Status == IPStatus.Success || reply.Status == IPStatus.DestinationHostUnreachable)
            {
               Console.WriteLine("Пункт назначения достигнут!");
               break;
            }
         }

         Console.ReadKey();
      }

      static string GetDestination()
      {
         var destination = Console.ReadLine();
         if (destination is null || IsValidDomain(destination) is false)
         {
            Console.WriteLine("Пожалуйста, введите действительный URL-адрес назначения");
            destination = GetDestination();
            Console.Clear();
         }

         return destination;
      }

      static bool IsValidDomain(string domain)
      {
         // Простое регулярное выражение для проверки того, является ли строка допустимым доменом
         string pattern = @"^(?!:\/\/)([a-zA-Z0-9-]+\.){1,}[a-zA-Z]{2,}$";
         return Regex.IsMatch(domain, pattern);
      }
   }
}