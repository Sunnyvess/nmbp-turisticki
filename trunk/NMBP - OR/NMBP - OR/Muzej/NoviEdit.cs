using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Muzej {
    public partial class NoviEdit : Form {
        public Muzej muzej;
        public bool accepted = false;

        public NoviEdit () {
            InitializeComponent ();
            muzej = new Muzej ();
            this.Name = "Novi muzej";
            NapuniTipMuzeja ();
        }
        public NoviEdit (Muzej muzejToEdit) {
            InitializeComponent ();
            muzej = muzejToEdit;
            this.Name = "Izmjena muzeja";
            NapuniTipMuzeja ();
        }
        void NapuniTipMuzeja () {
            tipMuzejaCB.Items.Clear ();
            foreach (TipMuzeja tip in Enum.GetValues (typeof (TipMuzeja))) {
                tipMuzejaCB.Items.Add (tip.ToString());
            }
        }
    }
}
