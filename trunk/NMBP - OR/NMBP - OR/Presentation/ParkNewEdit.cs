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

        private int sifra;
        private int indeksSlike = 1;
        private String slika1Naziv = null;
        List<byte[]> slike;
        private int BrojSlika = 0;
        private String slika2Naziv = null;
        private String slika3Naziv = null;

        bool isNew = false;

        Slika slika = new Slika();

        public ParkNewEdit () {
            isNew = true;
            slike = new List<byte[]>();
            this.Name = "Novi park";
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ParkNewEdit (int sifra) {
            if (sifra == 0)
            {
                isNew = true;
                slike = new List<byte[]>();
            }
            else
            {
                isNew = false;
                slike = new List<byte[]>();
                for (int i = 1; i <= 3; i++)
                {
                    if (slika.getSlikaBytes(type, i, sifra) != null)
                        slike.Add(slika.getSlikaBytes(type, i, sifra));
                }
            }
            this.Name = "Izmjena parka";
            this.sifra = sifra;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet da = new DataSet();
        BindingSource parkBinding;
        BindingSource gradBinding;
        
        private void ParkNewEdit_Load(object sender, EventArgs e)
        {
            
                string sqlPark = "SELECT * FROM park";
                string sqlGrad = "SELECT * FROM grad";
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                    da.Reset();
                    adapter.SelectCommand = new NpgsqlCommand(sqlPark, conn);
                    adapter.Fill(da, "park");
                    adapter.SelectCommand.CommandText = sqlGrad;
                    adapter.Fill(da, "grad");
                    conn.Close();
                    parkBinding = new BindingSource(da, "park");
                    gradBinding = new BindingSource(da, "grad");
                    parkBinding.Position = parkBinding.Find("sifra", sifra);
                    gradComboBox.DataSource = gradBinding;
                    gradComboBox.DisplayMember = "ime";
                    gradComboBox.ValueMember = "postanskibroj";
                    if (isNew)
                        return;
                    BindData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void BindData()
        {

            nazivTB.DataBindings.Add("Text", parkBinding, "naziv");
            string adresa = da.Tables[0].Rows[parkBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);

            gradComboBox.SelectedValue = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["postanskibroj"];
            if (slike.Count != 0) parkPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]); 

            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];
            
            radnoVrijemeTB.DataBindings.Add("Text", parkBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", parkBinding, "opis");
            string otvoreno = Convert.ToString(da.Tables[0].Rows[parkBinding.Find("sifra", sifra)]["otvoren"]);

            if (otvoreno == "True")
                otvoren.Checked = true;
            else
                otvoren.Checked = false;

            for (int i = 1; i <= 3; i++)
            {
                if (slika.getSlikaBytes(type, i, sifra) != null)
                    BrojSlika++;
            }

        }
        
        private void prihvatiBTN_Click (object sender, EventArgs e) {
            if (isNew)
            {
                for (int i = slike.Count; i < 3; i++)
                    slike.Add(null);
                string sqlString = "INSERT INTO park (naziv, opis, radnoVrijeme, otvoren, adresa, slika[1], slika[2], slika[3]) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @otvoren, @adresa, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
                    string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString() + ")";
                    comm.Parameters.AddWithValue("@adresa", adresa);
                    comm.Parameters.AddWithValue("@slika1Naziv", slika1Naziv);
                    comm.Parameters.AddWithValue("@slika1Byte", (object)slike[0]);
                    comm.Parameters.AddWithValue("@slika2Naziv", slika2Naziv);
                    comm.Parameters.AddWithValue("@slika2Byte", (object)slike[1]);
                    comm.Parameters.AddWithValue("@slika3Naziv", slika3Naziv);
                    comm.Parameters.AddWithValue("@slika3Byte", (object)slike[2]);
                    comm.Parameters.AddWithValue("@radnoVrijeme", radnoVrijemeTB.Text);
                    comm.Parameters.AddWithValue("@otvoren", otvoren.Checked);
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            else
            {
                for (int i = slike.Count; i < 3; i++)
                    slike.Add(null);
                string sqlString = "UPDATE park SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, otvoren = @otvoren, adresa = @adresa, " +
                    "slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), slika[3]=(@slika3Naziv, @slika3Byte) " +
                    "WHERE sifra = @sifra";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
                    string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString() + ")";
                    comm.Parameters.AddWithValue("@adresa", adresa);
                    comm.Parameters.AddWithValue("@radnoVrijeme", radnoVrijemeTB.Text);
                    comm.Parameters.AddWithValue("@sifra", sifra);
                    comm.Parameters.AddWithValue("@otvoren", otvoren.Checked);
                    comm.Parameters.AddWithValue("@slika1Naziv", slika1Naziv);
                    comm.Parameters.AddWithValue("@slika1Byte", (object)slike[0]);
                    comm.Parameters.AddWithValue("@slika2Naziv", slika2Naziv);
                    comm.Parameters.AddWithValue("@slika2Byte", (object)slike[1]);
                    comm.Parameters.AddWithValue("@slika3Naziv", slika3Naziv);
                    comm.Parameters.AddWithValue("@slika3Byte", (object)slike[2]);
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            this.Close();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
           
            this.Close ();
        }

        private void ucitajSlikuTB_Click(object sender, EventArgs e)
        {
            if (slike.Count == 3)
            {
                MessageBox.Show("Nije moguće učitati više od 3 slike za jedan zapis");
                return;
            }
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    slika1Naziv = "test";
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(new BufferedStream(fs));
                    if (isNew)
                    {
                        slike.Add(br.ReadBytes((Int32)fs.Length));
                        parkPB.Image = new Bitmap(open.FileName);
                    }

                    else
                    {
                        slike.Add(br.ReadBytes((Int32)fs.Length));
                        parkPB.Image = new Bitmap(open.FileName);

                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Neuspjelo učitavanje slike");
            }
        
        }

        private void previousPictureButton_Click(object sender, EventArgs e)
        {
            int brojSlika = BrojSlika;

            if (brojSlika != 0)
            {
                if (indeksSlike == 1) indeksSlike = brojSlika;
                else indeksSlike--;
                if (isNew)

                    parkPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
                else
                    parkPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);


            }
        }

        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            int brojSlika = BrojSlika;

            if (brojSlika != 0)
            {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                if (isNew)

                    parkPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
                else
                    parkPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);


            }
        }

        private void ZamijeniButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                slika1Naziv = "test";
                FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(new BufferedStream(fs));
                parkPB.Image = new Bitmap(open.FileName);
                slike[indeksSlike - 1] = br.ReadBytes((Int32)fs.Length);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            slike[indeksSlike - 1] = null;
            parkPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
        }

        private void parkPB_DoubleClick(object sender, EventArgs e)
        {
            SlikaForm slikaForm = new SlikaForm(type, sifra, BrojSlika);
            slikaForm.ShowDialog();
        }
    }
}
