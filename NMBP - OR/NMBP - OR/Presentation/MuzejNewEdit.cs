using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Presentation {
    public partial class MuzejNewEdit : Form {
        public Logic.Muzej muzej;
        public bool accepted = false;

        public MuzejNewEdit () {
            InitializeComponent ();
            muzej = new Logic.Muzej ();
            this.Name = "Novi muzej";
            NapuniTipMuzeja ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public MuzejNewEdit (Logic.Muzej muzejToEdit) {
            InitializeComponent ();
            muzej = muzejToEdit;
            this.Name = "Izmjena muzeja";
            NapuniTipMuzeja ();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        void NapuniTipMuzeja () {
            tipMuzejaCB.Items.Clear ();
            foreach (Logic.TipMuzeja tip in Enum.GetValues (typeof (Logic.TipMuzeja))) {
                tipMuzejaCB.Items.Add (tip.ToString());
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
