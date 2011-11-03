using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace NMBP___OR.Presentation {
    public partial class MuzejInfo : Form {
        private int Sifra;
        public MuzejInfo () {
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public int sifra
        {
            get { return Sifra; }
            set { Sifra = value; }
        }

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet da = new DataSet();
        private void MuzejInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'muzejDataSet1.grad' table. You can move, or remove it, as needed.
            this.gradTableAdapter.Fill(this.muzejDataSet1.grad);
            // TODO: This line of code loads data into the 'muzejDataSet1.muzej' table. You can move, or remove it, as needed.
            this.muzejTableAdapter.Fill(this.muzejDataSet1.muzej);

            bindingSourceMuzej.Position = bindingSourceMuzej.Find("sifra", Sifra);
            BindData();
            

        }
        private void BindData()
        {
            nameLabel.DataBindings.Add("Text", bindingSourceMuzej, "naziv");

            adresaLabel.Text = getAdresa();
            radnoVrijemeLabel.DataBindings.Add("Text", bindingSourceMuzej, "radnovrijeme");
            opisLabel.DataBindings.Add("Text", bindingSourceMuzej, "opis");
            
        }
        private string getAdresa()
        {
            string adresa = muzejDataSet1.Tables[0].Rows[bindingSourceMuzej.Find("sifra", Sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string ulica = adresa.Substring(0, adresa.IndexOf(","));
            int pbr = Convert.ToInt32(adresa.Substring(adresa.IndexOf(",") + 1));
            string grad = muzejDataSet1.Tables[1].Rows[bindingSourceGrad.Find("postanskibroj", pbr)]["ime"].ToString();
            return adresa + " " + grad;
        }

    }



}
