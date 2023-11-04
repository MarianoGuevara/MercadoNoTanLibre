namespace Formularios
{
    partial class FormLogin
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
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(154, 126);
            lblTitulo.Size = new Size(218, 38);
            lblTitulo.Text = "INICIAR SESIÓN";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(102, 253);
            // 
            // txtPassword
            // 
            txtPassword.PasswordChar = '*';
            // 
            // lblMail
            // 
            lblMail.Location = new Point(102, 218);
            // 
            // btn1
            // 
            btn1.Location = new Point(155, 467);
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(155, 544);
            btn2.Text = "Boton 2";
            btn2.Click += btn2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(25, 656);
            label1.Name = "label1";
            label1.Size = new Size(243, 25);
            label1.TabIndex = 8;
            label1.Text = "Mercado (no tan) libre - 2023";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 703);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "Form1";
            FormClosing += FormLogin_FormClosing;
            Load += FormLogin_Load;
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(lblTitulo, 0);
            Controls.SetChildIndex(txtMail, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(lblMail, 0);
            Controls.SetChildIndex(lblPassword, 0);
            Controls.SetChildIndex(btn1, 0);
            Controls.SetChildIndex(btn2, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}