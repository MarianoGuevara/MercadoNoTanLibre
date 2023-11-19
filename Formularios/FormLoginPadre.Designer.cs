namespace Formularios
{
    partial class FormLoginPadre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginPadre));
            lblTitulo = new Label();
            txtMail = new TextBox();
            txtPassword = new TextBox();
            lblMail = new Label();
            lblPassword = new Label();
            btn1 = new Button();
            btn2 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(113, 110);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(285, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "LOGIN/REGISTRARSE";
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtMail.Location = new Point(102, 203);
            txtMail.Name = "txtMail";
            txtMail.PlaceholderText = "Mail (obligatorio)";
            txtMail.Size = new Size(305, 37);
            txtMail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(102, 354);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password (obligatorio)";
            txtPassword.Size = new Size(308, 37);
            txtPassword.TabIndex = 2;
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblMail.Location = new Point(102, 168);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(60, 32);
            lblMail.TabIndex = 3;
            lblMail.Text = "Mail";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(102, 319);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(111, 32);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btn1.Location = new Point(154, 479);
            btn1.Name = "btn1";
            btn1.Size = new Size(220, 48);
            btn1.TabIndex = 5;
            btn1.Text = "Boton 1";
            btn1.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btn2.Location = new Point(154, 582);
            btn2.Name = "btn2";
            btn2.Size = new Size(220, 48);
            btn2.TabIndex = 6;
            btn2.Text = "Boton 1";
            btn2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(102, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(305, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FormLoginPadre
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 100);
            ClientSize = new Size(529, 692);
            Controls.Add(pictureBox1);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(lblPassword);
            Controls.Add(lblMail);
            Controls.Add(txtPassword);
            Controls.Add(txtMail);
            Controls.Add(lblTitulo);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormLoginPadre";
            Text = "FormLoginPadre";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label lblTitulo;
        protected TextBox txtMail;
        protected TextBox txtPassword;
        protected Label lblMail;
        protected Label lblPassword;
        protected Button btn1;
        protected Button btn2;
        protected PictureBox pictureBox1;
    }
}