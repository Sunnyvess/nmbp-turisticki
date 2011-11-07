using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public interface ILokacija {
        void Dodaj (int postanskiBroj);
        void Obrisi (int sifra);
        void Izmijeni (int sifra);
        void PrikaziInfo (int sifra);
    }
}
