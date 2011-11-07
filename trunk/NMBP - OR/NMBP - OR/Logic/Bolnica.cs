using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Bolnica : ILokacija {
        public void Obrisi (int sifra) {
            NMBP___OR.DatabaseManager.DeleteLocation ("bolnica", sifra);
        }
        public void Izmijeni (int sifra) {
            NMBP___OR.Presentation.BolnicaNewEdit editBolnica = new NMBP___OR.Presentation.BolnicaNewEdit (sifra);
            editBolnica.ShowDialog ();
        }
        public void PrikaziInfo (int sifra) {
        }
        public void Dodaj (int postanskiBroj) {
            NMBP___OR.Presentation.BolnicaNewEdit editBolnica = new NMBP___OR.Presentation.BolnicaNewEdit (postanskiBroj.ToString());
            editBolnica.ShowDialog ();
        }

        public override string ToString () {
            return "Bolnica";
        }
    }
}
