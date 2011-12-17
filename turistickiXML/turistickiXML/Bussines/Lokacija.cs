using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace turistickiXML.Bussines {
    class Lokacija {
        public Lokacija (int id, string naziv) {
            this.ID = id;
            this.Naziv = naziv;
        }
        public int ID {
            get;
            set;
        }
        public string Naziv {
            get;
            set;
        }
        public override string ToString () {
            return this.Naziv;
        }
    }
}
