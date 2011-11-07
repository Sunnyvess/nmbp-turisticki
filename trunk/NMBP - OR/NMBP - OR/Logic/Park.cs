using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Park : ILokacija {
        public void Obrisi (int sifra) {
            NMBP___OR.DatabaseManager.DeleteLocation ("park", sifra);
        }
        public void Izmijeni (int sifra) {
            NMBP___OR.Presentation.ParkNewEdit editPark = new NMBP___OR.Presentation.ParkNewEdit (sifra);
            editPark.ShowDialog ();
        }
        public void PrikaziInfo (int sifra) {
        }
        public void Dodaj (int postanskiBroj) {
            NMBP___OR.Presentation.ParkNewEdit editPark = new NMBP___OR.Presentation.ParkNewEdit (postanskiBroj.ToString());
            editPark.ShowDialog ();
        }

        public override string ToString () {
            return "Park";
        }
    }
}
