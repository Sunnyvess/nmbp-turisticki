using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using turistickiXML.Business;

namespace turistickiXML.Presentation {
    public partial class BolnicaNewEdit : Form {
        private Bolnica bolnica = new Bolnica ();
        GradList gradlist = new GradList ();
        DataTable grad = new DataTable();
        private int sifra;
        private bool isNew;

        public BolnicaNewEdit (string pbr) {
            InitializeComponent ();
            this.Text = "Nova bolnica";
            this.StartPosition = FormStartPosition.CenterScreen;
            isNew = true;
            grad = gradlist.GetGradList();
            FillGradCB ();
            gradComboBox.SelectedValue = int.Parse(pbr);
        }
        public BolnicaNewEdit (int sifra) {
            InitializeComponent ();
            this.Text = "Izmjena bolnice";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sifra = sifra;
            isNew = false;
            grad = gradlist.GetGradList();
            FillGradCB ();
            bolnica = BolnicaLokacija.SelectBolnica (sifra);
            BindData ();
        }

        private void FillGradCB () {
            
            this.gradComboBox.Items.Clear ();
            this.gradComboBox.DataSource = grad;
            this.gradComboBox.DisplayMember = "naziv";
            this.gradComboBox.ValueMember = "pbr";
            this.gradComboBox.SelectedIndex = 0;
        }

        private void BindData () {
            this.nazivTB.Text = bolnica.Naziv;
            this.ulicaTB.Text = bolnica.Ulica;
            this.opisTB.Text = bolnica.Opis;
            this.radnoVrijemeTB.Text = bolnica.RadnoVrijeme;
            dezurna.Checked = bolnica.Dezurna;
            gradComboBox.SelectedValue = bolnica.PostBr;
        }

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            bolnica.Naziv = nazivTB.Text;
            bolnica.Ulica = ulicaTB.Text;
            bolnica.Opis = opisTB.Text;
            bolnica.RadnoVrijeme = radnoVrijemeTB.Text;
            bolnica.PostBr = Convert.ToInt32 (gradComboBox.SelectedValue);
            bolnica.Dezurna = dezurna.Checked;
            if (isNew) {
                BolnicaLokacija.InsertNew (bolnica);
            }
            else if (!isNew)
                BolnicaLokacija.Update (bolnica);
            this.Close ();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
            this.Close ();
        }

        private void nazivTB_Validating(object sender, CancelEventArgs e)
        {
            if (nazivTB.Text.Trim() == String.Empty)
            {
                prihvatiBTN.Enabled = false;
                errorProvider1.SetError(nazivTB, "Unesite naziv!");
            }
            else
            {
                prihvatiBTN.Enabled = true;
                errorProvider1.Clear();
            }
        }

        private void ulicaTB_Validating(object sender, CancelEventArgs e)
        {
            if (ulicaTB.Text.Trim() == String.Empty)
            {
                prihvatiBTN.Enabled = false;
                errorProvider2.SetError(ulicaTB, "Unesite adresu!");
            }
            else
            {
                prihvatiBTN.Enabled = true;
                errorProvider2.Clear();
            }
        }
    }
}
