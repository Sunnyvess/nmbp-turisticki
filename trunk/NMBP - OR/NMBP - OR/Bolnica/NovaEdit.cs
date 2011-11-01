using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Bolnica {
    public partial class NovaEdit : Form {
        public Bolnica bolnica;
        public bool accepted = false;

        public NovaEdit () {
            InitializeComponent ();
            bolnica = new Bolnica ();
            this.Name = "Nova bolnica";
        }
        public NovaEdit (Bolnica bolnicaToEdit) {
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
