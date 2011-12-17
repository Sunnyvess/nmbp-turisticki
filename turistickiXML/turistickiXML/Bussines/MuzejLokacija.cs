using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Bussines {
    class MuzejLokacija : ILokacija {

        public void ShowUpdateForm (int id) {
            Presentation.BolnicaNewEdit editBolnica = new Presentation.BolnicaNewEdit (id);
            editBolnica.ShowDialog ();
        }

        public void ShowInsertForm (int pbr) {
            Presentation.BolnicaNewEdit newMuzej = new Presentation.BolnicaNewEdit ();
            newMuzej.ShowDialog ();
        }

        public override string ToString () {
            return "Muzej";
        }
        public static void InsertNew (Muzej muzej) {
        }
        public static void Update (Muzej muzej) {
        }
    }
}
