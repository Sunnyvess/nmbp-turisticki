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
    public partial class BolnicaInfo : Form
    {
        private int sifra;
        private Bolnica bolnica = new Bolnica();
        public BolnicaInfo(int sifra)
        {
            InitializeComponent();
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        private void BindData () {
           nameLabel.Text = bolnica.Naziv;
           adresaLabel.Text = bolnica.Ulica;          
           radnoVrijemeLabel.Text = bolnica.RadnoVrijeme;
           opisLabel.Text =  bolnica.Opis;
           if (bolnica.Dezurna)
               dezurstvoLabel.Text = "DA";
           else
               dezurstvoLabel.Text = "NE";
        }

        private void BolnicaInfo_Load(object sender, EventArgs e)
        {
            bolnica = BolnicaLokacija.SelectBolnica(sifra);
            BindData();
        }
    }
}
