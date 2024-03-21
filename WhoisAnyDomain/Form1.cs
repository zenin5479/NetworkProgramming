using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WhoisAnyDomain
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void get_BTN_Click(object sender, EventArgs e)
      {
         List<string> whoisServers = new List<string>
         {
            "whois.tcinet.ru",
            "whois.ripn.net"
         };
         
         result_TB.Text = "";
         foreach (string whoisServer in whoisServers)
            result_TB.Text += WhoisService.Lookup(whoisServer, domainName_TB.Text);
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }
   }
}