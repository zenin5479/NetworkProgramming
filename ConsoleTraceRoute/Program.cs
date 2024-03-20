using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleTraceRoute
{
   class TraceRoute
   {
      public static void Main()
      {
         Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
         IPHostEntry iphe = Dns.GetHostEntry("www.google.com");
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
         // SocketOptionName.ReceiveTimeout 	Получить время ожидания.
         // Время ожидания операции приема истекает, если подтверждение не получено в течение 1000 миллисекунд.
         host.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 500);
         int badcount = 0;
         for (int i = 1; i < 50; i++)
         {
            host.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.IpTimeToLive, i);
            Stopwatch pingtiming = Stopwatch.StartNew();
            host.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
            try
            {
               data = new byte[1024];
               int recv = host.ReceiveFrom(data, ref ep);
               //pingtiming.Stop();
               Icmp response = new Icmp(data, recv);
               pingtiming.Stop();
               if (response.Type == 11)
                  Console.WriteLine("Прыжок {0}: Ответ от {1}, {2} миллисекунд", i, ep, pingtiming.ElapsedMilliseconds);
               if (response.Type == 0)
               {
                  Console.WriteLine("{0} Достиг в {1} Прыжок, {2} миллисекунд.", ep, i, pingtiming.ElapsedMilliseconds);
                  break;
               }
               badcount = 0;
            }
            catch (SocketException)
            {
               Console.WriteLine("Прыжок {0}: Нет ответа от удаленного хоста", i);
               badcount++;
               if (badcount == 20)
               {
                  Console.WriteLine("Не удается связаться с удаленным хостом");
                  break;
               }
            }
         }

         host.Close();
         Console.ReadKey();
      }
   }

   class Icmp
   {
      public byte Type;
      public byte Code;
      public ushort Checksum;
      public int MessageSize;
      public byte[] Message = new byte[1024];
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