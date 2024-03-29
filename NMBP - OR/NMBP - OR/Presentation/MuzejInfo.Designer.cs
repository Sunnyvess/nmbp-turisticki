﻿namespace NMBP___OR.Presentation {
    partial class MuzejInfo {
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
            this.slikaPanel = new System.Windows.Forms.Panel();
            this.muzejPB = new System.Windows.Forms.PictureBox();
            this.tipMuzejaLabel = new System.Windows.Forms.Label();
            this.radnoVrijemeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.opisLabel = new System.Windows.Forms.Label();
            this.adresaLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.previousPictureButton = new System.Windows.Forms.Button();
            this.nextPictureButton = new System.Windows.Forms.Button();
            this.slikaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muzejPB)).BeginInit();
            this.SuspendLayout();
            // 
            // slikaPanel
            // 
            this.slikaPanel.AutoScroll = true;
            this.slikaPanel.Controls.Add(this.muzejPB);
            this.slikaPanel.Location = new System.Drawing.Point(16, 118);
            this.slikaPanel.Name = "slikaPanel";
            this.slikaPanel.Size = new System.Drawing.Size(376, 291);
            this.slikaPanel.TabIndex = 15;
            // 
            // muzejPB
            // 
            this.muzejPB.Location = new System.Drawing.Point(-1, 0);
            this.muzejPB.Name = "muzejPB";
            this.muzejPB.Size = new System.Drawing.Size(376, 291);
            this.muzejPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.muzejPB.TabIndex = 0;
            this.muzejPB.TabStop = false;
            this.muzejPB.DoubleClick += new System.EventHandler(this.muzejPB_DoubleClick);
            // 
            // tipMuzejaLabel
            // 
            this.tipMuzejaLabel.AutoSize = true;
            this.tipMuzejaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tipMuzejaLabel.Location = new System.Drawing.Point(530, 444);
            this.tipMuzejaLabel.Name = "tipMuzejaLabel";
            this.tipMuzejaLabel.Size = new System.Drawing.Size(100, 16);
            this.tipMuzejaLabel.TabIndex = 14;
            this.tipMuzejaLabel.Text = "Prirodoslovni";
            // 
            // radnoVrijemeLabel
            // 
            this.radnoVrijemeLabel.AutoSize = true;
            this.radnoVrijemeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radnoVrijemeLabel.Location = new System.Drawing.Point(105, 444);
            this.radnoVrijemeLabel.Name = "radnoVrijemeLabel";
            this.radnoVrijemeLabel.Size = new System.Drawing.Size(93, 16);
            this.radnoVrijemeLabel.TabIndex = 13;
            this.radnoVrijemeLabel.Text = "09:30 - 21:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Radno vrijeme:";
            // 
            // opisLabel
            // 
            this.opisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opisLabel.Location = new System.Drawing.Point(397, 118);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size(233, 291);
            this.opisLabel.TabIndex = 11;
            this.opisLabel.Text = "Ovdje ide opis";
            // 
            // adresaLabel
            // 
            this.adresaLabel.AutoSize = true;
            this.adresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresaLabel.Location = new System.Drawing.Point(12, 39);
            this.adresaLabel.Name = "adresaLabel";
            this.adresaLabel.Size = new System.Drawing.Size(159, 16);
            this.adresaLabel.TabIndex = 10;
            this.adresaLabel.Text = "Draškovićeva 19, Zagreb";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(163, 20);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "Prirodoslovni muzej";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::NMBP___OR.Properties.Resources.info;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(580, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 50);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(457, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tip muzeja:";
            // 
            // previousPictureButton
            // 
            this.previousPictureButton.Location = new System.Drawing.Point(16, 89);
            this.previousPictureButton.Name = "previousPictureButton";
            this.previousPictureButton.Size = new System.Drawing.Size(75, 23);
            this.previousPictureButton.TabIndex = 17;
            this.previousPictureButton.Text = "Prethodna";
            this.previousPictureButton.UseVisualStyleBackColor = true;
            this.previousPictureButton.Click += new System.EventHandler(this.previousPictureButton_Click);
            // 
            // nextPictureButton
            // 
            this.nextPictureButton.Location = new System.Drawing.Point(96, 89);
            this.nextPictureButton.Name = "nextPictureButton";
            this.nextPictureButton.Size = new System.Drawing.Size(75, 23);
            this.nextPictureButton.TabIndex = 18;
            this.nextPictureButton.Text = "Sljedeća";
            this.nextPictureButton.UseVisualStyleBackColor = true;
            this.nextPictureButton.Click += new System.EventHandler(this.nextPictureButton_Click);
            // 
            // MuzejInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(639, 469);
            this.Controls.Add(this.nextPictureButton);
            this.Controls.Add(this.previousPictureButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.slikaPanel);
            this.Controls.Add(this.tipMuzejaLabel);
            this.Controls.Add(this.radnoVrijemeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opisLabel);
            this.Controls.Add(this.adresaLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.panel1);
            this.Name = "MuzejInfo";
            this.Text = "Informacije o muzeju";
            this.Load += new System.EventHandler(this.MuzejInfo_Load);
            this.slikaPanel.ResumeLayout(false);
            this.slikaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muzejPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel slikaPanel;
        private System.Windows.Forms.Label tipMuzejaLabel;
        private System.Windows.Forms.Label radnoVrijemeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label opisLabel;
        private System.Windows.Forms.Label adresaLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox muzejPB;
        private System.Windows.Forms.Button previousPictureButton;
        private System.Windows.Forms.Button nextPictureButton;

    }
}