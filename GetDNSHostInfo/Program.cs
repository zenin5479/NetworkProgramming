using System;
using System.Net;

namespace GetDNSHostInfo
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Приложение: Получить информацию о хосте DNS");
         string addresses = "www.google.com";
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