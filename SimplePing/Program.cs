using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimplePing
{
   internal class Program
   {
      static void Main()
      {
         int recv;
         Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
         IPHostEntry iphe = Dns.GetHostEntry("www.google.ru");
         IPEndPoint iep = new IPEndPoint(iphe.AddressList[0], 0);
         EndPoint ep = iep;
         Icmp packet = new Icmp
         {
            Type = 0x08,
            Code = 0x00,
            Checksum = 0
         };
         Buffer.BlockCopy(BitConverter.GetBytes((short)1), 0, packet.Message, 0, 2);
         Buffer.BlockCopy(BitConverter.GetBytes((short)1), 0, packet.Message, 2, 2);
         byte[] data = Encoding.ASCII.GetBytes("test packet");
         Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
         packet.MessageSize = data.Length + 4;
         int packetsize = packet.MessageSize + 4;
         ushort chcksum = packet.GetChecksum();
         packet.Checksum = chcksum;
         host.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
         host.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
         try
         {
            data = new byte[1024];
            recv = host.ReceiveFrom(data, ref ep);
         }
         catch (SocketException)
         {
            Console.WriteLine("Нет ответа от удаленного хоста");
            return;
         }

         Icmp response = new Icmp(data, recv);
         Console.WriteLine("Пинг хоста: {0}", iphe.HostName);
         Console.WriteLine("Ответ от: {0}", ep);
         Console.WriteLine("Тип {0}", response.Type);
         Console.WriteLine("Код: {0}", response.Code);
         int identifier = BitConverter.ToInt16(response.Message, 0);
         int sequence = BitConverter.ToInt16(response.Message, 2);
         Console.WriteLine("Идентификатор: {0}", identifier);
         Console.WriteLine("Последовательность: {0}", sequence);
         string stringData = Encoding.ASCII.GetString(response.Message, 4, response.MessageSize - 4);
         Console.WriteLine("Данные: {0}", stringData);
         host.Close();
         Console.ReadKey();
      }
   }
}