using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Presentation {
    public partial class VodicForm : Form {
        public VodicForm () {
            InitializeComponent ();

            lokacijaComboBox.Items.Clear ();
            lokacijaComboBox.Items.Add ("Bolnica");
            lokacijaComboBox.Items.Add ("Muzej");
            lokacijaComboBox.Items.Add ("Znamenitost");
            lokacijaComboBox.Items.Add ("Park");

            gradoviComboBox.Items.Clear ();
            gradoviComboBox.Items.Add ("Zagreb");
            gradoviComboBox.Items.Add ("Split");
            gradoviComboBox.Items.Add ("Osijek");

            //foreach (Grad.Grad tempGrad in gradList)
            //    gradoviComboBox.Items.Add (tempGrad);

            //foreach (Bolnica.Bolnica tempBolnica in bolnicaList)
            //    lokacijaComboBox.Items.Add (tempBolnica);
            //foreach (Muzej.Muzej tempMuzej in muzejList)
            //    lokacijaComboBox.Items.Add (tempMuzej);
            //foreach (Park.Park tempPark in parkList)
            //    lokacijaComboBox.Items.Add (tempPark);
            //foreach (Znamenitost.Znamenitost tempZnam in znamList)
            //    lokacijaComboBox.Items.Add (tempZnam);
        }

        private void addBTN_Click (object sender, EventArgs e) {
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            switch (lokacijaComboBox.SelectedItem.ToString ()) {
                case "Muzej":
                    MuzejNewEdit muzejNovi = new MuzejNewEdit ();
                    muzejNovi.ShowDialog ();
                    break;
                case "Bolnica":
                    BolnicaNewEdit bolnicaNova = new BolnicaNewEdit ();
                    bolnicaNova.ShowDialog ();
                    break;
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

        private void masterLista_SelectedIndexChanged (object sender, EventArgs e) {
            ILokacija selectedItem = masterLista.SelectedItem as ILokacija;
            if (selectedItem == null)
                return;
            selectedItem.PrikaziInfo ();
        }
        private void editBTN_Click (object sender, EventArgs e) {
            ILokacija selectedItem = masterLista.SelectedItem as ILokacija;
            if (selectedItem == null)
                return;
            selectedItem.Izmijeni ();
        }
        private void deleteBTN_Click (object sender, EventArgs e) {
            ILokacija selectedItem = masterLista.SelectedItem as ILokacija;
            if (selectedItem == null)
                return;
            selectedItem.Obrisi ();

        }
    }
}
