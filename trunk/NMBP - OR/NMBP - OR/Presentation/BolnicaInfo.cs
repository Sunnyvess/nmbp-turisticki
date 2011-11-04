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

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";
        NpgsqlConnection conn = new NpgsqlConnection (connString);
        DataSet da = new DataSet ();
        BindingSource bolnicaBinding;
        BindingSource gradBinding;
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
        private void BolnicaInfo_Load(object sender, EventArgs e)
        {
            string sqlBolnica = "SELECT * FROM bolnica";
            string sqlGrad = "SELECT * FROM grad";
            try
            {
                conn.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                da.Reset();
                adapter.SelectCommand = new NpgsqlCommand(sqlBolnica, conn);
                adapter.Fill(da, "bolnica");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill(da, "grad");
                conn.Close();
                bolnicaBinding = new BindingSource(da, "bolnica");
                gradBinding = new BindingSource(da, "grad");
                bolnicaBinding.Position = bolnicaBinding.Find("sifra", Sifra);
                BindData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void BindData()
        {
            nameLabel.DataBindings.Add("Text",bolnicaBinding, "naziv");
            adresaLabel.Text = getAdresa();
            radnoVrijemeLabel.DataBindings.Add("Text", bolnicaBinding, "radnovrijeme");
            opisLabel.DataBindings.Add("Text",bolnicaBinding, "opis");
            string dezurstvo = Convert.ToString(da.Tables[0].Rows[bolnicaBinding.Find("sifra", Sifra)][6]);
            
            if (dezurstvo == "True")
                dezurstvoLabel.Text = "DA";
            else
                dezurstvoLabel.Text = "NE";
        }
        private string getAdresa()
        {
            string adresa = da.Tables[0].Rows[bolnicaBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);
            string grad = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["ime"].ToString();
            return adress[0] + " " + adress[1] + ", " + adress[2] + " " + grad;
        }
    }
}
