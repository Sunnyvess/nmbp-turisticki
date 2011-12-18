namespace turistickiXML.Presentation
{
    partial class BolnicaInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.dezurstvoLabel = new System.Windows.Forms.Label();
            this.radnoVrijemeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.opisLabel = new System.Windows.Forms.Label();
            this.adresaLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(250, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Dežurna:";
            // 
            // dezurstvoLabel
            // 
            this.dezurstvoLabel.AutoSize = true;
            this.dezurstvoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dezurstvoLabel.Location = new System.Drawing.Point(307, 373);
            this.dezurstvoLabel.Name = "dezurstvoLabel";
            this.dezurstvoLabel.Size = new System.Drawing.Size(29, 16);
            this.dezurstvoLabel.TabIndex = 16;
            this.dezurstvoLabel.Text = "DA";
            // 
            // radnoVrijemeLabel
            // 
            this.radnoVrijemeLabel.AutoSize = true;
            this.radnoVrijemeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radnoVrijemeLabel.Location = new System.Drawing.Point(107, 373);
            this.radnoVrijemeLabel.Name = "radnoVrijemeLabel";
            this.radnoVrijemeLabel.Size = new System.Drawing.Size(93, 16);
            this.radnoVrijemeLabel.TabIndex = 15;
            this.radnoVrijemeLabel.Text = "09:30 - 21:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Radno vrijeme:";
            // 
            // opisLabel
            // 
            this.opisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opisLabel.Location = new System.Drawing.Point(12, 86);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size(323, 277);
            this.opisLabel.TabIndex = 13;
            this.opisLabel.Text = "Ovdje ide opis bolnice";
            // 
            // adresaLabel
            // 
            this.adresaLabel.AutoSize = true;
            this.adresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresaLabel.Location = new System.Drawing.Point(11, 40);
            this.adresaLabel.Name = "adresaLabel";
            this.adresaLabel.Size = new System.Drawing.Size(159, 16);
            this.adresaLabel.TabIndex = 12;
            this.adresaLabel.Text = "Draškovićeva 19, Zagreb";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(11, 10);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(204, 20);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Klinika za traumatologiju";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::turistickiXML.Properties.Resources.info;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(295, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 40);
            this.panel1.TabIndex = 19;
            // 
            // BolnicaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 394);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dezurstvoLabel);
            this.Controls.Add(this.radnoVrijemeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opisLabel);
            this.Controls.Add(this.adresaLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "BolnicaInfo";
            this.Text = "Informacije o bolnici";
            this.Load += new System.EventHandler(this.BolnicaInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dezurstvoLabel;
        private System.Windows.Forms.Label radnoVrijemeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label opisLabel;
        private System.Windows.Forms.Label adresaLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel1;
    }
}