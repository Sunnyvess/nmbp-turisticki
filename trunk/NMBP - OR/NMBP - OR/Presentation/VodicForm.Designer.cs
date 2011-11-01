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
            this.components = new System.ComponentModel.Container ();
            this.masterLista = new System.Windows.Forms.ListBox ();
            this.gradoviComboBox = new System.Windows.Forms.ComboBox ();
            this.lokacijaComboBox = new System.Windows.Forms.ComboBox ();
            this.toolTip1 = new System.Windows.Forms.ToolTip (this.components);
            this.deleteBTN = new System.Windows.Forms.Button ();
            this.editBTN = new System.Windows.Forms.Button ();
            this.addBTN = new System.Windows.Forms.Button ();
            this.SuspendLayout ();
            // 
            // masterLista
            // 
            this.masterLista.BackColor = System.Drawing.Color.Black;
            this.masterLista.ForeColor = System.Drawing.Color.White;
            this.masterLista.FormattingEnabled = true;
            this.masterLista.Location = new System.Drawing.Point (12, 63);
            this.masterLista.Name = "masterLista";
            this.masterLista.Size = new System.Drawing.Size (318, 290);
            this.masterLista.TabIndex = 0;
            this.masterLista.SelectedIndexChanged += new System.EventHandler (this.masterLista_SelectedIndexChanged);
            // 
            // gradoviComboBox
            // 
            this.gradoviComboBox.Font = new System.Drawing.Font ("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.gradoviComboBox.FormattingEnabled = true;
            this.gradoviComboBox.Location = new System.Drawing.Point (12, 12);
            this.gradoviComboBox.Name = "gradoviComboBox";
            this.gradoviComboBox.Size = new System.Drawing.Size (161, 32);
            this.gradoviComboBox.TabIndex = 1;
            // 
            // lokacijaComboBox
            // 
            this.lokacijaComboBox.Font = new System.Drawing.Font ("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.lokacijaComboBox.FormattingEnabled = true;
            this.lokacijaComboBox.Location = new System.Drawing.Point (179, 16);
            this.lokacijaComboBox.Name = "lokacijaComboBox";
            this.lokacijaComboBox.Size = new System.Drawing.Size (151, 28);
            this.lokacijaComboBox.TabIndex = 2;
            // 
            // deleteBTN
            // 
            this.deleteBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.delete;
            this.deleteBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteBTN.Location = new System.Drawing.Point (295, 359);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size (35, 35);
            this.deleteBTN.TabIndex = 5;
            this.toolTip1.SetToolTip (this.deleteBTN, "Obriši odabrano");
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler (this.deleteBTN_Click);
            // 
            // editBTN
            // 
            this.editBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.edit;
            this.editBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editBTN.Location = new System.Drawing.Point (254, 359);
            this.editBTN.Name = "editBTN";
            this.editBTN.Size = new System.Drawing.Size (35, 35);
            this.editBTN.TabIndex = 4;
            this.toolTip1.SetToolTip (this.editBTN, "Izmijeni odabrano");
            this.editBTN.UseVisualStyleBackColor = true;
            this.editBTN.Click += new System.EventHandler (this.editBTN_Click);
            // 
            // addBTN
            // 
            this.addBTN.BackgroundImage = global::NMBP___OR.Properties.Resources.add;
            this.addBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addBTN.Location = new System.Drawing.Point (12, 359);
            this.addBTN.Name = "addBTN";
            this.addBTN.Size = new System.Drawing.Size (35, 35);
            this.addBTN.TabIndex = 3;
            this.toolTip1.SetToolTip (this.addBTN, "Dodaj novi unos");
            this.addBTN.UseVisualStyleBackColor = true;
            this.addBTN.Click += new System.EventHandler (this.addBTN_Click);
            // 
            // VodicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (342, 403);
            this.Controls.Add (this.deleteBTN);
            this.Controls.Add (this.editBTN);
            this.Controls.Add (this.addBTN);
            this.Controls.Add (this.lokacijaComboBox);
            this.Controls.Add (this.gradoviComboBox);
            this.Controls.Add (this.masterLista);
            this.Name = "VodicForm";
            this.Text = "Turistički vodič";
            this.ResumeLayout (false);

        }

        #endregion

        private System.Windows.Forms.ListBox masterLista;
        private System.Windows.Forms.ComboBox gradoviComboBox;
        private System.Windows.Forms.ComboBox lokacijaComboBox;
        private System.Windows.Forms.Button addBTN;
        private System.Windows.Forms.Button editBTN;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

