﻿namespace NMBP___OR.Presentation {
    partial class ParkNewEdit {
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
          this.components = new System.ComponentModel.Container();
          this.ucitajSlikuTB = new System.Windows.Forms.Button();
          this.otvoren = new System.Windows.Forms.CheckBox();
          this.label4 = new System.Windows.Forms.Label();
          this.radnoVrijemeTB = new System.Windows.Forms.TextBox();
          this.slikaPanel = new System.Windows.Forms.Panel();
          this.parkPB = new System.Windows.Forms.PictureBox();
          this.label3 = new System.Windows.Forms.Label();
          this.opisTB = new System.Windows.Forms.TextBox();
          this.label2 = new System.Windows.Forms.Label();
          this.ulicaTB = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.nazivTB = new System.Windows.Forms.TextBox();
          this.panel1 = new System.Windows.Forms.Panel();
          this.odustaniBTN = new System.Windows.Forms.Button();
          this.prihvatiBTN = new System.Windows.Forms.Button();
          this.brojTB = new System.Windows.Forms.TextBox();
          this.gradComboBox = new System.Windows.Forms.ComboBox();
          this.DeleteButton = new System.Windows.Forms.Button();
          this.ZamijeniButton = new System.Windows.Forms.Button();
          this.previousPictureButton = new System.Windows.Forms.Button();
          this.nextPictureButton = new System.Windows.Forms.Button();
          this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
          this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
          this.slikaPanel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.parkPB)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
          this.SuspendLayout();
          // 
          // ucitajSlikuTB
          // 
          this.ucitajSlikuTB.Location = new System.Drawing.Point(626, 3);
          this.ucitajSlikuTB.Name = "ucitajSlikuTB";
          this.ucitajSlikuTB.Size = new System.Drawing.Size(85, 26);
          this.ucitajSlikuTB.TabIndex = 7;
          this.ucitajSlikuTB.Text = "Učitaj sliku";
          this.ucitajSlikuTB.UseVisualStyleBackColor = true;
          this.ucitajSlikuTB.Click += new System.EventHandler(this.ucitajSlikuTB_Click);
          // 
          // otvoren
          // 
          this.otvoren.AutoSize = true;
          this.otvoren.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.otvoren.Location = new System.Drawing.Point(59, 253);
          this.otvoren.Name = "otvoren";
          this.otvoren.Size = new System.Drawing.Size(80, 22);
          this.otvoren.TabIndex = 6;
          this.otvoren.Text = "Otvoren";
          this.otvoren.UseVisualStyleBackColor = true;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.label4.Location = new System.Drawing.Point(56, 160);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(96, 16);
          this.label4.TabIndex = 22;
          this.label4.Text = "Radno vrijeme";
          // 
          // radnoVrijemeTB
          // 
          this.radnoVrijemeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.radnoVrijemeTB.Location = new System.Drawing.Point(56, 179);
          this.radnoVrijemeTB.Multiline = true;
          this.radnoVrijemeTB.Name = "radnoVrijemeTB";
          this.radnoVrijemeTB.Size = new System.Drawing.Size(260, 43);
          this.radnoVrijemeTB.TabIndex = 4;
          // 
          // slikaPanel
          // 
          this.slikaPanel.AutoScroll = true;
          this.slikaPanel.BackColor = System.Drawing.SystemColors.Control;
          this.slikaPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
          this.slikaPanel.Controls.Add(this.parkPB);
          this.slikaPanel.Location = new System.Drawing.Point(335, 32);
          this.slikaPanel.Name = "slikaPanel";
          this.slikaPanel.Size = new System.Drawing.Size(376, 291);
          this.slikaPanel.TabIndex = 20;
          // 
          // parkPB
          // 
          this.parkPB.Location = new System.Drawing.Point(0, -1);
          this.parkPB.Name = "parkPB";
          this.parkPB.Size = new System.Drawing.Size(376, 291);
          this.parkPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
          this.parkPB.TabIndex = 0;
          this.parkPB.TabStop = false;
          this.parkPB.DoubleClick += new System.EventHandler(this.parkPB_DoubleClick);
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.label3.Location = new System.Drawing.Point(56, 312);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(36, 16);
          this.label3.TabIndex = 19;
          this.label3.Text = "Opis";
          // 
          // opisTB
          // 
          this.opisTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.opisTB.Location = new System.Drawing.Point(56, 331);
          this.opisTB.Multiline = true;
          this.opisTB.Name = "opisTB";
          this.opisTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
          this.opisTB.Size = new System.Drawing.Size(535, 126);
          this.opisTB.TabIndex = 5;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.label2.Location = new System.Drawing.Point(56, 68);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(52, 16);
          this.label2.TabIndex = 17;
          this.label2.Text = "Adresa";
          // 
          // ulicaTB
          // 
          this.ulicaTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.ulicaTB.Location = new System.Drawing.Point(56, 87);
          this.ulicaTB.Name = "ulicaTB";
          this.ulicaTB.Size = new System.Drawing.Size(186, 24);
          this.ulicaTB.TabIndex = 1;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.label1.Location = new System.Drawing.Point(56, 13);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(42, 16);
          this.label1.TabIndex = 15;
          this.label1.Text = "Naziv";
          // 
          // nazivTB
          // 
          this.nazivTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.nazivTB.Location = new System.Drawing.Point(56, 32);
          this.nazivTB.Name = "nazivTB";
          this.nazivTB.Size = new System.Drawing.Size(260, 26);
          this.nazivTB.TabIndex = 0;
          this.nazivTB.Validating += new System.ComponentModel.CancelEventHandler(this.nazivTB_Validating);
          // 
          // panel1
          // 
          this.panel1.BackgroundImage = global::NMBP___OR.Properties.Resources.park;
          this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
          this.panel1.Location = new System.Drawing.Point(12, 13);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(25, 30);
          this.panel1.TabIndex = 13;
          // 
          // odustaniBTN
          // 
          this.odustaniBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.cancel;
          this.odustaniBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
          this.odustaniBTN.Location = new System.Drawing.Point(668, 414);
          this.odustaniBTN.Name = "odustaniBTN";
          this.odustaniBTN.Size = new System.Drawing.Size(43, 43);
          this.odustaniBTN.TabIndex = 9;
          this.odustaniBTN.UseVisualStyleBackColor = true;
          this.odustaniBTN.Click += new System.EventHandler(this.odustaniBTN_Click);
          // 
          // prihvatiBTN
          // 
          this.prihvatiBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.accept;
          this.prihvatiBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
          this.prihvatiBTN.Location = new System.Drawing.Point(619, 414);
          this.prihvatiBTN.Name = "prihvatiBTN";
          this.prihvatiBTN.Size = new System.Drawing.Size(43, 43);
          this.prihvatiBTN.TabIndex = 8;
          this.prihvatiBTN.UseVisualStyleBackColor = true;
          this.prihvatiBTN.Click += new System.EventHandler(this.prihvatiBTN_Click);
          // 
          // brojTB
          // 
          this.brojTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.brojTB.Location = new System.Drawing.Point(248, 87);
          this.brojTB.Name = "brojTB";
          this.brojTB.Size = new System.Drawing.Size(65, 24);
          this.brojTB.TabIndex = 2;
          this.brojTB.Validating += new System.ComponentModel.CancelEventHandler(this.brojTB_Validating);
          // 
          // gradComboBox
          // 
          this.gradComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
          this.gradComboBox.FormattingEnabled = true;
          this.gradComboBox.Location = new System.Drawing.Point(56, 117);
          this.gradComboBox.Name = "gradComboBox";
          this.gradComboBox.Size = new System.Drawing.Size(120, 24);
          this.gradComboBox.TabIndex = 3;
          // 
          // DeleteButton
          // 
          this.DeleteButton.Location = new System.Drawing.Point(535, 3);
          this.DeleteButton.Name = "DeleteButton";
          this.DeleteButton.Size = new System.Drawing.Size(85, 26);
          this.DeleteButton.TabIndex = 42;
          this.DeleteButton.Text = "Obriši sliku";
          this.DeleteButton.UseVisualStyleBackColor = true;
          this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
          // 
          // ZamijeniButton
          // 
          this.ZamijeniButton.Location = new System.Drawing.Point(444, 3);
          this.ZamijeniButton.Name = "ZamijeniButton";
          this.ZamijeniButton.Size = new System.Drawing.Size(85, 26);
          this.ZamijeniButton.TabIndex = 43;
          this.ZamijeniButton.Text = "Zamijeni sliku";
          this.ZamijeniButton.UseVisualStyleBackColor = true;
          this.ZamijeniButton.Click += new System.EventHandler(this.ZamijeniButton_Click);
          // 
          // previousPictureButton
          // 
          this.previousPictureButton.Location = new System.Drawing.Point(335, 3);
          this.previousPictureButton.Name = "previousPictureButton";
          this.previousPictureButton.Size = new System.Drawing.Size(38, 26);
          this.previousPictureButton.TabIndex = 44;
          this.previousPictureButton.Text = "<";
          this.previousPictureButton.UseVisualStyleBackColor = true;
          this.previousPictureButton.Click += new System.EventHandler(this.previousPictureButton_Click);
          // 
          // nextPictureButton
          // 
          this.nextPictureButton.Location = new System.Drawing.Point(379, 3);
          this.nextPictureButton.Name = "nextPictureButton";
          this.nextPictureButton.Size = new System.Drawing.Size(38, 26);
          this.nextPictureButton.TabIndex = 45;
          this.nextPictureButton.Text = ">";
          this.nextPictureButton.UseVisualStyleBackColor = true;
          this.nextPictureButton.Click += new System.EventHandler(this.nextPictureButton_Click);
          // 
          // errorProvider1
          // 
          this.errorProvider1.ContainerControl = this;
          // 
          // errorProvider2
          // 
          this.errorProvider2.ContainerControl = this;
          // 
          // ParkNewEdit
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.AutoScroll = true;
          this.ClientSize = new System.Drawing.Size(723, 469);
          this.Controls.Add(this.nextPictureButton);
          this.Controls.Add(this.previousPictureButton);
          this.Controls.Add(this.ZamijeniButton);
          this.Controls.Add(this.DeleteButton);
          this.Controls.Add(this.gradComboBox);
          this.Controls.Add(this.brojTB);
          this.Controls.Add(this.odustaniBTN);
          this.Controls.Add(this.prihvatiBTN);
          this.Controls.Add(this.ucitajSlikuTB);
          this.Controls.Add(this.otvoren);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.radnoVrijemeTB);
          this.Controls.Add(this.slikaPanel);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.opisTB);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.ulicaTB);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.nazivTB);
          this.Controls.Add(this.panel1);
          this.Name = "ParkNewEdit";
          this.Text = "Unos/Izmjena parka";
          this.Load += new System.EventHandler(this.ParkNewEdit_Load);
          this.slikaPanel.ResumeLayout(false);
          this.slikaPanel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.parkPB)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ucitajSlikuTB;
        private System.Windows.Forms.CheckBox otvoren;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox radnoVrijemeTB;
        private System.Windows.Forms.Panel slikaPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox opisTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ulicaTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazivTB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button odustaniBTN;
        private System.Windows.Forms.Button prihvatiBTN;
        private System.Windows.Forms.TextBox brojTB;
        private System.Windows.Forms.ComboBox gradComboBox;
        private System.Windows.Forms.PictureBox parkPB;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ZamijeniButton;
        private System.Windows.Forms.Button previousPictureButton;
        private System.Windows.Forms.Button nextPictureButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}