using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleSendPing
{
   internal class Program
   {
      static void Main()
      {
         //SimpleSendPing();
         SendPing();
         //SimpleTraceRoute();
         Console.ReadKey();
      }

      private static void SimpleSendPing()
      {
         int recv;
         Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
         IPHostEntry iphe = Dns.GetHostEntry("www.ya.ru");
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
      }

      private static void SendPing()
      {
         Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
         IPHostEntry iphe = Dns.GetHostEntry("www.ya.ru");
         IPEndPoint iep = new IPEndPoint(iphe.AddressList[0], 0);
         EndPoint ep = iep;
         Icmp packet = new Icmp();
         int i = 1;
         packet.Type = 0x08;
         packet.Code = 0x00;
         Buffer.BlockCopy(BitConverter.GetBytes(1), 0, packet.Message, 0, 2);
         byte[] data = Encoding.ASCII.GetBytes("test packet");
         Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
         packet.MessageSize = data.Length + 4;
         int packetsize = packet.MessageSize + 4;
         Console.WriteLine("Пинг: {0}", iphe.HostName);
         while (true)
         {
            packet.Checksum = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(i), 0, packet.Message, 2, 2);
            ushort chcksum = packet.GetChecksum();
            packet.Checksum = chcksum;
            int pingstart = Environment.TickCount;

            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            sock.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
            try
            {
               data = new byte[1024];
               sock.ReceiveFrom(data, ref ep);
               int pingstop = Environment.TickCount;
               int elapsedtime = pingstop - pingstart;
               Console.WriteLine("Ответ от: " + ep + ", следующий: " + i + ", время = " + elapsedtime + " миллисекунд");
            }
            catch (SocketException)
            {
               Console.WriteLine("Нет ответа от хоста");
            }

            i++;
            Thread.Sleep(1000);
         }
      }

      private static void SimpleTraceRoute()
      {
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
         Buffer.BlockCopy(BitConverter.GetBytes(1), 0, packet.Message, 0, 2);
         Buffer.BlockCopy(BitConverter.GetBytes(1), 0, packet.Message, 2, 2);
         var data = Encoding.ASCII.GetBytes("test packet");
         Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
         packet.MessageSize = data.Length + 4;
         int packetsize = packet.MessageSize + 4;
         ushort chcksum = packet.GetChecksum();
         packet.Checksum = chcksum;
         host.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
         int badcount = 0;
         for (int i = 1; i < 50; i++)
         {
            host.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IpTimeToLive, i);
            int timestart = Environment.TickCount;
            host.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
            try
            {
               data = new byte[1024];
               int recv = host.ReceiveFrom(data, ref ep);
               int timestop = Environment.TickCount;
               Icmp response = new Icmp(data, recv);
               if (response.Type == 11)
                  Console.WriteLine("Прыжок {0}: ответ от {1}, {2} ms", i, ep, timestop - timestart);
               if (response.Type == 0)
               {
                  Console.WriteLine("{0} достиг в {1} прыжок, {2} ms.", ep, i, timestop - timestart);
                  break;
               }

               badcount = 0;
            }
            catch (SocketException)
            {
               Console.WriteLine("Прыжок {0}: Нет ответа от удаленного хоста", i);
               badcount++;
               if (badcount == 5)
               {
                  Console.WriteLine("Не удается связаться с удаленным хостом");
                  break;
               }
            }
         }
      }
   }

   internal class Icmp
   {
      public byte Type;
      public byte Code;
      public ushort Checksum;
      public int MessageSize;
      public readonly byte[] Message = new byte[1024];

      public Icmp()
      {
      }

      public Icmp(byte[] data, int size)
      {
         Type = data[20];
         Code = data[21];
         Checksum = BitConverter.ToUInt16(data, 22);
         MessageSize = size - 24;
         Buffer.BlockCopy(data, 24, Message, 0, MessageSize);
      }

      public byte[] GetBytes()
      {
         byte[] data = new byte[MessageSize + 9];
         Buffer.BlockCopy(BitConverter.GetBytes(Type), 0, data, 0, 1);
         Buffer.BlockCopy(BitConverter.GetBytes(Code), 0, data, 1, 1);
         Buffer.BlockCopy(BitConverter.GetBytes(Checksum), 0, data, 2, 2);
         Buffer.BlockCopy(Message, 0, data, 4, MessageSize);
         return data;
      }

      public ushort GetChecksum()
      {
         uint chcksm = 0;
         byte[] data = GetBytes();
         int packetsize = MessageSize + 8;
         int index = 0;
         while (index < packetsize)
         {
            chcksm += Convert.ToUInt32(BitConverter.ToUInt16(data, index));
            index += 2;
         }

         chcksm = (chcksm >> 16) + (chcksm & 0xffff);
         chcksm += (chcksm >> 16);
         return (ushort)(~chcksm);
      }
   }
}