﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AdvancedPing
{
   public partial class Form1 : Form
   {
      private static int pingstart, pingstop, elapsedtime;
      private static TextBox hostbox, databox;
      private static ListBox results;
      private static Thread pinger;
      private static Socket sock;

      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         pinger = new Thread(SendPing);
         pinger.IsBackground = true;
         pinger.Start();
      }

      static void SendPing()
      {
         IPHostEntry iphe = Dns.Resolve(hostbox.Text);
         IPEndPoint iep = new IPEndPoint(iphe.AddressList[0], 0);
         EndPoint ep = iep;
         Icmp packet = new Icmp();
         int recv, i = 1;
         packet.Type = 0x08;
         packet.Code = 0x00;
         Buffer.BlockCopy(BitConverter.GetBytes(1), 0, packet.Message, 0, 2);
         byte[] data = Encoding.ASCII.GetBytes(databox.Text);
         Buffer.BlockCopy(data, 0, packet.Message, 4, data.Length);
         packet.MessageSize = data.Length + 4;
         int packetsize = packet.MessageSize + 4;
         results.Items.Add("Pinging " + hostbox.Text);
         while (true)
         {
            packet.Checksum = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(i), 0, packet.Message, 2, 2);
            UInt16 chcksum = packet.GetChecksum();
            packet.Checksum = chcksum;
            pingstart = Environment.TickCount;
            sock.SendTo(packet.GetBytes(), packetsize, SocketFlags.None, iep);
            try
            {
               data = new byte[1024];
               recv = sock.ReceiveFrom(data, ref ep);
               pingstop = Environment.TickCount;
               elapsedtime = pingstop - pingstart;
               results.Items.Add("reply from: " + ep.ToString() + ", seq: " + i +
                                 ", time = " + elapsedtime + "ms");
            }
            catch (SocketException)
            {
               results.Items.Add("no reply from host");
            }
            i++;
            Thread.Sleep(3000);
         }
      }


      private void button2_Click(object sender, EventArgs e)
      {
         pinger.Abort();
         results.Items.Add("Ping stopped");
      }

      private void button3_Click(object sender, EventArgs e)
      {
         sock.Close();
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
         return (ushort)~chcksm;
      }
   }
}