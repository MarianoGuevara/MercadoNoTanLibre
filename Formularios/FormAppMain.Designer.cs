namespace Formularios
{
    partial class FormAppMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppMain));
            ftLogo = new PictureBox();
            ftUser = new PictureBox();
            lblInfo = new Label();
            txtInfoProducto2 = new ListView();
            lblEditarProducto = new Label();
            lblUserInfo = new Label();
            lblOrdenarPrecioAsc = new Label();
            label1 = new Label();
            label2 = new Label();
            lblOrdenarPrecioDesc = new Label();
            lblOrdenarTipoAsc = new Label();
            lblOrdenarTipoDesc = new Label();
            lblVerComprasPrevias = new Label();
            lblCerrarSesion = new Label();
            lblComprar = new Label();
            lblVerLogins = new Label();
            lblVerMiembrosApp = new Label();
            lblVenderProducto = new Label();
            toolTip1 = new ToolTip(components);
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            lblHora = new Label();
            ((System.ComponentModel.ISupportInitialize)ftLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ftUser).BeginInit();
            SuspendLayout();
            // 
            // ftLogo
            // 
            ftLogo.Image = (Image)resources.GetObject("ftLogo.Image");
            ftLogo.Location = new Point(12, 12);
            ftLogo.MinimumSize = new Size(200, 50);
            ftLogo.Name = "ftLogo";
            ftLogo.Size = new Size(304, 75);
            ftLogo.TabIndex = 1;
            ftLogo.TabStop = false;
            // 
            // ftUser
            // 
            ftUser.Image = (Image)resources.GetObject("ftUser.Image");
            ftUser.Location = new Point(12, 90);
            ftUser.Name = "ftUser";
            ftUser.Size = new Size(49, 48);
            ftUser.TabIndex = 2;
            ftUser.TabStop = false;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblInfo.Location = new Point(12, 903);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(532, 21);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "Mercado (no tan) libre - app simulacion de compra venta de objetos - 2023";
            // 
            // txtInfoProducto2
            // 
            txtInfoProducto2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtInfoProducto2.Location = new Point(12, 144);
            txtInfoProducto2.Name = "txtInfoProducto2";
            txtInfoProducto2.Size = new Size(1635, 742);
            txtInfoProducto2.TabIndex = 14;
            txtInfoProducto2.UseCompatibleStateImageBehavior = false;
            // 
            // lblEditarProducto
            // 
            lblEditarProducto.AutoSize = true;
            lblEditarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblEditarProducto.Location = new Point(985, 100);
            lblEditarProducto.Name = "lblEditarProducto";
            lblEditarProducto.Size = new Size(149, 28);
            lblEditarProducto.TabIndex = 16;
            lblEditarProducto.Text = "Editar Producto";
            lblEditarProducto.Click += lblEditarProducto_Click;
            lblEditarProducto.MouseEnter += FormAppMain_MouseEnter;
            lblEditarProducto.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblUserInfo.Location = new Point(67, 100);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(362, 28);
            lblUserInfo.TabIndex = 17;
            lblUserInfo.Text = "Usuario [name], [perfil], [dia/mes/año]";
            // 
            // lblOrdenarPrecioAsc
            // 
            lblOrdenarPrecioAsc.AutoSize = true;
            lblOrdenarPrecioAsc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrdenarPrecioAsc.Location = new Point(771, 37);
            lblOrdenarPrecioAsc.Name = "lblOrdenarPrecioAsc";
            lblOrdenarPrecioAsc.Size = new Size(113, 28);
            lblOrdenarPrecioAsc.TabIndex = 19;
            lblOrdenarPrecioAsc.Text = "Ascendente";
            toolTip1.SetToolTip(lblOrdenarPrecioAsc, "Por precio (ascendente)");
            lblOrdenarPrecioAsc.Click += lblOrdenarPrecioAsc_Click;
            lblOrdenarPrecioAsc.MouseEnter += FormAppMain_MouseEnter;
            lblOrdenarPrecioAsc.MouseLeave += FormAppMain_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(763, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 28);
            label1.TabIndex = 20;
            label1.Text = "Ordenar catálogo: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1038, 35);
            label2.Name = "label2";
            label2.Size = new Size(17, 28);
            label2.TabIndex = 21;
            label2.Text = "|";
            // 
            // lblOrdenarPrecioDesc
            // 
            lblOrdenarPrecioDesc.AutoSize = true;
            lblOrdenarPrecioDesc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrdenarPrecioDesc.Location = new Point(899, 36);
            lblOrdenarPrecioDesc.Name = "lblOrdenarPrecioDesc";
            lblOrdenarPrecioDesc.Size = new Size(124, 28);
            lblOrdenarPrecioDesc.TabIndex = 22;
            lblOrdenarPrecioDesc.Text = "Descendente";
            toolTip1.SetToolTip(lblOrdenarPrecioDesc, "Por precio (descendente)");
            lblOrdenarPrecioDesc.Click += lblOrdenarPrecioDesc_Click;
            lblOrdenarPrecioDesc.MouseEnter += FormAppMain_MouseEnter;
            lblOrdenarPrecioDesc.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblOrdenarTipoAsc
            // 
            lblOrdenarTipoAsc.AutoSize = true;
            lblOrdenarTipoAsc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrdenarTipoAsc.Location = new Point(1071, 35);
            lblOrdenarTipoAsc.Name = "lblOrdenarTipoAsc";
            lblOrdenarTipoAsc.Size = new Size(113, 28);
            lblOrdenarTipoAsc.TabIndex = 24;
            lblOrdenarTipoAsc.Text = "Ascendente";
            toolTip1.SetToolTip(lblOrdenarTipoAsc, "Por tipo (ascendente)");
            lblOrdenarTipoAsc.Click += lblOrdenarTipoAsc_Click;
            lblOrdenarTipoAsc.MouseEnter += FormAppMain_MouseEnter;
            lblOrdenarTipoAsc.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblOrdenarTipoDesc
            // 
            lblOrdenarTipoDesc.AutoSize = true;
            lblOrdenarTipoDesc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblOrdenarTipoDesc.Location = new Point(1215, 35);
            lblOrdenarTipoDesc.Name = "lblOrdenarTipoDesc";
            lblOrdenarTipoDesc.Size = new Size(124, 28);
            lblOrdenarTipoDesc.TabIndex = 25;
            lblOrdenarTipoDesc.Text = "Descendente";
            toolTip1.SetToolTip(lblOrdenarTipoDesc, "Por tipo (descendente)");
            lblOrdenarTipoDesc.Click += lblOrdenarTipoDesc_Click;
            lblOrdenarTipoDesc.MouseEnter += FormAppMain_MouseEnter;
            lblOrdenarTipoDesc.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblVerComprasPrevias
            // 
            lblVerComprasPrevias.AutoSize = true;
            lblVerComprasPrevias.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblVerComprasPrevias.Location = new Point(1047, 896);
            lblVerComprasPrevias.Name = "lblVerComprasPrevias";
            lblVerComprasPrevias.Size = new Size(292, 28);
            lblVerComprasPrevias.TabIndex = 26;
            lblVerComprasPrevias.Text = "Mira toda las compras de la app";
            lblVerComprasPrevias.Click += lblVerComprasPrevias_Click;
            lblVerComprasPrevias.MouseEnter += FormAppMain_MouseEnter;
            lblVerComprasPrevias.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblCerrarSesion
            // 
            lblCerrarSesion.AutoSize = true;
            lblCerrarSesion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblCerrarSesion.Location = new Point(1511, 37);
            lblCerrarSesion.Name = "lblCerrarSesion";
            lblCerrarSesion.Size = new Size(124, 28);
            lblCerrarSesion.TabIndex = 27;
            lblCerrarSesion.Text = "Cerrar sesión";
            lblCerrarSesion.Click += lblCerrarSesion_Click;
            lblCerrarSesion.MouseEnter += FormAppMain_MouseEnter;
            lblCerrarSesion.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblComprar
            // 
            lblComprar.AutoSize = true;
            lblComprar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblComprar.Location = new Point(1225, 100);
            lblComprar.Name = "lblComprar";
            lblComprar.Size = new Size(89, 28);
            lblComprar.TabIndex = 28;
            lblComprar.Text = "Comprar";
            lblComprar.Click += lblComprar_Click;
            lblComprar.MouseEnter += FormAppMain_MouseEnter;
            lblComprar.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblVerLogins
            // 
            lblVerLogins.AutoSize = true;
            lblVerLogins.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblVerLogins.Location = new Point(1537, 90);
            lblVerLogins.Name = "lblVerLogins";
            lblVerLogins.Size = new Size(98, 28);
            lblVerLogins.TabIndex = 29;
            lblVerLogins.Text = "Ver logins";
            lblVerLogins.Click += lblVerLogins_Click;
            lblVerLogins.MouseEnter += FormAppMain_MouseEnter;
            lblVerLogins.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblVerMiembrosApp
            // 
            lblVerMiembrosApp.AutoSize = true;
            lblVerMiembrosApp.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblVerMiembrosApp.Location = new Point(1416, 897);
            lblVerMiembrosApp.Name = "lblVerMiembrosApp";
            lblVerMiembrosApp.Size = new Size(219, 28);
            lblVerMiembrosApp.TabIndex = 30;
            lblVerMiembrosApp.Text = "Ver miembros de la app";
            lblVerMiembrosApp.Click += lblVerMiembrosApp_Click;
            lblVerMiembrosApp.MouseEnter += FormAppMain_MouseEnter;
            lblVerMiembrosApp.MouseLeave += FormAppMain_MouseLeave;
            // 
            // lblVenderProducto
            // 
            lblVenderProducto.AutoSize = true;
            lblVenderProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblVenderProducto.Location = new Point(763, 100);
            lblVenderProducto.Name = "lblVenderProducto";
            lblVenderProducto.Size = new Size(160, 28);
            lblVenderProducto.TabIndex = 31;
            lblVenderProducto.Text = "Vender producto";
            lblVenderProducto.Click += lblVenderProducto_Click;
            lblVenderProducto.MouseEnter += FormAppMain_MouseEnter;
            lblVenderProducto.MouseLeave += FormAppMain_MouseLeave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(1364, 897);
            label4.Name = "label4";
            label4.Size = new Size(17, 28);
            label4.TabIndex = 34;
            label4.Text = "|";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(932, 100);
            label3.Name = "label3";
            label3.Size = new Size(17, 28);
            label3.TabIndex = 35;
            label3.Text = "|";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(1167, 100);
            label5.Name = "label5";
            label5.Size = new Size(17, 28);
            label5.TabIndex = 36;
            label5.Text = "|";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblHora.Location = new Point(343, 35);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(317, 30);
            lblHora.TabIndex = 38;
            lblHora.Text = "[año/mes/dia, hora:min:segs]";
            // 
            // FormAppMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 100);
            ClientSize = new Size(1659, 944);
            Controls.Add(lblHora);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblVenderProducto);
            Controls.Add(lblVerMiembrosApp);
            Controls.Add(lblVerLogins);
            Controls.Add(lblComprar);
            Controls.Add(lblCerrarSesion);
            Controls.Add(lblVerComprasPrevias);
            Controls.Add(lblOrdenarTipoDesc);
            Controls.Add(lblOrdenarTipoAsc);
            Controls.Add(lblOrdenarPrecioDesc);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblOrdenarPrecioAsc);
            Controls.Add(lblUserInfo);
            Controls.Add(lblEditarProducto);
            Controls.Add(txtInfoProducto2);
            Controls.Add(lblInfo);
            Controls.Add(ftUser);
            Controls.Add(ftLogo);
            Name = "FormAppMain";
            Text = "FormAppMain";
            FormClosing += FormAppMain_FormClosing;
            Load += FormAppMain_Load;
            MouseEnter += FormAppMain_MouseEnter;
            MouseLeave += FormAppMain_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)ftLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)ftUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox ftLogo;
        private PictureBox ftUser;
        private Label lblInfoApp;
        private Label lblInfo;
        private Button button1;
        private ListView txtInfoProducto2;
        private Label lblEditarProducto;
        private Label lblUserInfo;
        private Label lblOrdenarPrecioAsc;
        private Label label1;
        private Label label2;
        private Label lblOrdenarPrecioDesc;
        private Label lblOrdenarTipoAsc;
        private Label lblOrdenarTipoDesc;
        private Label lblVerComprasPrevias;
        private Label lblCerrarSesion;
        private Label lblComprar;
        private Label lblVerLogins;
        private Label lblVerMiembrosApp;
        private Label lblVenderProducto;
        private ToolTip toolTip1;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label lblHora;
    }
}