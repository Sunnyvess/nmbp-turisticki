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
        bool isNew = false;
        
        public BolnicaNewEdit (){
            isNew = true;
            this.Name = "Nova bolnica";
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public BolnicaNewEdit(int sifra)
        {
            if (sifra == 0)
                isNew = true;
            else
                isNew = false;
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
           
            string sqlBolnica = "SELECT * FROM bolnica";
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
                string sqlString = "INSERT INTO bolnica (naziv, opis, radnoVrijeme, dezurstvo, adresa) VALUES " + 
                    "(@naziv, @opis, @radnoVrijeme, @dezurstvo, @adresa)";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
                    
                    string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString() + ")";
                    
                    comm.Parameters.AddWithValue("@adresa", adresa);
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
                    "dezurstvo = @dezurstvo, adresa = @adresa WHERE sifra = @sifra";
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
        /*
        private void ucitajSlikuBTN_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    bolnicaPB.Image = new Bitmap(open.FileName);
                }

            }
            catch (Exception)
            {
                throw new ApplicationException("Failed loading image");
            }
        
        }*/
    }
}
