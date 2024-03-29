﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Business;
using System.Xml;

namespace turistickiXML.Presentation {
    public partial class VodicForm : Form {
        GradList gradlist = new GradList ();
        turistickiXML.DAL.XMLData xmldata = new turistickiXML.DAL.XMLData ();
        DataTable grad = new DataTable();
        XmlNodeList masterList2;
        string filePath = DAL.XMLData.filePath;

        public VodicForm () {
            InitializeComponent ();
        }
        private void VodicForm_Load (object sender, EventArgs e) {
            lokacijaComboBox.Items.Add (new MuzejLokacija ());
            lokacijaComboBox.Items.Add (new BolnicaLokacija ());
            lokacijaComboBox.Items.Add (new ParkLokacija ());
            lokacijaComboBox.Items.Add (new ZnamenitostLokacija ());
            grad = gradlist.GetGradList();
            FillGradCB ();
            FillMasterList ();
        }

        private void FillGradCB () {
            gradoviComboBox.DataSource = grad;
            gradoviComboBox.DisplayMember = "naziv";
            gradoviComboBox.ValueMember = "pbr";
            gradoviComboBox.SelectedIndex = 0;
            lokacijaComboBox.SelectedIndex = 0;
        }
        public void FillMasterList () {
            masterLista.Items.Clear ();
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            masterList2 = xmldata.Select (Convert.ToInt32 (gradoviComboBox.SelectedValue), lokacijaComboBox.SelectedItem.ToString ().ToLower ());

            foreach (XmlNode node in masterList2) {
                int id = 0;
                bool found = false;
                foreach (XmlAttribute attribute in node.Attributes) {
                    if (attribute.Name.ToLower ().StartsWith ("id")) {
                        id = int.Parse (attribute.Value);
                        found = true;
                    }
                }
                if (found == false)
                    continue;
                Lokacija lokacija = new Lokacija (id, node["naziv"].InnerText);
                masterLista.Items.Add (lokacija);
            }
            if(masterLista.Items.Count > 0)
                masterLista.SelectedIndex = 0;
        }

        private void gradoviComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            FillMasterList ();
        }
        private void lokacijaComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            FillMasterList ();
        }

        
        private void buttonNew_Click (object sender, EventArgs e) {
            if (gradoviComboBox.SelectedItem == null || lokacijaComboBox.SelectedItem == null)
                return;
            object selectedValue = gradoviComboBox.SelectedValue;
            int gradPostBr = int.Parse (gradoviComboBox.SelectedValue.ToString());
            ILokacija vrstaLokacije = lokacijaComboBox.SelectedItem as ILokacija;
            vrstaLokacije.ShowInsertForm (gradPostBr.ToString());
            FillMasterList ();
            gradoviComboBox.SelectedValue = selectedValue;
        }
        private void buttonEdit_Click (object sender, EventArgs e) {
            if (masterLista.SelectedItem == null)
                return;
            object selectedValue = gradoviComboBox.SelectedValue;
            Lokacija odabranaLokacija = masterLista.SelectedItem as Lokacija;
            
            ILokacija vrstaLokacije = lokacijaComboBox.SelectedItem as ILokacija;
            vrstaLokacije.ShowUpdateForm (odabranaLokacija.ID);
            FillMasterList ();
            gradoviComboBox.SelectedValue = selectedValue;

        }
        private void buttonDelete_Click (object sender, EventArgs e) {
            if (masterLista.SelectedItem == null)
                return;
            if (MessageBox.Show("Jeste li sigurni?", "Potvrda brisanja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                Lokacija odabranaLokacija = masterLista.SelectedItem as Lokacija;
                string vrstaLokacije = lokacijaComboBox.SelectedItem.ToString();
                DAL.XMLData.DeleteLokacija(vrstaLokacije, odabranaLokacija.ID);
                FillMasterList();
            }
        }

        private void masterLista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gradoviComboBox.SelectedItem == null)
                return;
            Lokacija odabranaLokacija = masterLista.SelectedItem as Lokacija;
            ILokacija vrstaLokacije = lokacijaComboBox.SelectedItem as ILokacija;
            vrstaLokacije.ShowInfoForm(odabranaLokacija.ID);  
        }
    }
}
