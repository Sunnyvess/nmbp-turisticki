using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMBP___OR.Znamenitost {
    public partial class NoviEdit : Form {
        public Znamenitost znamen;
        public bool accepted = false;

        public NoviEdit () {
            InitializeComponent ();
            znamen = new Znamenitost ();
            this.Name = "Nova znamenitost";
            NapuniTipoveZnamenitosti ();
        }
        public NoviEdit (Znamenitost znamenitostToEdit) {
            InitializeComponent ();
            znamen = znamenitostToEdit;
            this.Name = "Izmjena znamenitosti";
            NapuniTipoveZnamenitosti ();
        }
        void NapuniTipoveZnamenitosti () {
            tipZnamenCB.Items.Clear ();
            foreach (TipZnamenitosti tip in Enum.GetValues (typeof (TipZnamenitosti))) {
                tipZnamenCB.Items.Add (tip.ToString ());
            }
        }
    }
}
