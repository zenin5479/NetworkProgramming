using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace AsyncResolve
{
   public sealed partial class Form1 : Form
   {
      private readonly TextBox _address;
      private readonly ListBox _results;
      private readonly AsyncCallback _onResolved;

      public Form1()
      {
         InitializeComponent();
         Text = @"Определитель DNS-адресов";
         Size = new Size(363, 315);
         _onResolved = Resolved;
         Label label1 = new Label();
         label1.Parent = this;
         label1.Text = @"Введите адрес для определения:";
         label1.AutoSize = true;
         label1.Location = new Point(10, 10);
         _address = new TextBox();
         _address.Parent = this;
         _address.Size = new Size(200, 23);
         _address.Location = new Point(10, 35);
         _results = new ListBox();
         _results.Parent = this;
         _results.Location = new Point(10, 65);
         _results.Size = new Size(325, 200);
         Button checkit = new Button();
         checkit.Parent = this;
         checkit.Text = @"Определить";
         checkit.Location = new Point(235, 35);
         checkit.Size = new Size(100, 23);
         checkit.Click += ButtonResolveOnClick;
      }

      void ButtonResolveOnClick(object obj, EventArgs ea)
      {
         _results.Items.Clear();
         string addr = _address.Text;
         object state = new object();
         Dns.BeginGetHostEntry(addr, _onResolved, state);
         //Dns.BeginGetHostAddresses(addr, _onResolved, state);
      }

      private void Resolved(IAsyncResult ar)
      {
         string buffer;
         IPHostEntry iphe = Dns.EndGetHostEntry(ar);
         buffer = "Имя хоста: " + iphe.HostName;
         _results.Items.Add(buffer);
         foreach (string alias in iphe.Aliases)
         {
            buffer = "Псевдоним: " + alias;
            _results.Items.Add(buffer);
         }
         foreach (IPAddress addrs in iphe.AddressList)
         {
            buffer = "Адрес: " + addrs;
            _results.Items.Add(buffer);
         }
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }
   }
}