using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Bussines {
    class BolnicaLokacija : ILokacija {

        public void ShowUpdateForm (int id) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }
        public void ShowInsertForm (int pbr) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public override string ToString () {
            return "Bolnica";
        }

        public static void InsertNew (Bolnica bolnica) {
            DAL.XMLData.InsertBolnica (bolnica);
        }
        public static void Update (Bolnica bolnica) {
            DAL.XMLData.UpdateBolnica (bolnica);
        }
        public static Bolnica SelectBolnica (int id) {
            return DAL.XMLData.SelectBolnica (id);
        }
    }
}
