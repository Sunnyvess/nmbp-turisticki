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
    public partial class BolnicaNewEdit : Form {
        public Logic.Bolnica bolnica;
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
            this.sifra = sifra;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
       
        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        //DataSet da = new DataSet();
        private void BolnicaNewEdit_Load(object sender, EventArgs e)
        {
            if (isNew)
                return;
            // TODO: This line of code loads data into the 'bolnicaDataSet1.grad' table. You can move, or remove it, as needed.
            this.gradTableAdapter.Fill(this.bolnicaDataSet1.grad);
            // TODO: This line of code loads data into the 'bolnicaDataSet1.bolnica' table. You can move, or remove it, as needed.
            this.bolnicaTableAdapter.Fill(this.bolnicaDataSet1.bolnica);
            // TODO: This line of code loads data into the 'oRDDataSet.grad' table. You can move, or remove it, as needed.
            
            
            if (sifra != 0)
            {
                //string sql = "SELECT * FROM bolnica" + " WHERE sifra=" + Sifra.ToString(); ;

                //NpgsqlDataAdapter bolnicaData = new NpgsqlDataAdapter(sql, conn);
                //da.Reset();
                //bolnicaData.Fill(da);
                bindingSource1.Position = bindingSource1.Find("sifra", sifra);
                BindData();
                //conn.Close();
            }

            else
            {
                
            }
        }
        private void BindData()
        {
            
            nazivTB.DataBindings.Add("Text",bindingSource1,"naziv");
            adresaTB.Text = getAdresa();
            radnoVrijemeTB.DataBindings.Add("Text",bindingSource1,"radnovrijeme");
            opisTB.DataBindings.Add("Text", bindingSource1, "opis");
            
            string dezurstvo = Convert.ToString(bolnicaDataSet1.Tables[0].Rows[bindingSource1.Find("sifra",sifra)]["dezurstvo"]);
            
            if (dezurstvo == "1")
                dezurna.Checked = true;
            else
                dezurna.Checked = false;
        }
        private string getAdresa()
        {
            string adresa = bolnicaDataSet1.Tables[0].Rows[bindingSource1.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string ulica = adresa.Substring(0, adresa.IndexOf(","));
            int pbr = Convert.ToInt32(adresa.Substring(adresa.IndexOf(",") + 1));
            string grad = bolnicaDataSet1.Tables[1].Rows[bindingSource2.Find("postanskibroj", pbr)]["ime"].ToString();
            return adresa + " " + grad;
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
                    comm.Parameters.AddWithValue("@adresa", adresaTB.Text);
                    comm.Parameters.AddWithValue("@radnoVrijeme", radnoVrijemeTB.Text);
                    comm.Parameters.AddWithValue("@dezurstvo", dezurna.Checked);
                    MessageBox.Show(comm.CommandText);
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            /* if (Sifra == 0)
             {
                 NpgsqlDataAdapter daBolnice = new NpgsqlDataAdapter("SELECT * FROM bolnica", conn);
                 daBolnice.Fill(da, "bolnica");
                 DataRow newRow = da.Tables["bolnica"].NewRow();
                 newRow["naziv"] = nazivTB.Text;
                 //newRow["adresa"] = ;
                 newRow["opis"] = opisTB.Text;
                 newRow["radnovrijeme"] = radnoVrijemeTB.Text;
                 newRow["sifra"] = da.Tables[0].Columns.Count + 1;
                 if (dezurna.Checked)
                     newRow["dezurstvo"] = true;
                 else
                     newRow["dezurstvo"] = false;
                 da.Tables["bolnica"].Rows.Add(newRow);
                 NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(daBolnice);
                 daBolnice.Update(da, "bolnica");
             }
             else
             {
                 NpgsqlDataAdapter daBolnice = new NpgsqlDataAdapter("SELECT * FROM bolnica", conn);
                 daBolnice.Fill(da, "bolnica");
                 DataRow dataRow = da.Tables[0].Rows.Find("sifra",Sifra);
                 //dataRow.BeginEdit();
                 if(da.HasChanges())
                 {
                     daBolnice.Update(da.Tables[0]);
                 }

             }*/
            //DataTable dado = bolnicaDataSet.Tables["bolnica"];
            //DataRow current = dado.Rows.Find(Sifra);
            //current.BeginEdit();
            //string query = "UPDATE bolnica SET naziv=" + nazivTB.Text + ", opis=" + opisTB.Text + " WHERE sifra=" + Sifra;
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn);
            /*bindingSource1.EndEdit();
            try
            {
                if (bolnicaDataSet.HasChanges())
                {

                    pgSqlDataAdapter1.Update(bolnicaDataSet.bolnica);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pogreska" + ex.ToString());
            }*/
            else
            {
                string sqlString = "UPDATE bolnica SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, " +
                    "dezurstvo = @dezurstvo WHERE sifra = @sifra";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
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
                //accepted = true;
            }
            this.Close();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
            accepted = false;
            this.Close ();
        }
    }
}
