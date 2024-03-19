using System;
using System.Net;

namespace GetDNSAddressInfo
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Приложение: Получить информацию о DNS-адресе");
         string addresses = "64.233.163.105";
         Console.WriteLine("Информация для {0}", addresses);
         IPHostEntry results = Dns.GetHostEntry(addresses);
         Console.WriteLine("Имя хоста: {0}", results.HostName);
         foreach (string alias in results.Aliases)
         {
            Console.WriteLine("Псевдоним: {0}", alias);
         }
         foreach (IPAddress address in results.AddressList)
         {
            Console.WriteLine("Адрес: {0}", address);
         }

         Console.ReadKey();
      }
   }
}