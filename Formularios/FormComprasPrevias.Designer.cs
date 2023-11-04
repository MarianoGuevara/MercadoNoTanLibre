namespace Formularios
{
    partial class FormComprasPrevias
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
            SuspendLayout();
            // 
            // rbInfo
            // 
            rbInfo.Location = new Point(0, 114);
            rbInfo.Size = new Size(800, 549);
            // 
            // lblInfo
            // 
            lblInfo.Location = new Point(378, 32);
            lblInfo.Size = new Size(409, 38);
            lblInfo.Text = "COMPRAS PREVIAS EN LA APP";
            // 
            // FormComprasPrevias
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 675);
            Name = "FormComprasPrevias";
            Text = "FormComprasPrevias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}