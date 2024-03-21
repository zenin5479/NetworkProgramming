namespace WhoisAnyDomain
{
   partial class Form1
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         domainName_TB = new System.Windows.Forms.TextBox();
         get_BTN = new System.Windows.Forms.Button();
         result_TB = new System.Windows.Forms.TextBox();
         SuspendLayout();
         // 
         // domainName_TB
         // 
         domainName_TB.Location = new System.Drawing.Point(12, 12);
         domainName_TB.Name = "domainName_TB";
         domainName_TB.Size = new System.Drawing.Size(271, 23);
         domainName_TB.TabIndex = 0;
         domainName_TB.Text = "habrahabr.ru";
         // 
         // get_BTN
         // 
         get_BTN.Location = new System.Drawing.Point(289, 12);
         get_BTN.Name = "get_BTN";
         get_BTN.Size = new System.Drawing.Size(75, 23);
         get_BTN.TabIndex = 1;
         get_BTN.Text = "Получить!";
         get_BTN.UseVisualStyleBackColor = true;
         get_BTN.Click += get_BTN_Click;
         // 
         // result_TB
         // 
         result_TB.Location = new System.Drawing.Point(12, 41);
         result_TB.Multiline = true;
         result_TB.Name = "result_TB";
         result_TB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         result_TB.Size = new System.Drawing.Size(489, 397);
         result_TB.TabIndex = 2;
         // 
         // Form1
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(513, 450);
         Controls.Add(result_TB);
         Controls.Add(get_BTN);
         Controls.Add(domainName_TB);
         Name = "Form1";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "WHOIS";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.TextBox domainName_TB;
      private System.Windows.Forms.Button get_BTN;
      private System.Windows.Forms.TextBox result_TB;
   }
}
