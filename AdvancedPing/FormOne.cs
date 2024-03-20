using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AdvancedPing
{
   public partial class FormOne : Form
   {
      private bool _iscalculated = true;
      private static Socket _sock;

      public FormOne()
      {
         InitializeComponent();
      }

      private void ButtonStart_Click(object sender, EventArgs e)
      {
         new Thread(SendPing).Start();
      }

      void SendPing()
      {
         _iscalculated = true;
         _sock = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
         _sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
         IPHostEntry iphe = Dns.GetHostEntry(TextBoxHost.Text);
         IPEndPoint iep = new IPEndPoint(iphe.AddressList[0], 0);
         EndPoint ep = iep;
         Icmp packet = new Icmp();
         int i = 1;
         packet.Type = 0x08;
         packet.Code = 0x00;
         Buffer.BlockCopy(BitConverter.GetBytes(1), 0, packet.Message, 0, 2);
         byte[] data = Encoding.ASCII.GetBytes(TextBoxData.Text);
         Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
         packet.MessageSize = data.Length + 4;
         int packetsize = packet.MessageSize + 4;
         ListBoxResults.Invoke((Action)delegate { ListBoxResults.Items.Add("Пинг: " + TextBoxHost.Text); });
         while (_iscalculated)
         {
            packet.Checksum = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(i), 0, packet.Message, 2, 2);
            ushort chcksum = packet.GetChecksum();
            packet.Checksum = chcksum;
            Stopwatch pingtiming = Stopwatch.StartNew();
            _sock.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
            try
            {
               data = new byte[1024];
               _sock.ReceiveFrom(data, ref ep);
               pingtiming.Stop();
               EndPoint ep1 = ep;
               int i1 = i;
               ListBoxResults.Invoke((Action)delegate
               {
                  ListBoxResults.Items
                     .Add("Ответ от: " + ep1 + ", последовательность: " + i1 + ", время = " + pingtiming.ElapsedMilliseconds + " миллисекунд");
               });

               ListBoxResults.Invoke((Action)delegate { ListBoxResults.TopIndex = ListBoxResults.Items.Count - 1; });
            }
            catch (SocketException)
            {
               ListBoxResults.Invoke((Action)delegate { ListBoxResults.Items.Add("Нет ответа от хоста"); });
               ListBoxResults.Invoke((Action)delegate { ListBoxResults.TopIndex = ListBoxResults.Items.Count - 1; });
            }
            i++;
            Thread.Sleep(500);
         }
      }

      private void ButtonStop_Click(object sender, EventArgs e)
      {
         _iscalculated = false;
         ListBoxResults.Invoke((Action)delegate { ListBoxResults.Items.Add("Пинг остановлен"); });
         ListBoxResults.Invoke((Action)delegate { ListBoxResults.TopIndex = ListBoxResults.Items.Count - 1; });
      }

      private void ButtonClear_Click(object sender, EventArgs e)
      {
         ListBoxResults.Items.Clear();
      }

      private void ButtonClose_Click(object sender, EventArgs e)
      {
         _sock.Close();
         Close();
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }
   }

   internal class Icmp
   {
      public byte Type;
      public byte Code;
      public ushort Checksum;
      public int MessageSize;
      public readonly byte[] Message = new byte[1024];

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
         return (ushort)~chcksm;
      }
   }
}