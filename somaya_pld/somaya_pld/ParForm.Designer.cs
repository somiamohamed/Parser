namespace somaya_pld
{
    partial class ParForm
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
            richTextBox1 = new RichTextBox();
            ErrorBox = new ListBox();
            LexBox = new ListBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(62, 53);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(600, 638);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // ErrorBox
            // 
            ErrorBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ErrorBox.FormattingEnabled = true;
            ErrorBox.ItemHeight = 28;
            ErrorBox.Location = new Point(692, 53);
            ErrorBox.Name = "ErrorBox";
            ErrorBox.Size = new Size(443, 284);
            ErrorBox.TabIndex = 1;
            // 
            // LexBox
            // 
            LexBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            LexBox.FormattingEnabled = true;
            LexBox.ItemHeight = 28;
            LexBox.Location = new Point(692, 379);
            LexBox.Name = "LexBox";
            LexBox.Size = new Size(443, 312);
            LexBox.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1194, 748);
            Controls.Add(LexBox);
            Controls.Add(ErrorBox);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Parser";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private ListBox ErrorBox;
        private ListBox LexBox;
    }
}
