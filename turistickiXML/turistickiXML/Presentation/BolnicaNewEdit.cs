﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using turistickiXML.Bussines;

namespace turistickiXML.Presentation {
    public partial class BolnicaNewEdit : Form {
        private Bolnica bolnica = new Bolnica ();
        GradList gradlist = new GradList ();
        DataTable grad = new DataTable();
        private int sifra;
        private bool isNew;

        public BolnicaNewEdit (string pbr) {
            InitializeComponent ();
            this.Text = "Nova bolnica";
            this.StartPosition = FormStartPosition.CenterScreen;
            isNew = true;
            grad = gradlist.GetGradList();
            FillGradCB ();
            gradComboBox.SelectedValue = int.Parse(pbr);
        }
        public BolnicaNewEdit (int sifra) {
            InitializeComponent ();
            this.Text = "Izmjena bolnice";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sifra = sifra;
            isNew = false;
            grad = gradlist.GetGradList();
            FillGradCB ();
            bolnica = BolnicaLokacija.SelectBolnica (sifra);
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
            this.nazivTB.Text = bolnica.Naziv;
            this.ulicaTB.Text = bolnica.Ulica;
            this.opisTB.Text = bolnica.Opis;
            this.radnoVrijemeTB.Text = bolnica.RadnoVrijeme;
            dezurna.Checked = bolnica.Dezurna;
            gradComboBox.SelectedValue = bolnica.PostBr;
        }

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            bolnica.Naziv = nazivTB.Text;
            bolnica.Ulica = ulicaTB.Text;
            bolnica.Opis = opisTB.Text;
            bolnica.RadnoVrijeme = radnoVrijemeTB.Text;
            bolnica.PostBr = Convert.ToInt32 (gradComboBox.SelectedValue);
            bolnica.Dezurna = dezurna.Checked;
            if (isNew) {
                bolnica.ID = 3;
                BolnicaLokacija.InsertNew (bolnica);
            }
            else if (!isNew)
                BolnicaLokacija.Update (bolnica);
            this.Close ();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
            this.Close ();
        }
    }
}