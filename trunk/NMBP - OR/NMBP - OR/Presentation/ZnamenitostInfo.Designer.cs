namespace NMBP___OR.Presentation {
    partial class ZnamenitostInfo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.slikaPanel = new System.Windows.Forms.Panel ();
            this.radnoVrijemeLabel = new System.Windows.Forms.Label ();
            this.label1 = new System.Windows.Forms.Label ();
            this.opisLabel = new System.Windows.Forms.Label ();
            this.adresaLabel = new System.Windows.Forms.Label ();
            this.nameLabel = new System.Windows.Forms.Label ();
            this.panel1 = new System.Windows.Forms.Panel ();
            this.label2 = new System.Windows.Forms.Label ();
            this.tipZnamenLabel = new System.Windows.Forms.Label ();
            this.SuspendLayout ();
            // 
            // slikaPanel
            // 
            this.slikaPanel.Location = new System.Drawing.Point (12, 82);
            this.slikaPanel.Name = "slikaPanel";
            this.slikaPanel.Size = new System.Drawing.Size (140, 119);
            this.slikaPanel.TabIndex = 33;
            // 
            // radnoVrijemeLabel
            // 
            this.radnoVrijemeLabel.AutoSize = true;
            this.radnoVrijemeLabel.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.radnoVrijemeLabel.Location = new System.Drawing.Point (12, 252);
            this.radnoVrijemeLabel.Name = "radnoVrijemeLabel";
            this.radnoVrijemeLabel.Size = new System.Drawing.Size (93, 16);
            this.radnoVrijemeLabel.TabIndex = 32;
            this.radnoVrijemeLabel.Text = "09:30 - 21:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label1.Location = new System.Drawing.Point (13, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (99, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Radno vrijeme:";
            // 
            // opisLabel
            // 
            this.opisLabel.AutoSize = true;
            this.opisLabel.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.opisLabel.Location = new System.Drawing.Point (158, 82);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size (84, 15);
            this.opisLabel.TabIndex = 30;
            this.opisLabel.Text = "Ovdje ide opis";
            // 
            // adresaLabel
            // 
            this.adresaLabel.AutoSize = true;
            this.adresaLabel.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.adresaLabel.Location = new System.Drawing.Point (12, 39);
            this.adresaLabel.Name = "adresaLabel";
            this.adresaLabel.Size = new System.Drawing.Size (159, 16);
            this.adresaLabel.TabIndex = 29;
            this.adresaLabel.Text = "Draškovićeva 19, Zagreb";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.nameLabel.Location = new System.Drawing.Point (12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size (106, 20);
            this.nameLabel.TabIndex = 28;
            this.nameLabel.Text = "Park prirode";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::NMBP___OR.Properties.Resources.info;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point (357, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size (50, 50);
            this.panel1.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.label2.Location = new System.Drawing.Point (299, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size (108, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tip znamenitosti:";
            // 
            // tipZnamenLabel
            // 
            this.tipZnamenLabel.AutoSize = true;
            this.tipZnamenLabel.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.tipZnamenLabel.Location = new System.Drawing.Point (299, 253);
            this.tipZnamenLabel.Name = "tipZnamenLabel";
            this.tipZnamenLabel.Size = new System.Drawing.Size (77, 16);
            this.tipZnamenLabel.TabIndex = 17;
            this.tipZnamenLabel.Text = "Spomenik";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (415, 278);
            this.Controls.Add (this.label2);
            this.Controls.Add (this.tipZnamenLabel);
            this.Controls.Add (this.slikaPanel);
            this.Controls.Add (this.radnoVrijemeLabel);
            this.Controls.Add (this.label1);
            this.Controls.Add (this.opisLabel);
            this.Controls.Add (this.adresaLabel);
            this.Controls.Add (this.nameLabel);
            this.Controls.Add (this.panel1);
            this.Name = "Info";
            this.Text = "Informacije o znamenitosti";
            this.ResumeLayout (false);
            this.PerformLayout ();

        }

        #endregion

        private System.Windows.Forms.Panel slikaPanel;
        private System.Windows.Forms.Label radnoVrijemeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label opisLabel;
        private System.Windows.Forms.Label adresaLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tipZnamenLabel;

    }
}