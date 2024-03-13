namespace AdvancedPing
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
         textBox1 = new System.Windows.Forms.TextBox();
         listBox1 = new System.Windows.Forms.ListBox();
         label2 = new System.Windows.Forms.Label();
         textBox2 = new System.Windows.Forms.TextBox();
         button1 = new System.Windows.Forms.Button();
         button2 = new System.Windows.Forms.Button();
         button3 = new System.Windows.Forms.Button();
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
         // textBox1
         // 
         textBox1.Location = new System.Drawing.Point(122, 12);
         textBox1.Name = "textBox1";
         textBox1.Size = new System.Drawing.Size(146, 23);
         textBox1.TabIndex = 1;
         // 
         // listBox1
         // 
         listBox1.FormattingEnabled = true;
         listBox1.ItemHeight = 15;
         listBox1.Location = new System.Drawing.Point(12, 41);
         listBox1.Name = "listBox1";
         listBox1.Size = new System.Drawing.Size(418, 214);
         listBox1.TabIndex = 2;
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
         // textBox2
         // 
         textBox2.Location = new System.Drawing.Point(89, 261);
         textBox2.Name = "textBox2";
         textBox2.Size = new System.Drawing.Size(179, 23);
         textBox2.TabIndex = 4;
         textBox2.Text = "test packet";
         // 
         // button1
         // 
         button1.Location = new System.Drawing.Point(274, 12);
         button1.Name = "button1";
         button1.Size = new System.Drawing.Size(75, 23);
         button1.TabIndex = 5;
         button1.Text = "Start";
         button1.UseVisualStyleBackColor = true;
         button1.Click += button1_Click;
         // 
         // button2
         // 
         button2.Location = new System.Drawing.Point(355, 12);
         button2.Name = "button2";
         button2.Size = new System.Drawing.Size(75, 23);
         button2.TabIndex = 6;
         button2.Text = "Stop";
         button2.UseVisualStyleBackColor = true;
         button2.Click += button2_Click;
         // 
         // button3
         // 
         button3.Location = new System.Drawing.Point(355, 261);
         button3.Name = "button3";
         button3.Size = new System.Drawing.Size(75, 23);
         button3.TabIndex = 7;
         button3.Text = "Close";
         button3.UseVisualStyleBackColor = true;
         button3.Click += button3_Click;
         // 
         // Form1
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(442, 295);
         Controls.Add(button3);
         Controls.Add(button2);
         Controls.Add(button1);
         Controls.Add(textBox2);
         Controls.Add(label2);
         Controls.Add(listBox1);
         Controls.Add(textBox1);
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
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
   }
}
