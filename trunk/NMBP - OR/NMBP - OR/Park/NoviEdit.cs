using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Park {
    public partial class NoviEdit : Form {
        public Park park;
        public bool accepted = false;

        public NoviEdit () {
            InitializeComponent ();
            park = new Park ();
            this.Name = "Novi park";
        }
        public NoviEdit (Park parkToEdit) {
            InitializeComponent ();
            park = parkToEdit;
            this.Name = "Izmjena parka";
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
