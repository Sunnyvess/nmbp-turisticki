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

        public VodicForm () {
            InitializeComponent ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void VodicForm_Load (object sender, EventArgs e) {
            FillGradCB ();

            lokacijaComboBox.Items.Add (new Logic.Muzej ());
            lokacijaComboBox.Items.Add (new Logic.Bolnica ());
            lokacijaComboBox.Items.Add (new Logic.Park());
            lokacijaComboBox.Items.Add (new Logic.Znamenitost ());
            lokacijaComboBox.SelectedIndex = 0;

            FillMasterList ();
        }
        private void FillGradCB () {
            DataTable gradTable = DatabaseManager.GradTable ();
            gradoviComboBox.DataSource = gradTable;;
            gradoviComboBox.DisplayMember = "ime";
            gradoviComboBox.ValueMember = "postanskibroj";
            gradoviComboBox.SelectedIndex = 0;
        }
        private void FillMasterList () {
            if (lokacijaComboBox.SelectedItem == null || gradoviComboBox.SelectedItem == null)
                return;
            masterLista.DataSource = DatabaseManager.LokacijaTable (lokacijaComboBox.SelectedItem.ToString(), gradoviComboBox.SelectedValue.ToString());
            masterLista.DisplayMember = "naziv";
            masterLista.ValueMember = "sifra";
        }

        private void lokacijaComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            FillMasterList ();
        }
        private void gradoviComboBox_SelectedIndexChanged (object sender, EventArgs e) {
            FillMasterList ();
        }

        private void masterLista_MouseDoubleClick (object sender, MouseEventArgs e) {
            if (gradoviComboBox.SelectedItem == null)
                return;

            Logic.ILokacija lokacija = lokacijaComboBox.SelectedItem as Logic.ILokacija;
            lokacija.PrikaziInfo (int.Parse (masterLista.SelectedValue.ToString()));
            //showForm (Convert.ToInt32 (masterLista.SelectedValue), "info");
        }
        
        private void addBTN_Click (object sender, EventArgs e) {
            if (gradoviComboBox.SelectedItem == null)
                return;

            object selectedValue = gradoviComboBox.SelectedValue;
            Logic.ILokacija lokacija = lokacijaComboBox.SelectedItem as Logic.ILokacija;
            lokacija.Dodaj (int.Parse (selectedValue.ToString()));
            FillGradCB ();
            gradoviComboBox.SelectedValue = selectedValue;
        }
        private void editBTN_Click (object sender, EventArgs e) {
            if (masterLista.SelectedItem == null)
                return;

            object selectedValue = gradoviComboBox.SelectedValue;
            Logic.ILokacija lokacija = lokacijaComboBox.SelectedItem as Logic.ILokacija;
            lokacija.Izmijeni (int.Parse (masterLista.SelectedValue.ToString ()));
            FillGradCB ();
            gradoviComboBox.SelectedValue = selectedValue;

            //showForm (Convert.ToInt32 (masterLista.SelectedValue), "NewEdit");
        }
        private void deleteBTN_Click (object sender, EventArgs e) {
            if (masterLista.SelectedItem == null)
                return;

            if (MessageBox.Show ("Jeste li sigurni?", "Potvrda brisanja", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                Logic.ILokacija lokacija = lokacijaComboBox.SelectedItem as Logic.ILokacija;
                lokacija.Obrisi (int.Parse (masterLista.SelectedValue.ToString ()));
                FillMasterList ();
            }
        }

    }
}
