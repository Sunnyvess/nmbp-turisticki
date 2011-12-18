﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Bussines;

namespace turistickiXML.Presentation
{
    public partial class ParkNewEdit : Form
    {
        private  Park park = new Park ();
        GradList gradlist = new GradList ();
        DataTable grad = new DataTable();
        private int sifra;
        private bool isNew;

        public ParkNewEdit (string pbr) {
            InitializeComponent ();
            this.Text = "Novi park";
            this.StartPosition = FormStartPosition.CenterScreen;
            isNew = true;
            grad = gradlist.GetGradList();
            FillGradCB ();
            gradComboBox.SelectedValue = int.Parse(pbr);
        }
        public ParkNewEdit (int sifra) {
            InitializeComponent ();
            this.Text = "Izmjena parka";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sifra = sifra;
            isNew = false;
            grad = gradlist.GetGradList();
            FillGradCB ();
            park = ParkLokacija.SelectPark (sifra);
            //gradComboBox.SelectedValue = int.Parse(pbr);

            BindData ();
        }

        private void FillGradCB () {
            
            this.gradComboBox.Items.Clear ();
            this.gradComboBox.DataSource = grad;
            this.gradComboBox.DisplayMember = "nazivGrad";
            this.gradComboBox.ValueMember = "pbr";
            this.gradComboBox.SelectedIndex = 0;
        }

        private void BindData () {
            //bolnica = new Bolnica ();
            //bolnica = bolnica.Select (sifra);
            this.nazivTB.Text = park.Naziv;
            this.ulicaTB.Text = park.Ulica;
            this.opisTB.Text = park.Opis;
            this.radnoVrijemeTB.Text = park.RadnoVrijeme;
            otvoren.Checked = park.Otvoren;
            gradComboBox.SelectedValue = park.PostBr;
        }

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            park.Naziv = nazivTB.Text;
            park.Ulica = ulicaTB.Text;
            park.Opis = opisTB.Text;
            park.RadnoVrijeme = radnoVrijemeTB.Text;
            park.PostBr = Convert.ToInt32 (gradComboBox.SelectedValue);
            park.Otvoren = otvoren.Checked;
            if (isNew) {
                park.ID = 3;
                
                ParkLokacija.InsertNew (park);
            }
            else if (!isNew)
                ParkLokacija.Update (park);
            this.Close ();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
            this.Close ();
        }
    }
}