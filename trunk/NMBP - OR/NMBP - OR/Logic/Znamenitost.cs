using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Znamenitost : ILokacija {
        public void Obrisi (int sifra) {
            NMBP___OR.DatabaseManager.DeleteLocation ("znamenitost", sifra);
        }
        public void Izmijeni (int sifra) {
            NMBP___OR.Presentation.ZnamenitostNewEdit editZnamen = new NMBP___OR.Presentation.ZnamenitostNewEdit (sifra);
            editZnamen.ShowDialog ();
        }
        public void PrikaziInfo (int sifra) {
        }
        public void Dodaj (int postanskiBroj) {
            NMBP___OR.Presentation.ZnamenitostNewEdit editZnamen = new NMBP___OR.Presentation.ZnamenitostNewEdit (postanskiBroj.ToString());
            editZnamen.ShowDialog ();
        }

        public override string ToString () {
            return "Znamenitost";
        }
    }
}
