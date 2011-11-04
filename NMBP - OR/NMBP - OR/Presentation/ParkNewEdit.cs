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
    public partial class ParkNewEdit : Form {
       
        public bool accepted = false;
        private int sifra;
        bool isNew = false;
        

        public ParkNewEdit () {
            isNew = true;
            this.Name = "Novi park";
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ParkNewEdit (int sifra) {
            if (sifra == 0)
                isNew = true;
            else
                isNew = false;
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


            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];
            
            radnoVrijemeTB.DataBindings.Add("Text", parkBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", parkBinding, "opis");
            string otvoreno = Convert.ToString(da.Tables[0].Rows[parkBinding.Find("sifra", sifra)]["otvoren"]);

            if (otvoreno == "True")
                otvoren.Checked = true;
            else
                otvoren.Checked = false;

        }
        
        private void prihvatiBTN_Click (object sender, EventArgs e) {
            if (isNew)
            {
                string sqlString = "INSERT INTO park (naziv, opis, radnoVrijeme, otvoren, adresa) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @otvoren, @adresa)";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
                    string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString() + ")";
                    comm.Parameters.AddWithValue("@adresa", adresa);
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
                string sqlString = "UPDATE park SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, otvoren = @otvoren, adresa = @adresa " +
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
    }
}
