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
        private int sifra;
        private int indeksSlike = 1;
        private string type = "muzej";
        Slika slika = new Slika ();
        private int BrojSlika = 0;
        static string connString = DatabaseManager.connString;

        NpgsqlConnection conn = new NpgsqlConnection (connString);
        DataSet da = new DataSet ();
        BindingSource muzejBinding;
        BindingSource gradBinding;

        public MuzejInfo (int sifra) {
            InitializeComponent ();
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void MuzejInfo_Load (object sender, EventArgs e) {
            string sqlBolnica = "SELECT * FROM muzej";
            string sqlGrad = "SELECT * FROM grad";
            try {
                conn.Open ();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter ();
                da.Reset ();
                adapter.SelectCommand = new NpgsqlCommand (sqlBolnica, conn);
                adapter.Fill (da, "muzej");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill (da, "grad");
                conn.Close ();
                muzejBinding = new BindingSource (da, "muzej");
                gradBinding = new BindingSource (da, "grad");
                muzejBinding.Position = muzejBinding.Find ("sifra", sifra);
                BindData ();

            }
            catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }

        private void BindData () {
            nameLabel.DataBindings.Add ("Text", muzejBinding, "naziv");
            adresaLabel.Text = getAdresa ();
            if (slika.getBrojSlika (type, sifra) != 0) muzejPB.Image = slika.getSlika (type, indeksSlike, sifra);
            radnoVrijemeLabel.DataBindings.Add ("Text", muzejBinding, "radnovrijeme");
            opisLabel.DataBindings.Add ("Text", muzejBinding, "opis");
            tipMuzejaLabel.DataBindings.Add ("Text", muzejBinding, "tipmuzeja");
            for (int i = 1 ; i <= 3 ; i++) {
                if (slika.getSlikaBytes (type, i, sifra) != null)
                    BrojSlika++;
            }

        }
        private string getAdresa () {
            string adresa = da.Tables[0].Rows[muzejBinding.Find ("sifra", sifra)]["adresa"].ToString ();
            adresa = adresa.Substring (1, adresa.IndexOf (")") - 1);
            string[] adress = adresa.Split (',');
            adress[0] = adress[0].Replace ("\"", "");
            int pbr = Convert.ToInt32 (adress[2]);
            string grad = da.Tables[1].Rows[gradBinding.Find ("postanskibroj", pbr)]["ime"].ToString ();
            return adress[0] + " " + adress[1] + ", " + adress[2] + " " + grad;
        }

        private void muzejPB_DoubleClick (object sender, EventArgs e) {
            if (BrojSlika != 0) {
                SlikaForm slikaForm = new SlikaForm (type, sifra, BrojSlika);
                slikaForm.ShowDialog ();
            }
        }
        private void previousPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;
            if (brojSlika != 0) {
                if (indeksSlike == 1) indeksSlike = brojSlika;
                else indeksSlike--;
                muzejPB.Image = slika.getSlika (type, indeksSlike, sifra);
            }
        }
        private void nextPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;
            if (brojSlika != 0) {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                muzejPB.Image = slika.getSlika (type, indeksSlike, sifra);
            }
        }
    }
}
