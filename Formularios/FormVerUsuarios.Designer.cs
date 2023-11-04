namespace Formularios
{
    partial class FormVerUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // rbInfo
            // 
            rbInfo.Size = new Size(841, 687);
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(344, 30);
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 25;
            listBox1.Location = new Point(63, 126);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(514, 379);
            listBox1.TabIndex = 0;
            // 
            // FormVerUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 790);
            Controls.Add(listBox1);
            Name = "FormVerUsuarios";
            Text = "FormVerUsuarios";
            Controls.SetChildIndex(listBox1, 0);
            Controls.SetChildIndex(rbInfo, 0);
            Controls.SetChildIndex(lblInfo, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
    }
}