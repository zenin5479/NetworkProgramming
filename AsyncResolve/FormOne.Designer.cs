namespace AsyncResolve
{
   sealed partial class FormOne
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
         ButtonIdentify = new System.Windows.Forms.Button();
         TextBoxAddress = new System.Windows.Forms.TextBox();
         LabelAddress = new System.Windows.Forms.Label();
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
         // ButtonIdentify
         // 
         ButtonIdentify.Location = new System.Drawing.Point(284, 260);
         ButtonIdentify.Name = "ButtonIdentify";
         ButtonIdentify.Size = new System.Drawing.Size(100, 25);
         ButtonIdentify.TabIndex = 6;
         ButtonIdentify.Text = "Определить";
         ButtonIdentify.UseVisualStyleBackColor = true;
         ButtonIdentify.Click += button1_Click;
         // 
         // TextBoxAddress
         // 
         TextBoxAddress.Location = new System.Drawing.Point(202, 12);
         TextBoxAddress.Name = "TextBoxAddress";
         TextBoxAddress.Size = new System.Drawing.Size(182, 23);
         TextBoxAddress.TabIndex = 5;
         TextBoxAddress.Text = "www.google.com";
         // 
         // LabelAddress
         // 
         LabelAddress.AutoSize = true;
         LabelAddress.Location = new System.Drawing.Point(12, 15);
         LabelAddress.Name = "LabelAddress";
         LabelAddress.Size = new System.Drawing.Size(184, 15);
         LabelAddress.TabIndex = 4;
         LabelAddress.Text = "Введите адрес для определения:";
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
         // FormOne
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(396, 297);
         Controls.Add(ButtonClear);
         Controls.Add(ListBoxResults);
         Controls.Add(ButtonIdentify);
         Controls.Add(TextBoxAddress);
         Controls.Add(LabelAddress);
         Name = "FormOne";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Определитель DNS-адресов";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.ListBox ListBoxResults;
      private System.Windows.Forms.Button ButtonIdentify;
      private System.Windows.Forms.TextBox TextBoxAddress;
      private System.Windows.Forms.Label LabelAddress;
      private System.Windows.Forms.Button ButtonClear;
   }
}
