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
    public partial class VodicForm : Form {       
        public VodicForm () {
            InitializeComponent ();       
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";
        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet lokacijaDataSet = new DataSet();
        DataSet grad = new DataSet();
        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
        string type;
        
        private void VodicForm_Load(object sender, EventArgs e)
        {
           
            string sqlString = "SELECT * FROM grad";
            NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);

            grad.Reset();
            adapter.SelectCommand = comm;
            adapter.Fill(grad);
            gradoviComboBox.DataSource = grad.Tables[0];

            gradoviComboBox.DisplayMember = "ime";
            gradoviComboBox.ValueMember = "postanskibroj";
            
            lokacijaComboBox.Items.Add("Muzej");
            lokacijaComboBox.Items.Add("Bolnica");
            lokacijaComboBox.Items.Add("Park");
            lokacijaComboBox.Items.Add("Znamenitost");
            lokacijaComboBox.SelectedIndex = 0;
            gradoviComboBox.SelectedIndex = 0;
            showDetails();
        }

        private void showForm(int sifra, string tip)
        {
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            switch (lokacijaComboBox.SelectedItem.ToString ()) {
                case "Muzej":
                    if (tip == "NewEdit")
                    {
                        MuzejNewEdit muzejNovi = new MuzejNewEdit(sifra);
                        muzejNovi.ShowDialog();
                        showDetails();
                        break;
                    }
                    else
                    {
                        MuzejInfo muzejInfo = new MuzejInfo();
                        muzejInfo.sifra = sifra;
                        muzejInfo.ShowDialog();
                        break;
                    }
                case "Bolnica":
                    if (tip == "NewEdit")
                    {
                        BolnicaNewEdit bolnicaNova = new BolnicaNewEdit(sifra);
                        bolnicaNova.ShowDialog();
                        showDetails();
                        break;
                    }
                    else
                    {
                        BolnicaInfo bolnicaInfo = new BolnicaInfo();
                        bolnicaInfo.sifra = sifra;
                        bolnicaInfo.ShowDialog();
                        break;
                    }
                    
                case "Znamenitost":
                   if (tip == "NewEdit")
                    {
                        ZnamenitostNewEdit znamenitostNova = new ZnamenitostNewEdit(sifra);
                        znamenitostNova.ShowDialog();
                        showDetails();
                        break;
                    }
                    else
                    {
                        ZnamenitostInfo znamenitostInfo = new ZnamenitostInfo();
                        znamenitostInfo.sifra = sifra;
                        znamenitostInfo.ShowDialog();
                        break;
                    }
                case "Park":
                   if (tip == "NewEdit")
                   {
                       ParkNewEdit parkNova = new ParkNewEdit(sifra);
                       parkNova.ShowDialog();
                       showDetails();
                       break;
                   }
                   else
                   {
                       ParkInfo parkInfo = new ParkInfo();
                       parkInfo.sifra = sifra;
                       parkInfo.ShowDialog();
                       break;
                   }
            }
        }

        private void addBTN_Click (object sender, EventArgs e) 
        {
            showForm(0, "NewEdit");
        }
        
        private void showDetails()
        {

            if (lokacijaComboBox.SelectedItem == null)
                return;
            string sqlString = "SELECT naziv, sifra FROM " + type +" WHERE (adresa).grad = @adresa";
            NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@adresa", gradoviComboBox.SelectedValue);
            conn.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();

            lokacijaDataSet.Reset();
            adapter.SelectCommand = comm;
            adapter.Fill(lokacijaDataSet);
            conn.Close();
            masterLista.DataSource = lokacijaDataSet.Tables[0];
            masterLista.DisplayMember = "naziv";
            masterLista.ValueMember = "sifra";
        }

        private void editBTN_Click (object sender, EventArgs e) {
           
            showForm(Convert.ToInt32(masterLista.SelectedValue), "NewEdit");
        }
        private void deleteBTN_Click (object sender, EventArgs e) {
            if (masterLista.SelectedIndex < 0)
                return;
            if (MessageBox.Show("Jeste li sigurni?", "Potvrda brisanja", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                
                string sqlString = "DELETE FROM " + type + " WHERE sifra = @sifra";

                Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                comm.Parameters.Clear();

                comm.Parameters.AddWithValue("@sifra", int.Parse(masterLista.SelectedValue.ToString()));
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
                showDetails();
            }
        }

        private void lokacijaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = lokacijaComboBox.SelectedItem.ToString().ToLower();
            showDetails();
        }

        private void masterLista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showForm(Convert.ToInt32(masterLista.SelectedValue), "info");
        }

        private void gradoviComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showDetails();
        }     
    }
}
