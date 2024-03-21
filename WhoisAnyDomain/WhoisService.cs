using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WhoisAnyDomain
{
   public static class WhoisService
   {
      public static string Lookup(string whoisServer, string domainName)
      {
         try
         {
            if (string.IsNullOrEmpty(whoisServer) || string.IsNullOrEmpty(domainName))
               return null;
            StringBuilder result = new StringBuilder();
            result.AppendLine("По данным: " + whoisServer + "\n"
                              + "-----------------------------------------------------------------");
            using TcpClient tcpClient = new TcpClient();
            // Открываем соединение с сервером WHOIS
            tcpClient.Connect(whoisServer.Trim(), 43);
            byte[] domainQueryBytes = Encoding.ASCII.GetBytes(domainName);
            using Stream stream = tcpClient.GetStream();
            // Отправляем запрос на сервер WHOIS
            stream.Write(domainQueryBytes, 0, domainQueryBytes.Length);
            // Читаем ответ в формате UTF8, так как некоторые национальные домены содержат информацию на местном языке
            using StreamReader sr = new StreamReader(tcpClient.GetStream(), Encoding.UTF8);
            string row;
            while ((row = sr.ReadLine()) != null)
               result.AppendLine(row);
            result.AppendLine("-----------------------------------------------------------------");
            return result.ToString();
         }
         catch (Exception)
         {
            Console.WriteLine(@"Ошибка связи с сервером " + whoisServer);
         }

         return "Не удалось получить данные с сервера " + whoisServer;
      }
   }
}