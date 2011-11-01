using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Presentation {
    public partial class ZnamenitostNewEdit : Form {
        public Logic.Znamenitost znamen;
        public bool accepted = false;

        public ZnamenitostNewEdit () {
            InitializeComponent ();
            znamen = new Logic.Znamenitost ();
            this.Name = "Nova znamenitost";
            NapuniTipoveZnamenitosti ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ZnamenitostNewEdit (Logic.Znamenitost znamenitostToEdit) {
            InitializeComponent ();
            znamen = znamenitostToEdit;
            this.Name = "Izmjena znamenitosti";
            NapuniTipoveZnamenitosti ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        void NapuniTipoveZnamenitosti () {
            tipZnamenCB.Items.Clear ();
            foreach (Logic.TipZnamenitosti tip in Enum.GetValues (typeof (Logic.TipZnamenitosti))) {
                tipZnamenCB.Items.Add (tip.ToString ());
            }
        }

        private void prihvatiBTN_Click (object sender, EventArgs e) {
            accepted = true;
            this.Close ();
        }
        private void odustaniBTN_Click (object sender, EventArgs e) {
            accepted = false;
            this.Close ();
        }
    }
}
