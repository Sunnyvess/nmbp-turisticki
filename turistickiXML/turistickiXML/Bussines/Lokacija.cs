using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace turistickiXML.Bussines {
    class Lokacija {
        public int ID {
            get;
            set;
        }
        public string Naziv {
            get;
            set;
        }
        public string Opis {
            get;
            set;
        }
        public string RadnoVrijeme {
            get;
            set;
        }
        public string Ulica {
            get;
            set;
        }
        public int PostBr {
            get;
            set;
        }

        public Lokacija (int id, string naziv) {
            this.ID = id;
            this.Naziv = naziv;
        }
        public Lokacija () {
        }
        public override string ToString () {
            return this.Naziv;
        }
    }
}
