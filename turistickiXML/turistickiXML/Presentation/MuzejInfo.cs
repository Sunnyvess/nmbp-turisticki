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
    public partial class MuzejInfo : Form
    {
        private int sifra;
        private Muzej muzej = new Muzej();
        public MuzejInfo(int sifra)
        {
            InitializeComponent();
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        private void BindData () {
           nameLabel.Text = muzej.Naziv;
           adresaLabel.Text = muzej.Ulica;          
           radnoVrijemeLabel.Text = muzej.RadnoVrijeme;
           opisLabel.Text =  muzej.Opis;
           tipMuzejaLabel.Text = muzej.Tip;
        }

        private void MuzejInfo_Load(object sender, EventArgs e)
        {
            muzej = MuzejLokacija.SelectMuzej(sifra);
            BindData();
        }
    }
}
