namespace AsyncResolve
{
   sealed partial class Form1
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
         ListBoxResults = new System.Windows.Forms.ListBox();
         button1 = new System.Windows.Forms.Button();
         TextBoxAddress = new System.Windows.Forms.TextBox();
         label1 = new System.Windows.Forms.Label();
         ButtonClear = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // ListBoxResults
         // 
         ListBoxResults.FormattingEnabled = true;
         ListBoxResults.ItemHeight = 15;
         ListBoxResults.Location = new System.Drawing.Point(12, 41);
         ListBoxResults.Name = "ListBoxResults";
         ListBoxResults.Size = new System.Drawing.Size(372, 214);
         ListBoxResults.TabIndex = 7;
         // 
         // button1
         // 
         button1.Location = new System.Drawing.Point(284, 260);
         button1.Name = "button1";
         button1.Size = new System.Drawing.Size(100, 25);
         button1.TabIndex = 6;
         button1.Text = "Определить";
         button1.UseVisualStyleBackColor = true;
         button1.Click += button1_Click;
         // 
         // TextBoxAddress
         // 
         TextBoxAddress.Location = new System.Drawing.Point(202, 12);
         TextBoxAddress.Name = "TextBoxAddress";
         TextBoxAddress.Size = new System.Drawing.Size(182, 23);
         TextBoxAddress.TabIndex = 5;
         TextBoxAddress.Text = "www.google.com";
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(12, 15);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(184, 15);
         label1.TabIndex = 4;
         label1.Text = "Введите адрес для определения:";
         // 
         // ButtonClear
         // 
         ButtonClear.Location = new System.Drawing.Point(203, 261);
         ButtonClear.Name = "ButtonClear";
         ButtonClear.Size = new System.Drawing.Size(75, 23);
         ButtonClear.TabIndex = 9;
         ButtonClear.Text = "Очистить";
         ButtonClear.UseVisualStyleBackColor = true;
         ButtonClear.Click += ButtonClear_Click;
         // 
         // Form1
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(396, 297);
         Controls.Add(ButtonClear);
         Controls.Add(ListBoxResults);
         Controls.Add(button1);
         Controls.Add(TextBoxAddress);
         Controls.Add(label1);
         Name = "Form1";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Определитель DNS-адресов";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.ListBox ListBoxResults;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TextBox TextBoxAddress;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button ButtonClear;
   }
}
