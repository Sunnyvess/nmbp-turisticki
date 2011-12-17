using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Bussines {
    class ParkLokacija : ILokacija {

        public void ShowUpdateForm (int id) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public void ShowInsertForm (int pbr) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public override string ToString () {
            return "Park";
        }
        public static void InsertNew (Park park) {
        }
        public static void Update (Park park) {
        }
    }
}
