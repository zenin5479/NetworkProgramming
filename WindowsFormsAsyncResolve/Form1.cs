﻿using System;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsAsyncResolve
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         ListBoxResults.Items.Clear();
         string addr = TextBoxAddress.Text;
         object state = new object();
         Dns.BeginGetHostEntry(addr, Resolved, state);
      }

      private void Resolved(IAsyncResult ar)
      {
         string buffer;
         IPHostEntry iphe = Dns.EndGetHostEntry(ar);
         buffer = "Имя хоста: " + iphe.HostName;
         ListBoxResults.Items.Add(buffer);
         foreach (string alias in iphe.Aliases)
         {
            buffer = "Псевдоним: " + alias;
            ListBoxResults.Items.Add(buffer);
         }
         foreach (IPAddress addrs in iphe.AddressList)
         {
            buffer = "Адрес: " + addrs;
            ListBoxResults.Items.Add(buffer);
         }
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }
   }
}