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
    public partial class BolnicaInfo : Form {
        private int Sifra;
        public BolnicaInfo () {
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
        private void BolnicaInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bolnicaDataSet1.grad' table. You can move, or remove it, as needed.
            this.gradTableAdapter.Fill(this.bolnicaDataSet1.grad);
            // TODO: This line of code loads data into the 'bolnicaDataSet1.bolnica' table. You can move, or remove it, as needed.
            this.bolnicaTableAdapter.Fill(this.bolnicaDataSet1.bolnica);
           /*
                string sql = "SELECT * FROM bolnica" + " WHERE sifra=" + Sifra.ToString(); ;

                NpgsqlDataAdapter bolnicaData = new NpgsqlDataAdapter(sql, conn);
                da.Reset();
                bolnicaData.Fill(da);*/
                bindingSource1.Position = bindingSource1.Find("sifra",Sifra);
                BindData();
                //conn.Close();
            
        }
        private void BindData()
        {
            nameLabel.DataBindings.Add("Text",bindingSource1, "naziv");

            adresaLabel.Text = getAdresa();
            radnoVrijemeLabel.DataBindings.Add("Text", bindingSource1, "radnovrijeme");
            opisLabel.DataBindings.Add("Text",bindingSource1, "opis");
            string dezurstvo = Convert.ToString(bolnicaDataSet1.Tables[0].Rows[bindingSource1.Find("sifra",Sifra)][6]);
           
            if (dezurstvo == "1")
                dezurstvoLabel.Text = "DA";
            else
                dezurstvoLabel.Text = "NE";
        }
        private string getAdresa()
        {
            string adresa = bolnicaDataSet1.Tables[0].Rows[bindingSource1.Find("sifra", Sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string ulica = adresa.Substring(0, adresa.IndexOf(","));
            int pbr = Convert.ToInt32(adresa.Substring(adresa.IndexOf(",") + 1));
            string grad = bolnicaDataSet1.Tables[1].Rows[bindingSource2.Find("postanskibroj", pbr)]["ime"].ToString();
            return adresa + " " + grad;
        }
    }
}
