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
    public partial class ZnamenitostInfo : Form
    {
        private int sifra;
        private Znamenitost znam = new Znamenitost();
        public ZnamenitostInfo(int sifra)
        {
            InitializeComponent();
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        private void BindData () {
           nameLabel.Text = znam.Naziv;
           adresaLabel.Text = znam.Ulica;          
           radnoVrijemeLabel.Text = znam.RadnoVrijeme;
           opisLabel.Text =  znam.Opis;
           datumizgradnjeLB.Text = znam.godinaIzgradnje;
           tipZnamenLabel.Text = znam.TipZnamenitosti;
        }

        private void ZnamenitostInfo_Load(object sender, EventArgs e)
        {
            znam = ZnamenitostLokacija.SelectZnamenitost(sifra);
            BindData();
        }
    }
}
