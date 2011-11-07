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
    public partial class MuzejNewEdit : Form {
        private string type = "muzej";
        private int indeksSlike = 1;
        private String slika1Naziv = null;
        List<byte[]> slike;
        private int BrojSlika = 0;
        private String slika2Naziv = null;
        private String slika3Naziv = null;
        Slika slika = new Slika();
        private int sifra;
        bool isNew = false;

        public MuzejNewEdit () {
            isNew = true;
            slike = new List<byte[]>();
            this.Name = "Novi muzej";
            InitializeComponent ();            
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        public MuzejNewEdit(int sifra)
        {
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
            this.Name = "Izmjena muzeja";
            this.sifra = sifra;
            InitializeComponent (); 
            this.StartPosition = FormStartPosition.CenterScreen;
        }
       
        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet da = new DataSet();
        BindingSource muzejBinding;
        BindingSource gradBinding;

        private void MuzejNewEdit_Load(object sender, EventArgs e)
        {
                string sqlMuzej = "SELECT * FROM muzej";
                string sqlGrad = "SELECT * FROM grad";
                try
                {
                    conn.Open();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                    da.Reset();
                    adapter.SelectCommand = new NpgsqlCommand(sqlMuzej, conn);
                    adapter.Fill(da, "muzej");
                    adapter.SelectCommand.CommandText = sqlGrad;
                    adapter.Fill(da, "grad");
                    conn.Close();
                    muzejBinding = new BindingSource(da, "muzej");
                    gradBinding = new BindingSource(da, "grad");
                    muzejBinding.Position = muzejBinding.Find("sifra", sifra);
                    gradComboBox.DataSource = gradBinding;
                    gradComboBox.DisplayMember = "ime";
                    gradComboBox.ValueMember = "postanskibroj";
                    tipMuzejaCB.SelectedIndex = 0;
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

            nazivTB.DataBindings.Add("Text", muzejBinding, "naziv");
            string adresa = da.Tables[0].Rows[muzejBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);

            gradComboBox.SelectedValue = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["postanskibroj"];
            if (slike.Count != 0) muzejPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];

            radnoVrijemeTB.DataBindings.Add("Text", muzejBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", muzejBinding, "opis");
            tipMuzejaCB.SelectedItem = da.Tables[0].Rows[muzejBinding.Find("sifra", sifra)]["tipmuzeja"];
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
                string sqlString = "INSERT INTO muzej (naziv, opis, radnoVrijeme, adresa, tipmuzeja, slika[1], slika[2], slika[3]) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @adresa, @tipmuzeja, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";
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
                    comm.Parameters.AddWithValue("@tipmuzeja", tipMuzejaCB.SelectedItem.ToString());
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
                for (int i = slike.Count; i < 3; i++)
                    slike.Add(null);

            {
                string sqlString = "UPDATE muzej SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, adresa = @adresa, " +
                    "tipmuzeja = @tipmuzeja, slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), slika[3]=(@slika3Naziv, @slika3Byte) WHERE sifra = @sifra";
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
                    comm.Parameters.AddWithValue("@tipmuzeja", tipMuzejaCB.SelectedItem.ToString());
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
            if (BrojSlika == 3)
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
                    slike.Add(br.ReadBytes((Int32)fs.Length));
                    muzejPB.Image = new Bitmap(open.FileName);
                    BrojSlika++;
                    indeksSlike = BrojSlika;

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
                muzejPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);


            }
        }

        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            int brojSlika = BrojSlika;

            if (brojSlika != 0)
            {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                muzejPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
            }
        }

        private void ZamijeniButton_Click(object sender, EventArgs e)
        {
            if (BrojSlika > 0)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    slika1Naziv = "test";
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(new BufferedStream(fs));
                    muzejPB.Image = new Bitmap(open.FileName);
                    slike[indeksSlike - 1] = br.ReadBytes((Int32)fs.Length);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (BrojSlika > 0)
            {
                slike.RemoveAt(indeksSlike - 1);
                BrojSlika--;
                indeksSlike = BrojSlika;
                if (BrojSlika > 0)
                    muzejPB.Image = slika.pretvoriSlika(slike[BrojSlika - 1]);
                else
                    muzejPB.Image = null;
            }
        }

        private void muzejPB_DoubleClick(object sender, EventArgs e)
        {
            if (BrojSlika != 0)
            {
                SlikaForm slikaForm = new SlikaForm(slike, BrojSlika);
                slikaForm.ShowDialog();
            }
        }

    }
}
