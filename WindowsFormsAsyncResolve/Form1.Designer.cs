namespace WindowsFormsAsyncResolve
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
         TextBoxAddress = new System.Windows.Forms.TextBox();
         button1 = new System.Windows.Forms.Button();
         ListBoxResults = new System.Windows.Forms.ListBox();
         SuspendLayout();
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.Location = new System.Drawing.Point(12, 15);
         label1.Name = "label1";
         label1.Size = new System.Drawing.Size(216, 19);
         label1.TabIndex = 0;
         label1.Text = "Введите адрес для определения:";
         // 
         // TextBoxAddress
         // 
         TextBoxAddress.Location = new System.Drawing.Point(234, 12);
         TextBoxAddress.Name = "TextBoxAddress";
         TextBoxAddress.Size = new System.Drawing.Size(150, 25);
         TextBoxAddress.TabIndex = 1;
         TextBoxAddress.Text = "www.google.com";
         // 
         // button1
         // 
         button1.Location = new System.Drawing.Point(284, 243);
         button1.Name = "button1";
         button1.Size = new System.Drawing.Size(100, 30);
         button1.TabIndex = 2;
         button1.Text = "Определить";
         button1.UseVisualStyleBackColor = true;
         button1.Click += button1_Click;
         // 
         // ListBoxResults
         // 
         ListBoxResults.FormattingEnabled = true;
         ListBoxResults.ItemHeight = 17;
         ListBoxResults.Location = new System.Drawing.Point(12, 43);
         ListBoxResults.Name = "ListBoxResults";
         ListBoxResults.Size = new System.Drawing.Size(372, 191);
         ListBoxResults.TabIndex = 3;
         // 
         // Form1
         // 
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
         ClientSize = new System.Drawing.Size(396, 285);
         Controls.Add(ListBoxResults);
         Controls.Add(button1);
         Controls.Add(TextBoxAddress);
         Controls.Add(label1);
         Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         Name = "Form1";
         Text = "Определитель DNS-адресов";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox TextBoxAddress;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ListBox ListBoxResults;
   }
}
