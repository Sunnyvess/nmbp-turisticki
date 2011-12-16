namespace turistickiXML.Presentation
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
            this.gradoviComboBox = new System.Windows.Forms.ComboBox();
            this.lokacijaComboBox = new System.Windows.Forms.ComboBox();
            this.masterLista = new System.Windows.Forms.ListBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gradoviComboBox
            // 
            this.gradoviComboBox.DisplayMember = "postanskibroj";
            this.gradoviComboBox.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gradoviComboBox.FormattingEnabled = true;
            this.gradoviComboBox.Location = new System.Drawing.Point(12, 12);
            this.gradoviComboBox.Name = "gradoviComboBox";
            this.gradoviComboBox.Size = new System.Drawing.Size(161, 31);
            this.gradoviComboBox.TabIndex = 1;
            this.gradoviComboBox.ValueMember = "postanskibroj";
            this.gradoviComboBox.SelectedIndexChanged += new System.EventHandler(this.gradoviComboBox_SelectedIndexChanged);
            // 
            // lokacijaComboBox
            // 
            this.lokacijaComboBox.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lokacijaComboBox.FormattingEnabled = true;
            this.lokacijaComboBox.Items.AddRange(new object[] {
            "Bolnica",
            "Muzej",
            "Park",
            "Znamenitost"});
            this.lokacijaComboBox.Location = new System.Drawing.Point(187, 12);
            this.lokacijaComboBox.MaximumSize = new System.Drawing.Size(151, 0);
            this.lokacijaComboBox.Name = "lokacijaComboBox";
            this.lokacijaComboBox.Size = new System.Drawing.Size(151, 31);
            this.lokacijaComboBox.TabIndex = 2;
            // 
            // masterLista
            // 
            this.masterLista.BackColor = System.Drawing.SystemColors.Window;
            this.masterLista.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.masterLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.masterLista.FormattingEnabled = true;
            this.masterLista.ItemHeight = 18;
            this.masterLista.Location = new System.Drawing.Point(16, 70);
            this.masterLista.Name = "masterLista";
            this.masterLista.Size = new System.Drawing.Size(318, 274);
            this.masterLista.TabIndex = 3;
            // 
            // buttonNew
            // 
            this.buttonNew.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonNew.Location = new System.Drawing.Point(16, 367);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(35, 35);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(258, 367);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(35, 35);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(299, 367);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 35);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // VodicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 414);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.masterLista);
            this.Controls.Add(this.lokacijaComboBox);
            this.Controls.Add(this.gradoviComboBox);
            this.Name = "VodicForm";
            this.Text = "Turistički vodič";
            this.Load += new System.EventHandler(this.VodicForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox gradoviComboBox;
        private System.Windows.Forms.ComboBox lokacijaComboBox;
        private System.Windows.Forms.ListBox masterLista;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}