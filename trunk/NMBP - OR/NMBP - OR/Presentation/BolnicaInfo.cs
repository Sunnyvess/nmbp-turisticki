using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.IO;

namespace NMBP___OR.Presentation {
    public partial class BolnicaInfo : Form {
        private int Sifra;
        private int indeksSlike = 1;
        private int brojSlika = 0;

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
        BindingSource bolnicaBinding;
        BindingSource gradBinding;
        private void BolnicaInfo_Load(object sender, EventArgs e)
        {
            string sqlBolnica = "SELECT naziv, adresa, opis, radnovrijeme, sifra, dezurstvo FROM bolnica";
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
            if(getBrojSlika()!=0) bolnicaPB.Image = getSlika(indeksSlike);                        
            radnoVrijemeLabel.DataBindings.Add("Text", bolnicaBinding, "radnovrijeme");
            opisLabel.DataBindings.Add("Text",bolnicaBinding, "opis");
            string dezurstvo = Convert.ToString(da.Tables[0].Rows[bolnicaBinding.Find("sifra", Sifra)][5]);
            
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

        private int getBrojSlika()
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT array_length(slika, 1) AS brojSlika FROM bolnica where sifra = " + sifra, conn);
            object brojSlika1 = command.ExecuteScalar();
            conn.Close();

            return (brojSlika1 is int) ? (Int32)brojSlika1 : 0;
        }

        private Image getSlika(int indeks)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT slika[" + indeks + "].slika FROM bolnica where sifra = " +  sifra, conn);
            object result = command.ExecuteScalar();
            conn.Close();

            Image image;
            if (result is byte[])
            {
                byte[] slika = (byte[])result;
                using (MemoryStream ms = new MemoryStream(slika, 0, slika.Length))
                {
                    ms.Write(slika, 0, slika.Length);
                    image = Image.FromStream(ms, true);
                }

                return image;
            }
            else return null;
        }

        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            if (getBrojSlika() != 0)
            {
                if (indeksSlike == getBrojSlika()) indeksSlike = 1;
                else indeksSlike++;
                bolnicaPB.Image = getSlika(indeksSlike);
            }

        }

        private void previousPictureButton_Click(object sender, EventArgs e)
        {
            if (getBrojSlika() != 0)
            {
                if (indeksSlike == 1) indeksSlike = getBrojSlika();
                else indeksSlike--;
                bolnicaPB.Image = getSlika(indeksSlike);
            }
        }
    }
}
