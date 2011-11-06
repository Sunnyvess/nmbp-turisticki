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
        
        public bool accepted = false;
        private int sifra;
        private String slika1Naziv = null;
        private byte[] slika1Byte;
        private String slika2Naziv = null;
        private byte[] slika2Byte;
        private String slika3Naziv = null;
        private byte[] slika3Byte;
        bool isNew = false;
        
        public BolnicaNewEdit (){
            isNew = true;
            slika1Byte = null;
            slika2Byte = null;
            slika3Byte = null;

            this.Name = "Nova bolnica";
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public BolnicaNewEdit(int sifra)
        {
            if (sifra == 0)
            {
                isNew = true;
                slika1Byte = null;
                slika2Byte = null;
                slika3Byte = null;
            }
            else
            {
                isNew = false;
                slika1Byte = getSlikaBytes(1, sifra);
                slika2Byte = getSlikaBytes(2, sifra);
                slika3Byte = getSlikaBytes(3, sifra);
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

            
            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];
            radnoVrijemeTB.DataBindings.Add("Text", bolnicaBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", bolnicaBinding, "opis");
            
            string dezurstvo = Convert.ToString(da.Tables[0].Rows[bolnicaBinding.Find("sifra", sifra)]["dezurstvo"]);
            
            if (dezurstvo == "True")
                dezurna.Checked = true;
            else
                dezurna.Checked = false;

        }
       
        private void prihvatiBTN_Click (object sender, EventArgs e) {
            if (isNew)
            {
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
                    comm.Parameters.AddWithValue("@slika1Byte", (object)slika1Byte);
                    comm.Parameters.AddWithValue("@slika2Naziv", slika2Naziv);
                    comm.Parameters.AddWithValue("@slika2Byte", (object)slika2Byte);
                    comm.Parameters.AddWithValue("@slika3Naziv", slika3Naziv);
                    comm.Parameters.AddWithValue("@slika3Byte", (object)slika3Byte);
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
                    comm.Parameters.AddWithValue("@slika1Byte", (object)slika1Byte);
                    comm.Parameters.AddWithValue("@slika2Naziv", slika2Naziv);
                    comm.Parameters.AddWithValue("@slika2Byte", (object)slika2Byte);
                    comm.Parameters.AddWithValue("@slika3Naziv", slika3Naziv);
                    comm.Parameters.AddWithValue("@slika3Byte", (object)slika3Byte);
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
            accepted = false;
            this.Close ();
        }

        
        private void ucitajSlikuBTN_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //bolnicaPB.Image = Image.FromFile(open.FileName);
                    label5.Text = "Slika 1 učitana";
                    slika1Naziv = "test";
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(new BufferedStream(fs));
                    slika1Byte = br.ReadBytes((Int32)fs.Length);         
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        
        }

        private void ucitajSliku2BTN_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //bolnicaPB.Image = Image.FromFile(open.FileName);
                    label6.Text = "Slika 2 učitana";
                    slika2Naziv = "test";
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(new BufferedStream(fs));
                    slika2Byte = br.ReadBytes((Int32)fs.Length);
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //bolnicaPB.Image = Image.FromFile(open.FileName);
                    label7.Text = "Slika 3 učitana";
                    slika3Naziv = "test";
                    FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(new BufferedStream(fs));
                    slika3Byte = br.ReadBytes((Int32)fs.Length);
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        }

        private byte[] getSlikaBytes(int indeks, int sifra)
        {
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT slika[" + indeks + "].slika FROM bolnica where sifra = " + sifra, conn);
            object result = command.ExecuteScalar();
            conn.Close();

            if (result is byte[])
            {
                byte[] slika = (byte[])result;
                return slika;
            }
            else return null;
        }
    }
}
