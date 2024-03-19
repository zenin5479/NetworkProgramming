using System;
using System.Net;

namespace GetDNSHostInfo
{
   internal class Program
   {
      static void Main()
      {
         Console.WriteLine("Приложение: Получить информацию о хосте DNS");
         IPHostEntry results = Dns.GetHostEntry("www.google.com");
         Console.WriteLine("Имя хоста: {0}", results.HostName);
         foreach (string alias in results.Aliases)
         {
            Console.WriteLine("Псевдоним: {0}", alias);
         }
         foreach (IPAddress address in results.AddressList)
         {
            Console.WriteLine("Адрес: {0}", address);
         }
      }
   }
}