using System;
using System.Net;
using System.Windows.Forms;

namespace AsyncResolve
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
         IPHostEntry iphe = Dns.EndGetHostEntry(ar);
         string buffer = "Имя хоста: " + iphe.HostName;
         var buffer1 = buffer;
         ListBoxResults.Invoke((Action)delegate { ListBoxResults.Items.Add(buffer1); });
         foreach (string alias in iphe.Aliases)
         {
            buffer = "Псевдоним: " + alias;
            ListBoxResults.Items.Add(buffer);
         }
         foreach (IPAddress addrs in iphe.AddressList)
         {
            buffer = "Адрес: " + addrs;
            var buffer2 = buffer;
            ListBoxResults.Invoke((Action)delegate { ListBoxResults.Items.Add(buffer2); });
         }
      }

      private void ButtonClear_Click(object sender, EventArgs e)
      {
         ListBoxResults.Items.Clear();
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }
   }
}