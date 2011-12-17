using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Bussines {
    class ZnamenitostLokacija : ILokacija {

        public void ShowUpdateForm (int id) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public void ShowInsertForm (int pbr) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }
        public override string ToString () {
            return "Znamenitost";
        }
        public static void InsertNew (Znamenitost znam) {
        }
        public static void Update (Znamenitost znam) {
        }
    }
}
