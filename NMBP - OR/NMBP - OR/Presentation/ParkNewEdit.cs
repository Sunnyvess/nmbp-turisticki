using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Presentation {
    public partial class ParkNewEdit : Form {
        public Logic.Park park;
        public bool accepted = false;

        public ParkNewEdit () {
            InitializeComponent ();
            park = new Logic.Park ();
            this.Name = "Novi park";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ParkNewEdit (Logic.Park parkToEdit) {
            InitializeComponent ();
            park = parkToEdit;
            this.Name = "Izmjena parka";
            this.StartPosition = FormStartPosition.CenterScreen;
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
