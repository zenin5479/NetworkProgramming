namespace AdvancedPing
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
         LabelHost = new System.Windows.Forms.Label();
         TextBoxHost = new System.Windows.Forms.TextBox();
         ListBoxResults = new System.Windows.Forms.ListBox();
         LabelData = new System.Windows.Forms.Label();
         TextBoxData = new System.Windows.Forms.TextBox();
         ButtonStart = new System.Windows.Forms.Button();
         ButtonStop = new System.Windows.Forms.Button();
         ButtonClose = new System.Windows.Forms.Button();
         ButtonClear = new System.Windows.Forms.Button();
         SuspendLayout();
         // 
         // LabelHost
         // 
         LabelHost.AutoSize = true;
         LabelHost.Location = new System.Drawing.Point(12, 15);
         LabelHost.Name = "LabelHost";
         LabelHost.Size = new System.Drawing.Size(137, 15);
         LabelHost.TabIndex = 0;
         LabelHost.Text = "Введите хост для пинга:";
         // 
         // TextBoxHost
         // 
         TextBoxHost.Location = new System.Drawing.Point(155, 12);
         TextBoxHost.Name = "TextBoxHost";
         TextBoxHost.Size = new System.Drawing.Size(147, 23);
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
         // LabelData
         // 
         LabelData.AutoSize = true;
         LabelData.Location = new System.Drawing.Point(12, 264);
         LabelData.Name = "LabelData";
         LabelData.Size = new System.Drawing.Size(108, 15);
         LabelData.TabIndex = 3;
         LabelData.Text = "Пакетные данные:";
         // 
         // TextBoxData
         // 
         TextBoxData.Location = new System.Drawing.Point(126, 261);
         TextBoxData.Name = "TextBoxData";
         TextBoxData.Size = new System.Drawing.Size(100, 23);
         TextBoxData.TabIndex = 4;
         TextBoxData.Text = "test packet";
         // 
         // ButtonStart
         // 
         ButtonStart.Location = new System.Drawing.Point(308, 12);
         ButtonStart.Name = "ButtonStart";
         ButtonStart.Size = new System.Drawing.Size(75, 23);
         ButtonStart.TabIndex = 5;
         ButtonStart.Text = "Старт";
         ButtonStart.UseVisualStyleBackColor = true;
         ButtonStart.Click += ButtonStart_Click;
         // 
         // ButtonStop
         // 
         ButtonStop.Location = new System.Drawing.Point(389, 12);
         ButtonStop.Name = "ButtonStop";
         ButtonStop.Size = new System.Drawing.Size(75, 23);
         ButtonStop.TabIndex = 6;
         ButtonStop.Text = "Стоп";
         ButtonStop.UseVisualStyleBackColor = true;
         ButtonStop.Click += ButtonStop_Click;
         // 
         // ButtonClose
         // 
         ButtonClose.Location = new System.Drawing.Point(389, 261);
         ButtonClose.Name = "ButtonClose";
         ButtonClose.Size = new System.Drawing.Size(75, 23);
         ButtonClose.TabIndex = 7;
         ButtonClose.Text = "Закрыть";
         ButtonClose.UseVisualStyleBackColor = true;
         ButtonClose.Click += ButtonClose_Click;
         // 
         // ButtonClear
         // 
         ButtonClear.Location = new System.Drawing.Point(308, 261);
         ButtonClear.Name = "ButtonClear";
         ButtonClear.Size = new System.Drawing.Size(75, 23);
         ButtonClear.TabIndex = 8;
         ButtonClear.Text = "Очистить";
         ButtonClear.UseVisualStyleBackColor = true;
         ButtonClear.Click += ButtonClear_Click;
         // 
         // FormOne
         // 
         AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
         AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         ClientSize = new System.Drawing.Size(476, 299);
         Controls.Add(ButtonClear);
         Controls.Add(ButtonClose);
         Controls.Add(ButtonStop);
         Controls.Add(ButtonStart);
         Controls.Add(TextBoxData);
         Controls.Add(LabelData);
         Controls.Add(ListBoxResults);
         Controls.Add(TextBoxHost);
         Controls.Add(LabelHost);
         Name = "FormOne";
         StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         Text = "Расширенный пинг";
         Load += Form1_Load;
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private System.Windows.Forms.Label LabelHost;
      private System.Windows.Forms.TextBox TextBoxHost;
      private System.Windows.Forms.ListBox ListBoxResults;
      private System.Windows.Forms.Label LabelData;
      private System.Windows.Forms.TextBox TextBoxData;
      private System.Windows.Forms.Button ButtonStart;
      private System.Windows.Forms.Button ButtonStop;
      private System.Windows.Forms.Button ButtonClose;
      private System.Windows.Forms.Button ButtonClear;
   }
}
