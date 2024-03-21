using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WhoisAnyDomain
{
   public partial class FormOne : Form
   {
      public FormOne()
      {
         InitializeComponent();
      }

      private void ButtonGet_Click(object sender, EventArgs e)
      {
         List<string> whoisServers = new List<string>
         {
            "whois.tcinet.ru",
            "whois.ripn.net"
         };
         
         TextBoxResult.Text = "";
         foreach (string whoisServer in whoisServers)
            TextBoxResult.Text += WhoisService.Lookup(whoisServer, DomainName.Text);
      }

      private void FormOne_Load(object sender, EventArgs e)
      {

      }
   }
}