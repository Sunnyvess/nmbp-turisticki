namespace NMBP___OR.Presentation
{
    partial class SlikaForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.previousPictureButton = new System.Windows.Forms.Button();
            this.nextPictureButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 402);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(616, 402);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // previousPictureButton
            // 
            this.previousPictureButton.Location = new System.Drawing.Point(218, 412);
            this.previousPictureButton.Name = "previousPictureButton";
            this.previousPictureButton.Size = new System.Drawing.Size(75, 23);
            this.previousPictureButton.TabIndex = 11;
            this.previousPictureButton.Text = "Prethodna";
            this.previousPictureButton.UseVisualStyleBackColor = true;
            this.previousPictureButton.Click += new System.EventHandler(this.previousPictureButton_Click);
            // 
            // nextPictureButton
            // 
            this.nextPictureButton.Location = new System.Drawing.Point(319, 412);
            this.nextPictureButton.Name = "nextPictureButton";
            this.nextPictureButton.Size = new System.Drawing.Size(75, 23);
            this.nextPictureButton.TabIndex = 12;
            this.nextPictureButton.Text = "Sljedeća";
            this.nextPictureButton.UseVisualStyleBackColor = true;
            this.nextPictureButton.Click += new System.EventHandler(this.nextPictureButton_Click);
            // 
            // SlikaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(617, 447);
            this.Controls.Add(this.nextPictureButton);
            this.Controls.Add(this.previousPictureButton);
            this.Controls.Add(this.panel1);
            this.Name = "SlikaForm";
            this.Text = "Prikaz slika";
            this.Load += new System.EventHandler(this.SlikaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button previousPictureButton;
        private System.Windows.Forms.Button nextPictureButton;
    }
}