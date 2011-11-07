using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Npgsql;

namespace NMBP___OR.Presentation {
    public partial class ZnamenitostNewEdit : Form {
        private string type = "znamenitost";
        static string connString = DatabaseManager.connString;

        NpgsqlConnection conn = new NpgsqlConnection (connString);
        DataSet da = new DataSet ();
        BindingSource znamenitostBinding;
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

        public ZnamenitostNewEdit (string pbr) {
            InitializeComponent ();
            isNew = true;
            slike = new List<byte[]> ();
            this.Text = "Nova znamenitost";
            this.StartPosition = FormStartPosition.CenterScreen;
            FillGradCB ();
            gradComboBox.SelectedValue = int.Parse (pbr);
        }
        public ZnamenitostNewEdit (int sifra) {
            InitializeComponent ();
            isNew = false;
            slike = new List<byte[]> ();
            for (int i = 1 ; i <= 3 ; i++) {
                if (slika.getSlikaBytes (type, i, sifra) != null)
                    slike.Add (slika.getSlikaBytes (type, i, sifra));
            }

            this.Text = "Izmjena znamenitosti";
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

        private void ZnamenitostNewEdit_Load (object sender, EventArgs e) {

            string sqlZnamenitost = "SELECT * FROM znamenitost";
            string sqlGrad = "SELECT * FROM grad";
            try {
                conn.Open ();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter ();
                da.Reset ();
                adapter.SelectCommand = new NpgsqlCommand (sqlZnamenitost, conn);
                adapter.Fill (da, "znamenitost");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill (da, "grad");
                conn.Close ();
                znamenitostBinding = new BindingSource (da, "znamenitost");
                gradBinding = new BindingSource (da, "grad");
                znamenitostBinding.Position = znamenitostBinding.Find ("sifra", sifra);
                tipZnamenCB.SelectedIndex = 0;
                if (isNew)
                    return;
                BindData ();

            }
            catch (Exception ex) {
                MessageBox.Show (ex.Message);
            }


        }
        private void BindData () {

            nazivTB.DataBindings.Add ("Text", znamenitostBinding, "naziv");
            string adresa = da.Tables[0].Rows[znamenitostBinding.Find ("sifra", sifra)]["adresa"].ToString ();
            adresa = adresa.Substring (1, adresa.IndexOf (")") - 1);
            string[] adress = adresa.Split (',');
            adress[0] = adress[0].Replace ("\"", "");
            int pbr = Convert.ToInt32 (adress[2]);

            gradComboBox.SelectedValue = da.Tables[1].Rows[gradBinding.Find ("postanskibroj", pbr)]["postanskibroj"];
            if (slike.Count != 0) znamPB.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);

            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];
            radnoVrijemeTB.DataBindings.Add ("Text", znamenitostBinding, "radnovrijeme");
            opisTB.DataBindings.Add ("Text", znamenitostBinding, "opis");
            datumIzgradnje.DataBindings.Add ("Value", znamenitostBinding, "datumizgradnje");
            tipZnamenCB.SelectedItem = da.Tables[0].Rows[znamenitostBinding.Find ("sifra", sifra)]["tipznamenitosti"];
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
                    znamPB.Image = new Bitmap (open.FileName);
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
                znamPB.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);
            }
        }
        private void nextPictureButton_Click (object sender, EventArgs e) {
            int brojSlika = BrojSlika;

            if (brojSlika != 0) {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                znamPB.Image = slika.pretvoriSlika (slike[indeksSlike - 1]);
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
                    znamPB.Image = new Bitmap (open.FileName);
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
                    znamPB.Image = slika.pretvoriSlika (slike[BrojSlika - 1]);
                else
                    znamPB.Image = null;
            }
        }
        private void znamPB_DoubleClick (object sender, EventArgs e) {
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
                    DatabaseManager.ZnamenitostInsert (nazivTB.Text, opisTB.Text, radnoVrijemeTB.Text, adresa, datumIzgradnje.Value, tipZnamenCB.SelectedItem.ToString(), 
                        (object) slike[0], slika1Naziv, (object) slike[1], slika2Naziv, (object) slike[2], slika3Naziv);
                }
                catch (Exception ex) {
                    MessageBox.Show (ex.Message);
                }
            }

            else {
                try {
                    DatabaseManager.ZnamenitostEdit (this.sifra, nazivTB.Text, opisTB.Text, radnoVrijemeTB.Text, adresa, datumIzgradnje.Value, tipZnamenCB.SelectedItem.ToString(), 
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
