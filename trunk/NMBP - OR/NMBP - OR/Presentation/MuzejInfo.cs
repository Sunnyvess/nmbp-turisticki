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
    public partial class MuzejInfo : Form {
        private int Sifra;
        public MuzejInfo () {
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public int sifra
        {
            get { return Sifra; }
            set { Sifra = value; }
        }

        static string connString = "Server=dado.dyndns-home.com;Port=5432;User Id=postgres;Password=postgres;Database=ORD";

        NpgsqlConnection conn = new NpgsqlConnection(connString);
        DataSet da = new DataSet();
        BindingSource muzejBinding;
        BindingSource gradBinding;
        private void MuzejInfo_Load(object sender, EventArgs e)
        {
            string sqlBolnica = "SELECT * FROM muzej";
            string sqlGrad = "SELECT * FROM grad";
            try
            {
                conn.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
                da.Reset();
                adapter.SelectCommand = new NpgsqlCommand(sqlBolnica, conn);
                adapter.Fill(da, "muzej");
                adapter.SelectCommand.CommandText = sqlGrad;
                adapter.Fill(da, "grad");
                conn.Close();
                muzejBinding = new BindingSource(da, "muzej");
                gradBinding = new BindingSource(da, "grad");
                muzejBinding.Position = muzejBinding.Find("sifra", Sifra);
                BindData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindData()
        {
            nameLabel.DataBindings.Add("Text", muzejBinding, "naziv");
            adresaLabel.Text = getAdresa();
            radnoVrijemeLabel.DataBindings.Add("Text", muzejBinding, "radnovrijeme");
            opisLabel.DataBindings.Add("Text", muzejBinding, "opis");
            tipMuzejaLabel.DataBindings.Add("Text", muzejBinding, "tipmuzeja");
            
        }
        private string getAdresa()
        {
            string adresa = da.Tables[0].Rows[muzejBinding.Find("sifra", sifra)]["adresa"].ToString();
            adresa = adresa.Substring(1, adresa.IndexOf(")") - 1);
            string[] adress = adresa.Split(',');
            adress[0] = adress[0].Replace("\"", "");
            int pbr = Convert.ToInt32(adress[2]);
            string grad = da.Tables[1].Rows[gradBinding.Find("postanskibroj", pbr)]["ime"].ToString();
            return adress[0] + " " + adress[1] + ", " + adress[2] + " " + grad;
        }

    }
}