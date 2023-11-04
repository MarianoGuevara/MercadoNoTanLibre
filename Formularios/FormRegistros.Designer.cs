namespace Formularios
{
    partial class FormRegistros
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
            lblLegajo = new Label();
            txtLegajo = new TextBox();
            txtName = new TextBox();
            lblName = new Label();
            cbTipoUser = new ComboBox();
            lblTipoUser = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(362, 41);
            lblTitulo.Size = new Size(190, 38);
            lblTitulo.Text = "REGISTRARSE";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(155, 151);
            txtMail.PlaceholderText = "Mail";
            txtMail.Size = new Size(292, 37);
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(155, 246);
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(292, 37);
            // 
            // lblMail
            // 
            lblMail.Location = new Point(273, 116);
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(243, 211);
            // 
            // btn1
            // 
            btn1.Location = new Point(35, 719);
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(344, 719);
            btn2.Text = "Boton 2";
            btn2.Click += btn2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(24, 18);
            // 
            // lblLegajo
            // 
            lblLegajo.AutoSize = true;
            lblLegajo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLegajo.Location = new Point(249, 503);
            lblLegajo.Name = "lblLegajo";
            lblLegajo.Size = new Size(84, 32);
            lblLegajo.TabIndex = 7;
            lblLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            txtLegajo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtLegajo.Location = new Point(155, 538);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.PlaceholderText = "Legajo";
            txtLegajo.Size = new Size(292, 37);
            txtLegajo.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(155, 340);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Nombre usuario ";
            txtName.Size = new Size(291, 37);
            txtName.TabIndex = 9;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(243, 305);
            lblName.Name = "lblName";
            lblName.Size = new Size(102, 32);
            lblName.TabIndex = 10;
            lblName.Text = "Nombre";
            // 
            // cbTipoUser
            // 
            cbTipoUser.FormattingEnabled = true;
            cbTipoUser.Location = new Point(155, 633);
            cbTipoUser.Name = "cbTipoUser";
            cbTipoUser.Size = new Size(292, 33);
            cbTipoUser.TabIndex = 11;
            cbTipoUser.SelectedIndexChanged += cbTipoUser_SelectedIndexChanged;
            // 
            // lblTipoUser
            // 
            lblTipoUser.AutoSize = true;
            lblTipoUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipoUser.Location = new Point(204, 598);
            lblTipoUser.Name = "lblTipoUser";
            lblTipoUser.Size = new Size(180, 32);
            lblTipoUser.TabIndex = 13;
            lblTipoUser.Text = "Tipo de usuario";
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(155, 436);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(291, 37);
            txtApellido.TabIndex = 14;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblApellido.Location = new Point(243, 401);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(102, 32);
            lblApellido.TabIndex = 16;
            lblApellido.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(182, 789);
            label1.Name = "label1";
            label1.Size = new Size(243, 25);
            label1.TabIndex = 17;
            label1.Text = "Mercado (no tan) libre - 2023";
            // 
            // FormRegistros
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 823);
            Controls.Add(label1);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblTipoUser);
            Controls.Add(cbTipoUser);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(txtLegajo);
            Controls.Add(lblLegajo);
            Name = "FormRegistros";
            Text = "FormRegistros";
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(lblTitulo, 0);
            Controls.SetChildIndex(txtMail, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(lblMail, 0);
            Controls.SetChildIndex(lblPassword, 0);
            Controls.SetChildIndex(btn1, 0);
            Controls.SetChildIndex(btn2, 0);
            Controls.SetChildIndex(lblLegajo, 0);
            Controls.SetChildIndex(txtLegajo, 0);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(lblName, 0);
            Controls.SetChildIndex(cbTipoUser, 0);
            Controls.SetChildIndex(lblTipoUser, 0);
            Controls.SetChildIndex(txtApellido, 0);
            Controls.SetChildIndex(lblApellido, 0);
            Controls.SetChildIndex(label1, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label lblLegajo;
        protected TextBox txtLegajo;
        protected TextBox txtName;
        protected Label lblName;
        public ComboBox cbPropiedadesUnicas;
        protected Label lblTipoUser;
        private TextBox txtApellido;
        protected Label lblCbPropio;
        protected Label lblApellido;
        protected ComboBox cbTipoUser;
        private Label label1;
    }
}