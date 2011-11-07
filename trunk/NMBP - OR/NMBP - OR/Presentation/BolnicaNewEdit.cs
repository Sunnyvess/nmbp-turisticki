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
    public partial class BolnicaNewEdit : Form {
        private string type = "bolnica";
        
        private int sifra;
        private int indeksSlike = 1;
        private String slika1Naziv = null;
        List<byte[]> slike;
        private int BrojSlika = 0;
        private String slika2Naziv = null;
        private String slika3Naziv = null;
        bool isNew = false;
        Slika slika = new Slika();
        
        public BolnicaNewEdit (){
            isNew = true;
            slike = new List<byte[]>();
            this.Name = "Nova bolnica";
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public BolnicaNewEdit(int sifra)
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
            this.Name = "Izmjena bolnice";
            this.sifra = sifra;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
       
        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet da = new DataSet();
        BindingSource bolnicaBinding;
        BindingSource gradBinding;
        
        private void BolnicaNewEdit_Load(object sender, EventArgs e)
        {

            string sqlBolnica = "SELECT naziv, adresa, opis, radnovrijeme, sifra, dezurstvo FROM bolnica";
            string sqlGrad = "SELECT * FROM grad";
            try
            {
                    conn.Open();
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                    da.Reset();
                    adapter.SelectCommand = new NpgsqlCommand(sqlBolnica,conn);
                    adapter.Fill(da, "bolnica");
                    adapter.SelectCommand.CommandText = sqlGrad;
                    adapter.Fill(da, "grad");
                    conn.Close();
                    bolnicaBinding = new BindingSource(da, "bolnica");
                    gradBinding = new BindingSource(da, "grad");
                    bolnicaBinding.Position = bolnicaBinding.Find("sifra", sifra);
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

            nazivTB.DataBindings.Add("Text", bolnicaBinding, "naziv");
            string adresa = da.Tables[0].Rows[bolnicaBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);

            gradComboBox.SelectedValue = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["postanskibroj"];
            //if (slika.getBrojSlika(type, sifra) != 0) bolnicaPB.Image = slika.getSlika(type, indeksSlike, sifra);
            if (slike.Count != 0) bolnicaPB.Image = slika.pretvoriSlika(slike[indeksSlike-1]);   
            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];
            radnoVrijemeTB.DataBindings.Add("Text", bolnicaBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", bolnicaBinding, "opis");
            
            string dezurstvo = Convert.ToString(da.Tables[0].Rows[bolnicaBinding.Find("sifra", sifra)]["dezurstvo"]);
            
            if (dezurstvo == "True")
                dezurna.Checked = true;
            else
                dezurna.Checked = false;

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

                
                string sqlString = "INSERT INTO bolnica (naziv, opis, radnoVrijeme, dezurstvo, adresa, slika[1], slika[2], slika[3]) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @dezurstvo, @adresa, (@slika1Naziv, @slika1Byte), (@slika2Naziv, @slika2Byte), (@slika3Naziv, @slika3Byte))";
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
                    comm.Parameters.AddWithValue("@dezurstvo", dezurna.Checked);
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

                
                
                string sqlString = "UPDATE bolnica SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, " +
                    "dezurstvo = @dezurstvo, adresa = @adresa, slika[1]=(@slika1Naziv, @slika1Byte), slika[2]=(@slika2Naziv, @slika2Byte), " +
                    "slika[3]=(@slika3Naziv, @slika3Byte) WHERE sifra = @sifra";
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
                    comm.Parameters.AddWithValue("@dezurstvo", dezurna.Checked);
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
       
        private void ucitajSlikuBTN_Click(object sender, EventArgs e)
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
                    bolnicaPB.Image = new Bitmap(open.FileName);
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
                 bolnicaPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);  
            }
        }

        private void nextPictureButton_Click(object sender, EventArgs e)
        {
            int brojSlika = BrojSlika;

            if (brojSlika != 0)
            {
                if (indeksSlike == brojSlika) indeksSlike = 1;
                else indeksSlike++;
                bolnicaPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
            }
        }

        private void ZamijeniButtton_Click(object sender, EventArgs e)
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
                    bolnicaPB.Image = new Bitmap(open.FileName);
                    slike[indeksSlike - 1] = br.ReadBytes((Int32)fs.Length);
                }
            }
        }

        private void bolnicaPB_DoubleClick(object sender, EventArgs e)
        {
            if (BrojSlika != 0)
            {
                SlikaForm slikaForm = new SlikaForm(slike,BrojSlika);
                slikaForm.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (BrojSlika > 0)
            {
                slike.RemoveAt(indeksSlike - 1);
                BrojSlika--;
                indeksSlike = BrojSlika;
            }
            if (BrojSlika > 0)
                bolnicaPB.Image = slika.pretvoriSlika(slike[indeksSlike - 1]);
            else
                bolnicaPB.Image = null;
        }

    }
}
