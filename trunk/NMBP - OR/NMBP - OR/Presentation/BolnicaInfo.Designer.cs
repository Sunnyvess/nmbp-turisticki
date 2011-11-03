namespace NMBP___OR.Presentation {
    partial class BolnicaInfo {
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.adresaLabel = new System.Windows.Forms.Label();
            this.opisLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radnoVrijemeLabel = new System.Windows.Forms.Label();
            this.dezurstvoLabel = new System.Windows.Forms.Label();
            this.slikaPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
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
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(12, 12);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(204, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Klinika za traumatologiju";
            // 
            // adresaLabel
            // 
            this.adresaLabel.AutoSize = true;
            this.adresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.adresaLabel.Location = new System.Drawing.Point(12, 42);
            this.adresaLabel.Name = "adresaLabel";
            this.adresaLabel.Size = new System.Drawing.Size(159, 16);
            this.adresaLabel.TabIndex = 2;
            this.adresaLabel.Text = "Draškovićeva 19, Zagreb";
            // 
            // opisLabel
            // 
            this.opisLabel.AutoSize = true;
            this.opisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.opisLabel.Location = new System.Drawing.Point(158, 85);
            this.opisLabel.Name = "opisLabel";
            this.opisLabel.Size = new System.Drawing.Size(127, 15);
            this.opisLabel.TabIndex = 3;
            this.opisLabel.Text = "Ovdje ide opis bolnice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Radno vrijeme:";
            // 
            // radnoVrijemeLabel
            // 
            this.radnoVrijemeLabel.AutoSize = true;
            this.radnoVrijemeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radnoVrijemeLabel.Location = new System.Drawing.Point(12, 255);
            this.radnoVrijemeLabel.Name = "radnoVrijemeLabel";
            this.radnoVrijemeLabel.Size = new System.Drawing.Size(93, 16);
            this.radnoVrijemeLabel.TabIndex = 5;
            this.radnoVrijemeLabel.Text = "09:30 - 21:00";
            // 
            // dezurstvoLabel
            // 
            this.dezurstvoLabel.AutoSize = true;
            this.dezurstvoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dezurstvoLabel.Location = new System.Drawing.Point(378, 255);
            this.dezurstvoLabel.Name = "dezurstvoLabel";
            this.dezurstvoLabel.Size = new System.Drawing.Size(29, 16);
            this.dezurstvoLabel.TabIndex = 6;
            this.dezurstvoLabel.Text = "DA";
            // 
            // slikaPanel
            // 
            this.slikaPanel.Location = new System.Drawing.Point(12, 85);
            this.slikaPanel.Name = "slikaPanel";
            this.slikaPanel.Size = new System.Drawing.Size(140, 119);
            this.slikaPanel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(311, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dežurna:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::NMBP___OR.Properties.Resources.info;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(357, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(50, 50);
            this.panel1.TabIndex = 0;
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
            // BolnicaInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 279);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.slikaPanel);
            this.Controls.Add(this.dezurstvoLabel);
            this.Controls.Add(this.radnoVrijemeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opisLabel);
            this.Controls.Add(this.adresaLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.panel1);
            this.Name = "BolnicaInfo";
            this.Text = "Informacije o bolnici";
            this.Load += new System.EventHandler(this.BolnicaInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bolnicaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label adresaLabel;
        private System.Windows.Forms.Label opisLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label radnoVrijemeLabel;
        private System.Windows.Forms.Label dezurstvoLabel;
        private System.Windows.Forms.Panel slikaPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private bolnicaDataSet1 bolnicaDataSet1;
        private bolnicaDataSet1TableAdapters.bolnicaTableAdapter bolnicaTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource2;
        private bolnicaDataSet1TableAdapters.gradTableAdapter gradTableAdapter;
    }
}