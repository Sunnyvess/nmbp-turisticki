using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Bussines;

namespace turistickiXML.Presentation
{
    public partial class ZnamenitostNewEdit : Form
    {
        private  Znamenitost znam = new Znamenitost ();
        GradList gradlist = new GradList ();
        DataTable grad = new DataTable();
        private int sifra;
        private bool isNew;

        public ZnamenitostNewEdit (string pbr) {
            InitializeComponent ();
            this.Text = "Nova znamenitost";
            this.StartPosition = FormStartPosition.CenterScreen;
            isNew = true;
            grad = gradlist.GetGradList();
            FillGradCB ();
            tipZnamenCB.SelectedIndex = 0;
            gradComboBox.SelectedValue = int.Parse(pbr);
        }
        public ZnamenitostNewEdit (int sifra) {
            InitializeComponent ();
            this.Text = "Izmjena znamenitosti";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sifra = sifra;
            isNew = false;
            grad = gradlist.GetGradList();
            FillGradCB ();
            znam = ZnamenitostLokacija.SelectZnamenitost (sifra);
            BindData ();
        }

        private void FillGradCB () {
            
            this.gradComboBox.Items.Clear ();
            this.gradComboBox.DataSource = grad;
            this.gradComboBox.DisplayMember = "nazivGrad";
            this.gradComboBox.ValueMember = "pbr";
            this.gradComboBox.SelectedIndex = 0;
        }

        private void BindData () {
            this.nazivTB.Text = znam.Naziv;
            this.ulicaTB.Text = znam.Ulica;
            this.opisTB.Text = znam.Opis;
            this.radnoVrijemeTB.Text = znam.RadnoVrijeme;
            tipZnamenCB.SelectedItem = znam.TipZnamenitosti;
            datumIzgradnje.Value = Convert.ToDateTime(znam.godinaIzgradnje).Date;
            gradComboBox.SelectedValue = znam.PostBr;
        }

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            znam.Naziv = nazivTB.Text;
            znam.Ulica = ulicaTB.Text;
            znam.Opis = opisTB.Text;
            znam.RadnoVrijeme = radnoVrijemeTB.Text;
            znam.PostBr = Convert.ToInt32 (gradComboBox.SelectedValue);
            znam.TipZnamenitosti = tipZnamenCB.SelectedItem.ToString();
            znam.godinaIzgradnje = datumIzgradnje.Value.ToString("yyyy-MM-dd");
            if (isNew) {
                ZnamenitostLokacija.InsertNew (znam);
            }
            else if (!isNew)
                ZnamenitostLokacija.Update (znam);
            this.Close ();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
            this.Close ();
        }
    }
}
