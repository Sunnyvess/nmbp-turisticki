using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Business;

namespace turistickiXML.Presentation
{
    public partial class ParkNewEdit : Form
    {
        private  Park park = new Park ();
        GradList gradlist = new GradList ();
        DataTable grad = new DataTable();
        private int sifra;
        private bool isNew;

        public ParkNewEdit (string pbr) {
            InitializeComponent ();
            this.Text = "Novi park";
            this.StartPosition = FormStartPosition.CenterScreen;
            isNew = true;
            grad = gradlist.GetGradList();
            FillGradCB ();
            gradComboBox.SelectedValue = int.Parse(pbr);
        }
        public ParkNewEdit (int sifra) {
            InitializeComponent ();
            this.Text = "Izmjena parka";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sifra = sifra;
            isNew = false;
            grad = gradlist.GetGradList();
            FillGradCB ();
            park = ParkLokacija.SelectPark (sifra);
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
            this.nazivTB.Text = park.Naziv;
            this.ulicaTB.Text = park.Ulica;
            this.opisTB.Text = park.Opis;
            this.radnoVrijemeTB.Text = park.RadnoVrijeme;
            otvoren.Checked = park.Otvoren;
            gradComboBox.SelectedValue = park.PostBr;
        }

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            park.Naziv = nazivTB.Text;
            park.Ulica = ulicaTB.Text;
            park.Opis = opisTB.Text;
            park.RadnoVrijeme = radnoVrijemeTB.Text;
            park.PostBr = Convert.ToInt32 (gradComboBox.SelectedValue);
            park.Otvoren = otvoren.Checked;
            if (isNew) {
                ParkLokacija.InsertNew (park);
            }
            else if (!isNew)
                ParkLokacija.Update (park);
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
