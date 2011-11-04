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
    public partial class ZnamenitostInfo : Form {
        private int Sifra;
        public ZnamenitostInfo () {
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
        BindingSource znamenitostBinding;
        BindingSource gradBinding;
        private void ZnamenitostInfo_Load(object sender, EventArgs e)
        {
            string sqlZnamenitost = "SELECT * FROM znamenitost";
            string sqlGrad = "SELECT * FROM grad";
            try
            {
                conn.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                da.Reset();
                adapter.SelectCommand = new NpgsqlCommand(sqlZnamenitost, conn);
                adapter.Fill(da, "znamenitost");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill(da, "grad");
                conn.Close();
                znamenitostBinding = new BindingSource(da, "znamenitost");
                gradBinding = new BindingSource(da, "grad");
                znamenitostBinding.Position = znamenitostBinding.Find("sifra", Sifra);
                BindData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindData()
        {
            nameLabel.DataBindings.Add("Text", znamenitostBinding, "naziv");
            adresaLabel.Text = getAdresa();
            radnoVrijemeLabel.DataBindings.Add("Text", znamenitostBinding, "radnovrijeme");
            opisLabel.DataBindings.Add("Text", znamenitostBinding, "opis");
            DateTime datum = DateTime.Parse(da.Tables[0].Rows[znamenitostBinding.Find("sifra", sifra)]["datumizgradnje"].ToString());
            datumizgradnjeLB.Text = datum.ToShortDateString().ToString();
            tipZnamenLabel.DataBindings.Add("Text", znamenitostBinding, "tipznamenitosti");
        }
        private string getAdresa()
        {
            string adresa = da.Tables[0].Rows[znamenitostBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);
            string grad = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["ime"].ToString();
            return adress[0] + " " + adress[1] + ", " + adress[2] + " " + grad;
        }

    }
}
