using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsAdvancedPing
{
   public sealed partial class Form1 : Form
   {
      private static int _pingstart, _pingstop, _elapsedtime;
      private static TextBox _hostbox, _databox;
      private static ListBox _results;
      private static Thread _pinger;
      private static Socket _sock;

      public Form1()
      {
         InitializeComponent();
         Text = @"Advanced Ping Program";
         Size = new Size(400, 430);
         Label label1 = new Label();
         label1.Parent = this;
         label1.Text = @"Enter host to ping:";
         label1.AutoSize = true;
         label1.Location = new Point(10, 30);
         _hostbox = new TextBox();
         _hostbox.Parent = this;
         _hostbox.Size = new Size(200, 2 * Font.Height);
         _hostbox.Location = new Point(10, 55);
         _results = new ListBox();
         _results.Parent = this;
         _results.Location = new Point(10, 85);
         _results.Size = new Size(360, 18 * Font.Height);
         Label label2 = new Label();
         label2.Parent = this;
         label2.Text = @"Packet data:";
         label2.AutoSize = true;
         label2.Location = new Point(10, 330);
         _databox = new TextBox();
         _databox.Parent = this;
         _databox.Text = @"test packet";
         _databox.Size = new Size(200, 2 * Font.Height);
         _databox.Location = new Point(80, 325);
         Button sendit = new Button();
         sendit.Parent = this;
         sendit.Text = @"Start";
         sendit.Location = new Point(220, 52);
         sendit.Size = new Size(5 * Font.Height, 2 * Font.Height);
         sendit.Click += ButtonSendOnClick;
         Button stopit = new Button();
         stopit.Parent = this;
         stopit.Text = @"Stop";
         stopit.Location = new Point(295, 52);
         stopit.Size = new Size(5 * Font.Height, 2 * Font.Height);
         stopit.Click += ButtonStopOnClick;
         Button closeit = new Button();
         closeit.Parent = this;
         closeit.Text = @"Close";
         closeit.Location = new Point(300, 320);
         closeit.Size = new Size(5 * Font.Height, 2 * Font.Height);
         closeit.Click += ButtonCloseOnClick;
         _sock = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp);
         _sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
      }

      void ButtonSendOnClick(object obj, EventArgs ea)
      {
         _pinger = new Thread(SendPing)
         {
            IsBackground = true
         };
         _pinger.Start();
      }
      void ButtonStopOnClick(object obj, EventArgs ea)
      {
         _pinger.Abort();
         _results.Items.Add("Ping stopped");
      }
      void ButtonCloseOnClick(object obj, EventArgs ea)
      {
         _sock.Close();
         Close();
      }
      void SendPing()
      {
         IPHostEntry iphe = Dns.Resolve(_hostbox.Text);
         IPEndPoint iep = new IPEndPoint(iphe.AddressList[0], 0);
         EndPoint ep = iep;
         Icmp packet = new Icmp();
         int i = 1;
         packet.Type = 0x08;
         packet.Code = 0x00;
         Buffer.BlockCopy(BitConverter.GetBytes(1), 0, packet.Message, 0, 2);
         byte[] data = Encoding.ASCII.GetBytes(_databox.Text);
         Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
         packet.MessageSize = data.Length + 4;
         int packetsize = packet.MessageSize + 4;
         _results.Items.Add("Pinging " + _hostbox.Text);
         while (true)
         {
            packet.Checksum = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(i), 0, packet.Message, 2, 2);
            ushort chcksum = packet.GetChecksum();
            packet.Checksum = chcksum;
            _pingstart = Environment.TickCount;
            _sock.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
            try
            {
               data = new byte[1024];
               _sock.ReceiveFrom(data, ref ep);
               _pingstop = Environment.TickCount;
               _elapsedtime = _pingstop - _pingstart;
               _results.Items.Add("reply from: " + ep + ", seq: " + i + ", time = " + _elapsedtime + "ms");
            }
            catch (SocketException)
            {
               _results.Items.Add("no reply from host");
            }
            i++;
            Thread.Sleep(500);
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
