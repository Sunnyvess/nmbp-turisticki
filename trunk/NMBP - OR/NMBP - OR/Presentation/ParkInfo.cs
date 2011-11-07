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
    public partial class ParkInfo : Form {
        private string type = "park";
        static string connString = DatabaseManager.connString;

        NpgsqlConnection conn = new NpgsqlConnection (connString);
        DataSet da = new DataSet ();
        BindingSource parkBinding;
        BindingSource gradBinding;

        private int sifra;
        private int indeksSlike = 1;
        Slika slika = new Slika ();
        private int BrojSlika = 0;

        public ParkInfo (int sifra) {
            InitializeComponent ();
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ParkInfo_Load (object sender, EventArgs e) {
            string sqlPark = "SELECT * FROM park";
            string sqlGrad = "SELECT * FROM grad";
            try {
                conn.Open ();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter ();
                da.Reset ();
                adapter.SelectCommand = new NpgsqlCommand (sqlPark, conn);
                adapter.Fill (da, "park");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill (da, "grad");
                conn.Close ();
                parkBinding = new BindingSource (da, "park");
                gradBinding = new BindingSource (da, "grad");
                parkBinding.Position = parkBinding.Find ("sifra", sifra);
                BindData ();

            }
            catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }

        }
        private void BindData () {
            nameLabel.DataBindings.Add ("Text", parkBinding, "naziv");
            adresaLabel.Text = getAdresa ();
            if (slika.getBrojSlika (type, sifra) != 0) parkPB.Image = slika.getSlika (type, indeksSlike, sifra);
            radnoVrijemeLabel.DataBindings.Add ("Text", parkBinding, "radnovrijeme");
            opisLabel.DataBindings.Add ("Text", parkBinding, "opis");
            string otvoren = Convert.ToString (da.Tables[0].Rows[parkBinding.Find ("sifra", sifra)][6]);

            if (otvoren == "True")
                otvorenLabel.Text = "DA";
            else
                otvorenLabel.Text = "NE";
            for (int i = 1 ; i <= 3 ; i++) {
                if (slika.getSlikaBytes (type, i, sifra) != null)
                    BrojSlika++;
            }

        }
        private string getAdresa () {
            string adresa = da.Tables[0].Rows[parkBinding.Find ("sifra", sifra)]["adresa"].ToString ();
            adresa = adresa.Substring (1, adresa.IndexOf (")") - 1);
            string[] adress = adresa.Split (',');
            adress[0] = adress[0].Replace ("\"", "");
            int pbr = Convert.ToInt32 (adress[2]);
            string grad = da.Tables[1].Rows[gradBinding.Find ("postanskibroj", pbr)]["ime"].ToString ();
            return adress[0] + " " + adress[1] + ", " + adress[2] + " " + grad;
        }

        private void nextPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;
            if (brojSlika != 0) {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                parkPB.Image = slika.getSlika (type, indeksSlike, sifra);
            }
        }
        private void previousPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;
            if (brojSlika != 0) {
                if (indeksSlike == 1) indeksSlike = brojSlika;
                else indeksSlike--;
                parkPB.Image = slika.getSlika (type, indeksSlike, sifra);
            }
        }
        private void parkPB_DoubleClick (object sender, EventArgs e) {
            if (BrojSlika != 0) {
                SlikaForm slikaForm = new SlikaForm (type, sifra, BrojSlika);
                slikaForm.ShowDialog ();
            }
        }
    }
}
