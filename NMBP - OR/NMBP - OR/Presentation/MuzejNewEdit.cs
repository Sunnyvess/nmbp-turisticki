﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace NMBP___OR.Presentation {
    public partial class MuzejNewEdit : Form {
        
        public bool accepted = false;
        private int sifra;
        bool isNew = false;

        public MuzejNewEdit () {
            isNew = true;
            this.Name = "Novi muzej";
            InitializeComponent ();            
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        public MuzejNewEdit(int sifra)
        {
            if (sifra == 0)
                isNew = true;
            else
                isNew = false;
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
            
            ulicaTB.Text = adress[0];
            brojTB.Text = adress[1];

            radnoVrijemeTB.DataBindings.Add("Text", muzejBinding, "radnovrijeme");
            opisTB.DataBindings.Add("Text", muzejBinding, "opis");
            tipMuzejaCB.SelectedItem = da.Tables[0].Rows[muzejBinding.Find("sifra", sifra)]["tipmuzeja"];
            
        }
       
        private void prihvatiBTN_Click (object sender, EventArgs e) {
            if (isNew)
            {
                string sqlString = "INSERT INTO muzej (naziv, opis, radnoVrijeme, adresa, tipmuzeja) VALUES " +
                    "(@naziv, @opis, @radnoVrijeme, @adresa, @tipmuzeja)";
                try
                {
                    conn.Open();
                    Npgsql.NpgsqlCommand comm = new NpgsqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@naziv", nazivTB.Text);
                    comm.Parameters.AddWithValue("@opis", opisTB.Text);
                    string adresa = "(" + ulicaTB.Text + "," + brojTB.Text + "," + gradComboBox.SelectedValue.ToString() + ")";
                    comm.Parameters.AddWithValue("@adresa", adresa);
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
            {
                string sqlString = "UPDATE muzej SET naziv = @naziv, opis = @opis, radnovrijeme = @radnoVrijeme, adresa = @adresa, " +
                    "tipmuzeja = @tipmuzeja WHERE sifra = @sifra";
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
