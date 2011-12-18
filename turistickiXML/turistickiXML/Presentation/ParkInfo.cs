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
    public partial class ParkInfo : Form
    {
        private int sifra;
        private Park park = new Park();
        public ParkInfo(int sifra)
        {
            InitializeComponent();
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        private void BindData () {
           nameLabel.Text = park.Naziv;
           adresaLabel.Text = park.Ulica;          
           radnoVrijemeLabel.Text = park.RadnoVrijeme;
           opisLabel.Text =  park.Opis;
           if (park.Otvoren)
               otvorenLabel.Text = "DA";
           else
               otvorenLabel.Text = "NE";
        }

        private void ParkInfo_Load(object sender, EventArgs e)
        {
            park = ParkLokacija.SelectPark(sifra);
            BindData();
        }
    }
}
