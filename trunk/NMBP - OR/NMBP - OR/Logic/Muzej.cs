using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Muzej : ILokacija {
        public void Obrisi (int sifra) {
            NMBP___OR.DatabaseManager.DeleteLocation ("muzej", sifra);
        }
        public void Izmijeni (int sifra) {
            NMBP___OR.Presentation.MuzejNewEdit editMuzej = new NMBP___OR.Presentation.MuzejNewEdit (sifra);
            editMuzej.ShowDialog ();
        }
        public void PrikaziInfo (int sifra) {
            NMBP___OR.Presentation.MuzejInfo infoMuzej = new NMBP___OR.Presentation.MuzejInfo (sifra);
            infoMuzej.ShowDialog ();
        }
        public void Dodaj (int postanskiBroj) {
            NMBP___OR.Presentation.MuzejNewEdit newMuzej = new NMBP___OR.Presentation.MuzejNewEdit (postanskiBroj.ToString ());
            newMuzej.ShowDialog ();
        }

        public override string ToString () {
            return "Muzej";
        }
    }
}
