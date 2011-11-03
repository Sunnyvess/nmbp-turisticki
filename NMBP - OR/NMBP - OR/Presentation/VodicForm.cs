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
 
        
        public VodicForm () 
        
        
        {
            InitializeComponent ();
            
         
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);

        //private DataSet gradoviDataSet = new DataSet();
        //private DataSet lokacijaDataSet = new DataSet();

        private void VodicForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'oRDDataSet1.lokacija' table. You can move, or remove it, as needed.
            this.lokacijaTableAdapter.Fill(this.oRDDataSet1.lokacija);
            
            this.gradTableAdapter.Fill(this.oRDDataSet.grad);
            conn.Open();
          /*
            string upit = "SELECT grad.* " +
                          "FROM grad";
            string upitLokacija = "SELECT lokacija.* " + //+ lokacijaComboBox.SelectedItem.ToString ().ToLower() + ".* "  +
                                  "FROM lokacija";//+ lokacijaComboBox.SelectedItem.ToString ().ToLower();// +
                                  //" WHERE ";
            NpgsqlDataAdapter gradoviDataAdapter = new NpgsqlDataAdapter(upit, conn);
            NpgsqlDataAdapter lokacijaDataAdapter = new NpgsqlDataAdapter(upitLokacija, conn);
            gradoviDataSet.Reset();
            lokacijaDataSet.Reset();
            gradoviDataAdapter.Fill(gradoviDataSet,"grad");
            lokacijaDataAdapter.Fill(gradoviDataSet,"lokacija");*/
            lokacijaComboBox.SelectedIndex = 0;
            gradoviComboBox.SelectedIndex = 0;
            showDetails();
            //BindData();

        }
        
        private void BindData()
        {
            
/*
            this.gradoviComboBox.DataSource = gradoviDataSet.Tables[0];
            gradoviComboBox.DisplayMember = "ime";
            gradoviComboBox.ValueMember = "postanskibroj";
            
            masterLista.DataSource = gradoviDataSet.Tables[1];
            masterLista.DisplayMember = "naziv";
            masterLista.ValueMember = "(adresa).grad";*/
            
            //showDetails();
            
        }

        private void showForm(int sifra, string tip)
        {
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            switch (lokacijaComboBox.SelectedItem.ToString ()) {
                case "Muzej":
                    if (tip == "NewEdit")
                    {
                        MuzejNewEdit muzejNovi = new MuzejNewEdit();
                        muzejNovi.sifra = sifra;
                        muzejNovi.ShowDialog();
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
                    ZnamenitostNewEdit znamenitostNova = new ZnamenitostNewEdit ();
                    znamenitostNova.ShowDialog ();
                    break;
                case "Park":
                    ParkNewEdit parkNovi = new ParkNewEdit ();
                    parkNovi.ShowDialog ();
                    break;
        }
        }

        private void addBTN_Click (object sender, EventArgs e) 
        {
            showForm(0, "NewEdit");
        }
        
        private void showDetails()
        {
            //conn.Open();
            string sql = "SELECT * FROM " + lokacijaComboBox.SelectedItem.ToString().ToLower() + " WHERE (adresa).grad = " + gradoviComboBox.SelectedValue;
            DataSet detalji = new DataSet();
            NpgsqlDataAdapter detaljiData = new NpgsqlDataAdapter(sql,conn);
            detalji.Reset();
            detaljiData.Fill(detalji);
            masterLista.DataSource = detalji.Tables[0];
            masterLista.DisplayMember = "naziv";
            masterLista.ValueMember = "sifra";
            conn.Close();
            //napuniListuBolnica();

        }
        /*private void napuniListuBolnica()
        {
            List<Logic.Bolnica> bolnice = new List<Logic.Bolnica>();
            string sql = "SELECT * FROM bolnica";
            using(NpgsqlCommand command = new NpgsqlCommand(sql,conn))
            {

                NpgsqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string naziv = reader.GetString(0);
                    string adresa = reader.GetString(1);
                    string opis = reader.GetString(2);
                    string radnovrijeme = reader.GetString(3);
                    int sifra = reader.GetInt32(5);
                    bool dezurna = reader.GetBoolean(6);
                    bolnice.Add(new Logic.Bolnica(){naziv = naziv, adresa = adresa, opis = opis, radnovrijeme = radnovrijeme, sifra = sifra, dezurna = dezurna});
                    
                }
            }
            foreach(Logic.Bolnica bolnica in bolnice)
            {
                if (bolnica.adresa == )
                Console.WriteLine(bolnica);
                masterLista.Items.Add(bolnica.naziv);
            }
        }*/
        private void masterLista_SelectedIndexChanged (object sender, EventArgs e) {

            //showForm(Convert.ToInt32(masterLista.SelectedValue), "info");
            //Logic.ILokacija selectedItem = masterLista.SelectedItem as Logic.ILokacija;
            //if (selectedItem == null)
                //return;
           
        }
        private void editBTN_Click (object sender, EventArgs e) {
            //Logic.ILokacija selectedItem = masterLista.SelectedItem as Logic.ILokacija;
            //if (selectedItem == null)
                //return;
            //selectedItem.Izmijeni ();
            showForm(Convert.ToInt32(masterLista.SelectedValue), "NewEdit");
        }
        private void deleteBTN_Click (object sender, EventArgs e) {
            string type = lokacijaComboBox.SelectedItem.ToString().ToLower();
            string sqlString = "DELETE FROM " + type + " WHERE sifra = @sifra"; 

            Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
            comm.Parameters.Clear();
            //comm.Parameters.AddWithValue("@type", type);
            comm.Parameters.AddWithValue("@sifra", int.Parse (masterLista.SelectedValue.ToString()));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void lokacijaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void masterLista_DoubleClick(object sender, EventArgs e)
        {

        }

        
    }
}
