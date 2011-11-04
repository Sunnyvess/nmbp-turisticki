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

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";
        NpgsqlConnection connection = new NpgsqlConnection (connString);
        DataSet lokacijaDataSet = new DataSet ();

        public VodicForm () {
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void VodicForm_Load (object sender, EventArgs e) {
            this.gradTableAdapter.Fill (this.oRDDataSet.grad);
            lokacijaComboBox.SelectedIndex = 0;
            gradoviComboBox.SelectedIndex = 0;
            showDetails ();
        }

        private void showForm (int sifra, string tip) {
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            switch (lokacijaComboBox.SelectedItem.ToString ()) {
                case "Muzej":
                    if (tip == "NewEdit") {
                        MuzejNewEdit muzejNovi = new MuzejNewEdit (sifra);
                        muzejNovi.ShowDialog ();
                        showDetails ();
                        break;
                    }
                    else {
                        MuzejInfo muzejInfo = new MuzejInfo ();
                        muzejInfo.sifra = sifra;
                        muzejInfo.ShowDialog ();
                        break;
                    }
                case "Bolnica":
                    if (tip == "NewEdit") {
                        BolnicaNewEdit bolnicaNova = new BolnicaNewEdit (sifra);
                        bolnicaNova.ShowDialog ();
                        showDetails ();
                        break;
                    }
                    else {
                        BolnicaInfo bolnicaInfo = new BolnicaInfo ();
                        bolnicaInfo.sifra = sifra;
                        bolnicaInfo.ShowDialog ();
                        break;
                    }

                case "Znamenitost":
                    if (tip == "NewEdit") {
                        ZnamenitostNewEdit znamenitostNova = new ZnamenitostNewEdit (sifra);
                        znamenitostNova.ShowDialog ();
                        showDetails ();
                        break;
                    }
                    else {
                        ZnamenitostInfo znamenitostInfo = new ZnamenitostInfo ();
                        znamenitostInfo.sifra = sifra;
                        znamenitostInfo.ShowDialog ();
                        break;
                    }
                case "Park":
                    if (tip == "NewEdit") {
                        ParkNewEdit parkNova = new ParkNewEdit (sifra);
                        parkNova.ShowDialog ();
                        showDetails ();
                        break;
                    }
                    else {
                        ParkInfo parkInfo = new ParkInfo ();
                        parkInfo.sifra = sifra;
                        parkInfo.ShowDialog ();
                        break;
                    }
            }
        }
        private void showDetails () {

            string type = lokacijaComboBox.SelectedItem.ToString ().ToLower ();
            string sqlString = "SELECT * FROM " + type + " WHERE (adresa).grad = @adresa";
            NpgsqlCommand comm = new NpgsqlCommand (sqlString, connection);
            comm.Parameters.Clear ();
            comm.Parameters.AddWithValue ("@adresa", gradoviComboBox.SelectedValue);
            connection.Open ();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter ();

            lokacijaDataSet.Reset ();
            adapter.SelectCommand = comm;
            adapter.Fill (lokacijaDataSet);
            connection.Close ();
            masterLista.DataSource = lokacijaDataSet.Tables[0];
            masterLista.DisplayMember = "naziv";
            masterLista.ValueMember = "sifra";
        }

        private void addBTN_Click (object sender, EventArgs e) {
            showForm (0, "NewEdit");
        }
        private void editBTN_Click (object sender, EventArgs e) {

            showForm (Convert.ToInt32 (masterLista.SelectedValue), "NewEdit");
        }
        private void deleteBTN_Click (object sender, EventArgs e) {
            if (masterLista.SelectedIndex < 0)
                return;
            string type = lokacijaComboBox.SelectedItem.ToString ().ToLower ();
            if (MessageBox.Show ("Jeste li sigurni?", "Potvrda brisanja", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                string sqlString = "DELETE FROM " + type + " WHERE sifra = @sifra";

                Npgsql.NpgsqlCommand comm = new NpgsqlCommand (sqlString, connection);
                comm.Parameters.Clear ();

                comm.Parameters.AddWithValue ("@sifra", int.Parse (masterLista.SelectedValue.ToString ()));
                connection.Open ();
                comm.ExecuteNonQuery ();
                connection.Close ();
                showDetails ();
            }
        }

        private void lokacijaComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            showDetails ();
        }
        private void masterLista_MouseDoubleClick (object sender, MouseEventArgs e) {
            showForm (Convert.ToInt32 (masterLista.SelectedValue), "info");
        }
        private void gradoviComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            showDetails ();
        }
    }
}
