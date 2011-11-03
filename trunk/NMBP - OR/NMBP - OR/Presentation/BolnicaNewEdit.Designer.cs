namespace NMBP___OR.Presentation {
    partial class BolnicaNewEdit {
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
            this.nazivTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adresaTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.opisTB = new System.Windows.Forms.TextBox();
            this.slikaPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radnoVrijemeTB = new System.Windows.Forms.TextBox();
            this.dezurna = new System.Windows.Forms.CheckBox();
            this.ucitajSlikuBTN = new System.Windows.Forms.Button();
            this.odustaniBTN = new System.Windows.Forms.Button();
            this.prihvatiBTN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bolnicaDataSet1 = new NMBP___OR.bolnicaDataSet1();
            this.bolnicaTableAdapter = new NMBP___OR.bolnicaDataSet1TableAdapters.bolnicaTableAdapter();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.gradTableAdapter = new NMBP___OR.bolnicaDataSet1TableAdapters.gradTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bolnicaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // nazivTB
            // 
            this.nazivTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nazivTB.Location = new System.Drawing.Point(53, 31);
            this.nazivTB.Name = "nazivTB";
            this.nazivTB.Size = new System.Drawing.Size(260, 26);
            this.nazivTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(53, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Adresa";
            // 
            // adresaTB
            // 
            this.adresaTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresaTB.Location = new System.Drawing.Point(53, 86);
            this.adresaTB.Name = "adresaTB";
            this.adresaTB.Size = new System.Drawing.Size(260, 24);
            this.adresaTB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(53, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Opis";
            // 
            // opisTB
            // 
            this.opisTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opisTB.Location = new System.Drawing.Point(56, 233);
            this.opisTB.Multiline = true;
            this.opisTB.Name = "opisTB";
            this.opisTB.Size = new System.Drawing.Size(459, 46);
            this.opisTB.TabIndex = 6;
            // 
            // slikaPanel
            // 
            this.slikaPanel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.slikaPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slikaPanel.Location = new System.Drawing.Point(335, 31);
            this.slikaPanel.Name = "slikaPanel";
            this.slikaPanel.Size = new System.Drawing.Size(180, 180);
            this.slikaPanel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(53, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Radno vrijeme";
            // 
            // radnoVrijemeTB
            // 
            this.radnoVrijemeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radnoVrijemeTB.Location = new System.Drawing.Point(53, 143);
            this.radnoVrijemeTB.Multiline = true;
            this.radnoVrijemeTB.Name = "radnoVrijemeTB";
            this.radnoVrijemeTB.Size = new System.Drawing.Size(260, 65);
            this.radnoVrijemeTB.TabIndex = 9;
            // 
            // dezurna
            // 
            this.dezurna.AutoSize = true;
            this.dezurna.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dezurna.Location = new System.Drawing.Point(230, 6);
            this.dezurna.Name = "dezurna";
            this.dezurna.Size = new System.Drawing.Size(83, 22);
            this.dezurna.TabIndex = 11;
            this.dezurna.Text = "Dežurna";
            this.dezurna.UseVisualStyleBackColor = true;
            // 
            // ucitajSlikuBTN
            // 
            this.ucitajSlikuBTN.Location = new System.Drawing.Point(440, 6);
            this.ucitajSlikuBTN.Name = "ucitajSlikuBTN";
            this.ucitajSlikuBTN.Size = new System.Drawing.Size(75, 23);
            this.ucitajSlikuBTN.TabIndex = 12;
            this.ucitajSlikuBTN.Text = "Ucitaj sliku";
            this.ucitajSlikuBTN.UseVisualStyleBackColor = true;
            // 
            // odustaniBTN
            // 
            this.odustaniBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.cancel;
            this.odustaniBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.odustaniBTN.Location = new System.Drawing.Point(471, 285);
            this.odustaniBTN.Name = "odustaniBTN";
            this.odustaniBTN.Size = new System.Drawing.Size(43, 43);
            this.odustaniBTN.TabIndex = 14;
            this.odustaniBTN.UseVisualStyleBackColor = true;
            this.odustaniBTN.Click += new System.EventHandler(this.odustaniBTN_Click);
            // 
            // prihvatiBTN
            // 
            this.prihvatiBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.accept;
            this.prihvatiBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.prihvatiBTN.Location = new System.Drawing.Point(422, 285);
            this.prihvatiBTN.Name = "prihvatiBTN";
            this.prihvatiBTN.Size = new System.Drawing.Size(43, 43);
            this.prihvatiBTN.TabIndex = 13;
            this.prihvatiBTN.UseVisualStyleBackColor = true;
            this.prihvatiBTN.Click += new System.EventHandler(this.prihvatiBTN_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::NMBP___OR.Properties.Resources.bolnica;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 30);
            this.panel1.TabIndex = 1;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "bolnica";
            this.bindingSource1.DataSource = this.bolnicaDataSet1;
            // 
            // bolnicaDataSet1
            // 
            this.bolnicaDataSet1.DataSetName = "bolnicaDataSet1";
            this.bolnicaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bolnicaTableAdapter
            // 
            this.bolnicaTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "grad";
            this.bindingSource2.DataSource = this.bolnicaDataSet1;
            // 
            // gradTableAdapter
            // 
            this.gradTableAdapter.ClearBeforeFill = true;
            // 
            // BolnicaNewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 339);
            this.Controls.Add(this.odustaniBTN);
            this.Controls.Add(this.prihvatiBTN);
            this.Controls.Add(this.ucitajSlikuBTN);
            this.Controls.Add(this.dezurna);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.radnoVrijemeTB);
            this.Controls.Add(this.slikaPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.opisTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adresaTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nazivTB);
            this.Controls.Add(this.panel1);
            this.Name = "BolnicaNewEdit";
            this.Text = "Nova bolnica";
            this.Load += new System.EventHandler(this.BolnicaNewEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bolnicaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nazivTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adresaTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox opisTB;
        private System.Windows.Forms.Panel slikaPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox radnoVrijemeTB;
        private System.Windows.Forms.CheckBox dezurna;
        private System.Windows.Forms.Button ucitajSlikuBTN;
        private System.Windows.Forms.Button prihvatiBTN;
        private System.Windows.Forms.Button odustaniBTN;
        private System.Windows.Forms.BindingSource bindingSource1;
        private bolnicaDataSet1 bolnicaDataSet1;
        private bolnicaDataSet1TableAdapters.bolnicaTableAdapter bolnicaTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource2;
        private bolnicaDataSet1TableAdapters.gradTableAdapter gradTableAdapter;
    }
}