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
    public partial class ZnamenitostNewEdit : Form {
        public bool accepted = false;
        private int sifra;
        bool isNew = false;

        public ZnamenitostNewEdit()
        {
            isNew = true;
            this.Name = "Nova znamenitost";
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ZnamenitostNewEdit(int sifra)
        {
            if (sifra == 0)
                isNew = true;
            else
                isNew = false;
            this.Name = "Izmjena znamenitosti";
            this.sifra = sifra;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet da = new DataSet();
        BindingSource znamenitostBinding;
        BindingSource gradBinding;

        private void ZnamenitostNewEdit_Load(object sender, EventArgs e)
        {

            string sqlZnamenitost = "SELECT * FROM znamenitost";
            string sqlGrad = "SELECT * FROM grad";
            try
            {
                conn.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                da.Reset();
                adapter.SelectCommand = new NpgsqlCommand(sqlZnamenitost, conn);
                adapter.Fill(da, "znamenitost");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill(da, "grad");
                conn.Close();
                znamenitostBinding = new BindingSource(da, "znamenitost");
                gradBinding = new BindingSource(da, "grad");
                znamenitostBinding.Position = znamenitostBinding.Find("sifra", sifra);
                gradComboBox.DataSource = gradBinding;
                gradComboBox.DisplayMember = "ime";
                gradComboBox.ValueMember = "postanskibroj";
                tipZnamenCB.SelectedIndex = 0;
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

            nazivTB.DataBindings.Add("Text", znamenitostBinding, "naziv");
            string adresa = da.Tables[0].Rows[znamenitostBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);

            gradComboBox.SelectedValue = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["postanskibroj"];


            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];
            radnoVrijemeTB.DataBindings.Add("Text", znamenitostBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", znamenitostBinding, "opis");
            datumIzgradnje.DataBindings.Add("Value", znamenitostBinding, "datumizgradnje");
            tipZnamenCB.SelectedItem = da.Tables[0].Rows[znamenitostBinding.Find("sifra", sifra)]["tipznamenitosti"];

        }
        private void prihvatiBTN_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                string sqlString = "INSERT INTO znamenitost (naziv, opis, radnoVrijeme, adresa, datumizgradnje, tipznamenitosti) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @adresa, @datumizgradnje, @tipznamenitosti)";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
                    string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString() + ")";

                    comm.Parameters.AddWithValue("@adresa", adresa);
                    comm.Parameters.AddWithValue("@radnoVrijeme", radnoVrijemeTB.Text);
                    comm.Parameters.AddWithValue("@datumizgradnje", datumIzgradnje.Value.Date);
                    comm.Parameters.AddWithValue("@tipznamenitosti", tipZnamenCB.SelectedItem.ToString());
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
                string sqlString = "UPDATE znamenitost SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, adresa = @adresa, " +
                    "datumizgradnje = @datumizgradnje, tipznamenitosti = @tipznamenitosti WHERE sifra = @sifra";
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
                    comm.Parameters.AddWithValue("@datumizgradnje", datumIzgradnje.Value.Date);
                    comm.Parameters.AddWithValue("@tipznamenitosti", tipZnamenCB.SelectedItem.ToString());
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
        private void odustaniBTN_Click(object sender, EventArgs e)
        {
            accepted = false;
            this.Close();
        }
    }
}
