﻿namespace AdvancedPing
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
         label1 = new System.Windows.Forms.Label();
         TextBoxHost = new System.Windows.Forms.TextBox();
         ListBoxResults = new System.Windows.Forms.ListBox();
         label2 = new System.Windows.Forms.Label();
         TextBoxData = new System.Windows.Forms.TextBox();
         button1 = new System.Windows.Forms.Button();
         button2 = new System.Windows.Forms.Button();
         button3 = new System.Windows.Forms.Button();
         button4 = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(12, 15);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(104, 15);
         label1.TabIndex = 0;
         label1.Text = "Enter host to ping:";
         // 
         // TextBoxHost
         // 
         TextBoxHost.Location = new System.Drawing.Point(122, 12);
         TextBoxHost.Name = "TextBoxHost";
         TextBoxHost.Size = new System.Drawing.Size(180, 23);
         TextBoxHost.TabIndex = 1;
         TextBoxHost.Text = "www.google.com";
         // 
         // ListBoxResults
         // 
         ListBoxResults.FormattingEnabled = true;
         ListBoxResults.ItemHeight = 15;
         ListBoxResults.Location = new System.Drawing.Point(12, 41);
         ListBoxResults.Name = "ListBoxResults";
         ListBoxResults.Size = new System.Drawing.Size(452, 214);
         ListBoxResults.TabIndex = 2;
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.Location = new System.Drawing.Point(12, 264);
         label2.Name = "label2";
         label2.Size = new System.Drawing.Size(71, 15);
         label2.TabIndex = 3;
         label2.Text = "Packet data:";
         // 
         // TextBoxData
         // 
         TextBoxData.Location = new System.Drawing.Point(89, 261);
         TextBoxData.Name = "TextBoxData";
         TextBoxData.Size = new System.Drawing.Size(100, 23);
         TextBoxData.TabIndex = 4;
         TextBoxData.Text = "test packet";
         // 
         // button1
         // 
         button1.Location = new System.Drawing.Point(308, 11);
         button1.Name = "button1";
         button1.Size = new System.Drawing.Size(75, 23);
         button1.TabIndex = 5;
         button1.Text = "Start";
         button1.UseVisualStyleBackColor = true;
         button1.Click += button1_Click;
         // 
         // button2
         // 
         button2.Location = new System.Drawing.Point(389, 11);
         button2.Name = "button2";
         button2.Size = new System.Drawing.Size(75, 23);
         button2.TabIndex = 6;
         button2.Text = "Stop";
         button2.UseVisualStyleBackColor = true;
         button2.Click += button2_Click;
         // 
         // button3
         // 
         button3.Location = new System.Drawing.Point(389, 261);
         button3.Name = "button3";
         button3.Size = new System.Drawing.Size(75, 23);
         button3.TabIndex = 7;
         button3.Text = "Close";
         button3.UseVisualStyleBackColor = true;
         button3.Click += button3_Click;
         // 
         // button4
         // 
         button4.Location = new System.Drawing.Point(308, 261);
         button4.Name = "button4";
         button4.Size = new System.Drawing.Size(75, 23);
         button4.TabIndex = 8;
         button4.Text = "Close";
         button4.UseVisualStyleBackColor = true;
         // 
         // Form1
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(476, 299);
         Controls.Add(button4);
         Controls.Add(button3);
         Controls.Add(button2);
         Controls.Add(button1);
         Controls.Add(TextBoxData);
         Controls.Add(label2);
         Controls.Add(ListBoxResults);
         Controls.Add(TextBoxHost);
         Controls.Add(label1);
         Name = "Form1";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Advanced Ping";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox TextBoxHost;
      private System.Windows.Forms.ListBox ListBoxResults;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox TextBoxData;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button button4;
   }
}
