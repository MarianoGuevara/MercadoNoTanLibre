namespace Formularios
{
    partial class FormGenerarObjetoVenta
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
            txtCaract1 = new TextBox();
            lblTipoProducto = new Label();
            comboBox1 = new ComboBox();
            lblCaract1 = new Label();
            cbCaract2 = new ComboBox();
            lblCaract2 = new Label();
            rbDescrpcion = new RichTextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Location = new Point(730, 47);
            lblTitulo.Size = new Size(0, 38);
            lblTitulo.Text = "";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(68, 190);
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(422, 190);
            // 
            // lblMail
            // 
            lblMail.Location = new Point(68, 155);
            lblMail.Size = new Size(79, 32);
            lblMail.Text = "Precio";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(422, 155);
            lblPassword.Size = new Size(208, 32);
            lblPassword.Text = "Durabilidad (años)";
            // 
            // btn1
            // 
            btn1.Location = new Point(68, 814);
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(490, 814);
            btn2.Text = "Boton 2";
            btn2.Click += btn2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(238, 30);
            // 
            // txtCaract1
            // 
            txtCaract1.Location = new Point(248, 419);
            txtCaract1.Name = "txtCaract1";
            txtCaract1.Size = new Size(285, 31);
            txtCaract1.TabIndex = 7;
            // 
            // lblTipoProducto
            // 
            lblTipoProducto.AutoSize = true;
            lblTipoProducto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTipoProducto.Location = new Point(291, 283);
            lblTipoProducto.Name = "lblTipoProducto";
            lblTipoProducto.Size = new Size(199, 32);
            lblTipoProducto.TabIndex = 8;
            lblTipoProducto.Text = "Tipo de producto";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(248, 318);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(285, 33);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblCaract1
            // 
            lblCaract1.AutoSize = true;
            lblCaract1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaract1.Location = new Point(350, 384);
            lblCaract1.Name = "lblCaract1";
            lblCaract1.Size = new Size(0, 32);
            lblCaract1.TabIndex = 10;
            // 
            // cbCaract2
            // 
            cbCaract2.FormattingEnabled = true;
            cbCaract2.Location = new Point(248, 512);
            cbCaract2.Name = "cbCaract2";
            cbCaract2.Size = new Size(285, 33);
            cbCaract2.TabIndex = 11;
            cbCaract2.SelectedIndexChanged += cbCaract2_SelectedIndexChanged;
            // 
            // lblCaract2
            // 
            lblCaract2.AutoSize = true;
            lblCaract2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaract2.Location = new Point(303, 477);
            lblCaract2.Name = "lblCaract2";
            lblCaract2.Size = new Size(0, 32);
            lblCaract2.TabIndex = 12;
            // 
            // rbDescrpcion
            // 
            rbDescrpcion.Location = new Point(68, 606);
            rbDescrpcion.Name = "rbDescrpcion";
            rbDescrpcion.Size = new Size(642, 166);
            rbDescrpcion.TabIndex = 13;
            rbDescrpcion.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(68, 571);
            label3.Name = "label3";
            label3.Size = new Size(282, 32);
            label3.TabIndex = 14;
            label3.Text = "Descripcion del producto";
            // 
            // FormGenerarObjetoVenta
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 894);
            Controls.Add(label3);
            Controls.Add(rbDescrpcion);
            Controls.Add(lblCaract2);
            Controls.Add(cbCaract2);
            Controls.Add(lblCaract1);
            Controls.Add(comboBox1);
            Controls.Add(lblTipoProducto);
            Controls.Add(txtCaract1);
            Name = "FormGenerarObjetoVenta";
            Text = "FormGenerarObjetoVenta";
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(lblTitulo, 0);
            Controls.SetChildIndex(txtMail, 0);
            Controls.SetChildIndex(txtPassword, 0);
            Controls.SetChildIndex(lblMail, 0);
            Controls.SetChildIndex(lblPassword, 0);
            Controls.SetChildIndex(btn1, 0);
            Controls.SetChildIndex(btn2, 0);
            Controls.SetChildIndex(txtCaract1, 0);
            Controls.SetChildIndex(lblTipoProducto, 0);
            Controls.SetChildIndex(comboBox1, 0);
            Controls.SetChildIndex(lblCaract1, 0);
            Controls.SetChildIndex(cbCaract2, 0);
            Controls.SetChildIndex(lblCaract2, 0);
            Controls.SetChildIndex(rbDescrpcion, 0);
            Controls.SetChildIndex(label3, 0);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCaract1;
        private Label lblTipoProducto;
        private ComboBox comboBox1;
        private Label lblCaract1;
        private ComboBox cbCaract2;
        private Label lblCaract2;
        private RichTextBox rbDescrpcion;
        private Label label3;
    }
}