using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Presentation {
    public partial class BolnicaNewEdit : Form {
        public Logic.Bolnica bolnica;
        public bool accepted = false;

        public BolnicaNewEdit () {
            InitializeComponent ();
            bolnica = new Logic.Bolnica ();
            this.Name = "Nova bolnica";
        }
        public BolnicaNewEdit (Logic.Bolnica bolnicaToEdit) {
            InitializeComponent ();
            bolnica = bolnicaToEdit;
            this.Name = "Izmjena bolnice";
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
