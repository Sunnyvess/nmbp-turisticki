using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Npgsql;

namespace NMBP___OR.Presentation {
    public partial class ParkNewEdit : Form {
        private string type = "park";
        static string connString = DatabaseManager.connString;
        NpgsqlConnection conn = new NpgsqlConnection (connString);
        DataSet da = new DataSet ();
        BindingSource parkBinding;
        BindingSource gradBinding;

        private int sifra;
        private int indeksSlike = 1;
        private String slika1Naziv = null;
        List<byte[]> slike;
        private int BrojSlika = 0;
        private String slika2Naziv = null;
        private String slika3Naziv = null;

        bool isNew = false;
        Slika slika = new Slika ();

        public ParkNewEdit (string pbr) {
            isNew = true;
            slike = new List<byte[]> ();
            this.Text = "Novi park";
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
            FillGradCB ();
            gradComboBox.SelectedValue = int.Parse (pbr);
        }
        public ParkNewEdit (int sifra) {
            InitializeComponent ();
            isNew = false;
            slike = new List<byte[]> ();
            for (int i = 1 ; i <= 3 ; i++) {
                if (slika.getSlikaBytes (type, i, sifra) != null)
                    slike.Add (slika.getSlikaBytes (type, i, sifra));
            }

            this.Text = "Izmjena parka";
            this.sifra = sifra;
            this.StartPosition = FormStartPosition.CenterScreen;
            FillGradCB ();
        }
        private void FillGradCB () {
            gradComboBox.DataSource = DatabaseManager.GradTable ();
            gradComboBox.DisplayMember = "ime";
            gradComboBox.ValueMember = "postanskibroj";
            gradComboBox.SelectedIndex = 0;
        }

        private void ParkNewEdit_Load (object sender, EventArgs e) {

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
                if (isNew)
                    return;
                BindData ();

            }
            catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }
        }
        private void BindData () {

            nazivTB.DataBindings.Add ("Text", parkBinding, "naziv");
            string adresa = da.Tables[0].Rows[parkBinding.Find ("sifra", sifra)]["adresa"].ToString ();
            adresa = adresa.Substring (1, adresa.IndexOf (")") - 1);
            string[] adress = adresa.Split (',');
            adress[0] = adress[0].Replace ("\"", "");
            int pbr = Convert.ToInt32 (adress[2]);

            gradComboBox.SelectedValue = da.Tables[1].Rows[gradBinding.Find ("postanskibroj", pbr)]["postanskibroj"];
            if (slike.Count != 0) parkPB.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);

            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];

            radnoVrijemeTB.DataBindings.Add ("Text", parkBinding, "radnovrijeme");
            opisTB.DataBindings.Add ("Text", parkBinding, "opis");
            string otvoreno = Convert.ToString (da.Tables[0].Rows[parkBinding.Find ("sifra", sifra)]["otvoren"]);

            if (otvoreno == "True")
                otvoren.Checked = true;
            else
                otvoren.Checked = false;

            for (int i = 1 ; i <= 3 ; i++) {
                if (slika.getSlikaBytes (type, i, sifra) != null)
                    BrojSlika++;
            }

        }

        #region rad nad slikama

        private void ucitajSlikuTB_Click (object sender, EventArgs e) {
            if (BrojSlika == 3) {
                MessageBox.Show ("Nije moguće učitati više od 3 slike za jedan zapis");
                return;
            }
            try {
                OpenFileDialog open = new OpenFileDialog ();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog () == DialogResult.OK) {
                    slika1Naziv = "test";
                    FileStream fs = new FileStream (open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader (new BufferedStream (fs));
                    slike.Add (br.ReadBytes ((Int32) fs.Length));
                    parkPB.Image = new Bitmap (open.FileName);
                    BrojSlika++;
                    indeksSlike = BrojSlika;

                }

            }
            catch (Exception) {
                MessageBox.Show ("Neuspjelo učitavanje slike");
            }

        }
        private void previousPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;

            if (brojSlika != 0) {
                if (indeksSlike == 1) indeksSlike = brojSlika;
                else indeksSlike--;
                parkPB.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);


            }
        }
        private void nextPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;

            if (brojSlika != 0) {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                parkPB.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);


            }
        }
        private void ZamijeniButton_Click (object sender, EventArgs e) {
            if (BrojSlika > 0) {
                OpenFileDialog open = new OpenFileDialog ();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog () == DialogResult.OK) {
                    slika1Naziv = "test";
                    FileStream fs = new FileStream (open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader (new BufferedStream (fs));
                    parkPB.Image = new Bitmap (open.FileName);
                    slike[indeksSlike - 1] = br.ReadBytes ((Int32) fs.Length);
                }
            }
        }
        private void DeleteButton_Click (object sender, EventArgs e) {
            if (BrojSlika > 0) {
                slike.RemoveAt (indeksSlike - 1);
                BrojSlika--;
                indeksSlike = BrojSlika;
                if (BrojSlika > 0)
                    parkPB.Image = slika.pretvoriSlika (slike[BrojSlika - 1]);
                else
                    parkPB.Image = null;
            }
        }
        private void parkPB_DoubleClick (object sender, EventArgs e) {
            if (BrojSlika != 0) {
                SlikaForm slikaForm = new SlikaForm (slike, BrojSlika);
                slikaForm.ShowDialog ();
            }
        }

        #endregion

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            for (int i = slike.Count ; i < 3 ; i++)
                slike.Add (null);
            string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString () + ")";

            if (isNew) {
                try {
                    DatabaseManager.ParkInsert (nazivTB.Text, opisTB.Text, radnoVrijemeTB.Text, adresa, otvoren.Checked,
                        (object) slike[0], slika1Naziv, (object) slike[1], slika2Naziv, (object) slike[2], slika3Naziv);
                }
                catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }

            }
            else {               
                try {
                    DatabaseManager.ParkEdit (this.sifra, nazivTB.Text, opisTB.Text, radnoVrijemeTB.Text, adresa, otvoren.Checked,
                       (object) slike[0], slika1Naziv, (object) slike[1], slika2Naziv, (object) slike[2], slika3Naziv);
                }
                catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }
            }
            this.Close ();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {

            this.Close ();
        }

    }
}
