namespace Formularios
{
    partial class FormVerLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerLogin));
            rbInfo = new RichTextBox();
            lblInfo = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // rbInfo
            // 
            rbInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            rbInfo.Location = new Point(3, 101);
            rbInfo.Name = "rbInfo";
            rbInfo.Size = new Size(905, 687);
            rbInfo.TabIndex = 0;
            rbInfo.Text = "";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblInfo.Location = new Point(403, 29);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(336, 38);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "TEXTO BLA BLA BLA BLA";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(28, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(310, 75);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // FormVerLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 240, 100);
            ClientSize = new Size(913, 799);
            Controls.Add(pictureBox1);
            Controls.Add(lblInfo);
            Controls.Add(rbInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormVerLogin";
            Text = "FormVerUsers";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected RichTextBox rbInfo;
        protected Label lblInfo;
        private PictureBox pictureBox1;
    }
}