namespace WhoisAnyDomain
{
   partial class FormOne
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
         DomainName = new System.Windows.Forms.TextBox();
         ButtonGet = new System.Windows.Forms.Button();
         TextBoxResult = new System.Windows.Forms.TextBox();
         SuspendLayout();
         // 
         // DomainName
         // 
         DomainName.Location = new System.Drawing.Point(12, 12);
         DomainName.Name = "DomainName";
         DomainName.Size = new System.Drawing.Size(200, 23);
         DomainName.TabIndex = 0;
         DomainName.Text = "google.ru";
         // 
         // ButtonGet
         // 
         ButtonGet.Location = new System.Drawing.Point(218, 12);
         ButtonGet.Name = "ButtonGet";
         ButtonGet.Size = new System.Drawing.Size(152, 23);
         ButtonGet.TabIndex = 1;
         ButtonGet.Text = "Запросить информацию";
         ButtonGet.UseVisualStyleBackColor = true;
         ButtonGet.Click += get_BTN_Click;
         // 
         // TextBoxResult
         // 
         TextBoxResult.Location = new System.Drawing.Point(12, 41);
         TextBoxResult.Multiline = true;
         TextBoxResult.Name = "TextBoxResult";
         TextBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         TextBoxResult.Size = new System.Drawing.Size(358, 397);
         TextBoxResult.TabIndex = 2;
         // 
         // FormOne
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(384, 450);
         Controls.Add(TextBoxResult);
         Controls.Add(ButtonGet);
         Controls.Add(DomainName);
         Name = "FormOne";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Служба WHOIS";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.TextBox DomainName;
      private System.Windows.Forms.Button ButtonGet;
      private System.Windows.Forms.TextBox TextBoxResult;
   }
}
