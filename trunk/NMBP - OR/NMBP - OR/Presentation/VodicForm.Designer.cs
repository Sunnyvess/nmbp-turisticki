namespace NMBP___OR.Presentation
{
    partial class VodicForm
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
            this.components = new System.ComponentModel.Container();
            this.masterLista = new System.Windows.Forms.ListBox();
            this.gradoviComboBox = new System.Windows.Forms.ComboBox();
            this.gradBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oRDDataSet = new NMBP___OR.ORDDataSet();
            this.lokacijaComboBox = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.deleteBTN = new System.Windows.Forms.Button();
            this.editBTN = new System.Windows.Forms.Button();
            this.addBTN = new System.Windows.Forms.Button();
            this.gradTableAdapter = new NMBP___OR.ORDDataSetTableAdapters.gradTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gradBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oRDDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // masterLista
            // 
            this.masterLista.BackColor = System.Drawing.Color.LightGray;
            this.masterLista.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.masterLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.masterLista.FormattingEnabled = true;
            this.masterLista.ItemHeight = 18;
            this.masterLista.Location = new System.Drawing.Point(12, 63);
            this.masterLista.Name = "masterLista";
            this.masterLista.Size = new System.Drawing.Size(318, 274);
            this.masterLista.TabIndex = 2;
            this.masterLista.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.masterLista_MouseDoubleClick);
            // 
            // gradoviComboBox
            // 
            this.gradoviComboBox.DataSource = this.gradBindingSource;
            this.gradoviComboBox.DisplayMember = "ime";
            this.gradoviComboBox.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gradoviComboBox.FormattingEnabled = true;
            this.gradoviComboBox.Location = new System.Drawing.Point(12, 12);
            this.gradoviComboBox.Name = "gradoviComboBox";
            this.gradoviComboBox.Size = new System.Drawing.Size(161, 31);
            this.gradoviComboBox.TabIndex = 0;
            this.gradoviComboBox.ValueMember = "postanskibroj";
            this.gradoviComboBox.SelectedIndexChanged += new System.EventHandler(this.gradoviComboBox_SelectedIndexChanged);
            // 
            // gradBindingSource
            // 
            this.gradBindingSource.DataMember = "grad";
            this.gradBindingSource.DataSource = this.oRDDataSet;
            // 
            // oRDDataSet
            // 
            this.oRDDataSet.DataSetName = "ORDDataSet";
            this.oRDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lokacijaComboBox
            // 
            this.lokacijaComboBox.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lokacijaComboBox.FormattingEnabled = true;
            this.lokacijaComboBox.Items.AddRange(new object[] {
            "Muzej",
            "Bolnica",
            "Znamenitost",
            "Park"});
            this.lokacijaComboBox.Location = new System.Drawing.Point(179, 12);
            this.lokacijaComboBox.Name = "lokacijaComboBox";
            this.lokacijaComboBox.Size = new System.Drawing.Size(151, 31);
            this.lokacijaComboBox.TabIndex = 1;
            this.lokacijaComboBox.SelectedIndexChanged += new System.EventHandler(this.lokacijaComboBox_SelectedIndexChanged);
            // 
            // deleteBTN
            // 
            this.deleteBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.delete;
            this.deleteBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteBTN.Location = new System.Drawing.Point(295, 359);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(35, 35);
            this.deleteBTN.TabIndex = 5;
            this.toolTip1.SetToolTip(this.deleteBTN, "Obriši odabrano");
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // editBTN
            // 
            this.editBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.edit;
            this.editBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBTN.Location = new System.Drawing.Point(254, 359);
            this.editBTN.Name = "editBTN";
            this.editBTN.Size = new System.Drawing.Size(35, 35);
            this.editBTN.TabIndex = 4;
            this.toolTip1.SetToolTip(this.editBTN, "Izmijeni odabrano");
            this.editBTN.UseVisualStyleBackColor = true;
            this.editBTN.Click += new System.EventHandler(this.editBTN_Click);
            // 
            // addBTN
            // 
            this.addBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.add;
            this.addBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addBTN.Location = new System.Drawing.Point(12, 359);
            this.addBTN.Name = "addBTN";
            this.addBTN.Size = new System.Drawing.Size(35, 35);
            this.addBTN.TabIndex = 3;
            this.toolTip1.SetToolTip(this.addBTN, "Dodaj novi unos");
            this.addBTN.UseVisualStyleBackColor = true;
            this.addBTN.Click += new System.EventHandler(this.addBTN_Click);
            // 
            // gradTableAdapter
            // 
            this.gradTableAdapter.ClearBeforeFill = true;
            // 
            // VodicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 414);
            this.Controls.Add(this.deleteBTN);
            this.Controls.Add(this.editBTN);
            this.Controls.Add(this.addBTN);
            this.Controls.Add(this.lokacijaComboBox);
            this.Controls.Add(this.gradoviComboBox);
            this.Controls.Add(this.masterLista);
            this.Name = "VodicForm";
            this.Text = "Turistički vodič";
            this.Load += new System.EventHandler(this.VodicForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gradBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oRDDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox masterLista;
        private System.Windows.Forms.ComboBox gradoviComboBox;
        private System.Windows.Forms.ComboBox lokacijaComboBox;
        private System.Windows.Forms.Button addBTN;
        private System.Windows.Forms.Button editBTN;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource gradBindingSource;
        private ORDDataSet oRDDataSet;
        private ORDDataSetTableAdapters.gradTableAdapter gradTableAdapter;

    }
}

