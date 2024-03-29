﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Business;

namespace turistickiXML.Presentation
{
    public partial class MuzejNewEdit : Form
    {
        private Muzej muzej = new Muzej ();
        GradList gradlist = new GradList ();
        DataTable grad = new DataTable();
        private int sifra;
        private bool isNew;

        public MuzejNewEdit (string pbr) {
            InitializeComponent ();
            this.Text = "Novi muzej";
            this.StartPosition = FormStartPosition.CenterScreen;
            isNew = true;
            grad = gradlist.GetGradList();
            FillGradCB ();
            tipMuzejaCB.SelectedIndex = 0;
            gradComboBox.SelectedValue = int.Parse(pbr);
        }
        public MuzejNewEdit (int sifra) {
            InitializeComponent ();
            this.Text = "Izmjena muzeja";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.sifra = sifra;
            isNew = false;
            grad = gradlist.GetGradList();
            FillGradCB ();
            
            muzej = MuzejLokacija.SelectMuzej(sifra);
            BindData ();
        }

        private void FillGradCB () {
            
            this.gradComboBox.Items.Clear ();
            this.gradComboBox.DataSource = grad;
            this.gradComboBox.DisplayMember = "naziv";
            this.gradComboBox.ValueMember = "pbr";
            this.gradComboBox.SelectedIndex = 0;
            
        }
        private void BindData()
        {
            this.nazivTB.Text = muzej.Naziv;
            this.ulicaTB.Text = muzej.Ulica;
            this.opisTB.Text = muzej.Opis;
            this.radnoVrijemeTB.Text = muzej.RadnoVrijeme;
            tipMuzejaCB.SelectedItem = muzej.Tip;
            gradComboBox.SelectedValue = muzej.PostBr;
        }

        private void prihvatiBTN_Click(object sender, EventArgs e)
        {
            muzej.Naziv = nazivTB.Text;
            muzej.Ulica = ulicaTB.Text;
            muzej.Opis = opisTB.Text;
            muzej.RadnoVrijeme = radnoVrijemeTB.Text;
            muzej.PostBr = Convert.ToInt32(gradComboBox.SelectedValue);
            muzej.Tip = tipMuzejaCB.SelectedItem.ToString();
            if (isNew)
            {
                MuzejLokacija.InsertNew(muzej);
            }
            else if (!isNew)
                MuzejLokacija.Update(muzej);
            this.Close();
        }
        private void odustaniBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void nazivTB_Validating(object sender, CancelEventArgs e)
        {
            if (nazivTB.Text.Trim() == String.Empty)
            {
                prihvatiBTN.Enabled = false;
                errorProvider1.SetError(nazivTB, "Unesite naziv!");
            }
            else
            {
                prihvatiBTN.Enabled = true;
                errorProvider1.Clear();
            }
        }

        private void ulicaTB_Validating(object sender, CancelEventArgs e)
        {
            if (ulicaTB.Text.Trim() == String.Empty)
            {
                prihvatiBTN.Enabled = false;
                errorProvider2.SetError(ulicaTB, "Unesite adresu!");
            }
            else
            {
                prihvatiBTN.Enabled = true;
                errorProvider2.Clear();
            }
        }
    }
}
