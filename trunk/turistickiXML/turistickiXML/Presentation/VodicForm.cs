using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using turistickiXML.Bussines;
using System.Xml;

namespace turistickiXML.Presentation {
    public partial class VodicForm : Form {
        GradList gradlist = new GradList ();
        turistickiXML.DAL.XMLData xmldata = new turistickiXML.DAL.XMLData ();
        //DataTable grad = new DataTable();
        //DataTable masterList = new DataTable();
        XmlNodeList masterList2;
        string filePath = "..\\..\\XML\\turistickiVodic.xml";
        public VodicForm () {
            InitializeComponent ();
        }

        private void gradoviComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            FillMasterList ();
        }
        private void VodicForm_Load (object sender, EventArgs e) {
            FillGradCB ();

            lokacijaComboBox.Items.Add (new MuzejLokacija ());
            lokacijaComboBox.Items.Add (new BolnicaLokacija ());
            lokacijaComboBox.Items.Add (new ParkLokacija ());
            lokacijaComboBox.Items.Add (new ZnamenitostLokacija ());


            FillMasterList ();
        }
        private void FillGradCB () {
            DataTable grad = gradlist.GetGradList ();
            gradoviComboBox.DataSource = grad;
            gradoviComboBox.DisplayMember = "nazivGrad";
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
                Lokacija lokacija = new Lokacija (int.Parse (node["id"].InnerText), node["naziv"].InnerText);
                masterLista.Items.Add (lokacija);
            }
        }

        private void editBTN_Click (object sender, EventArgs e) {
            if (masterLista.SelectedItem == null)
                return;
            Lokacija odabranaLokacija = masterLista.SelectedItem as Lokacija;
            ILokacija vrstaLokacije = lokacijaComboBox.SelectedItem as ILokacija;
            vrstaLokacije.Update (odabranaLokacija.ID);
        }

        private void buttonNew_Click (object sender, EventArgs e) {
            int gradPostBr = (int)gradoviComboBox.SelectedValue;
            ILokacija vrstaLokacije = lokacijaComboBox.SelectedItem as ILokacija;
            vrstaLokacije.Insert (gradPostBr);
        }

        private void lokacijaComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            FillMasterList ();
        }

        private void buttonDelete_Click (object sender, EventArgs e) {
            Lokacija odabranaLokacija = masterLista.SelectedItem as Lokacija;
            ILokacija vrstaLokacije = lokacijaComboBox.SelectedItem as ILokacija;
            vrstaLokacije.Delete (odabranaLokacija.ID);
        }

    }
}
