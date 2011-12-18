using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Business {
    class BolnicaLokacija : ILokacija {

        public void ShowUpdateForm (int id) {
            Presentation.BolnicaNewEdit editBolnica = new Presentation.BolnicaNewEdit (id);
            editBolnica.ShowDialog ();
        }
        public void ShowInsertForm (string pbr) {
            Presentation.BolnicaNewEdit newBolnica = new Presentation.BolnicaNewEdit (pbr);
            newBolnica.ShowDialog ();
        }
        public void ShowInfoForm(int id)
        {
            Presentation.BolnicaInfo bolnicaInfo = new Presentation.BolnicaInfo(id);
            bolnicaInfo.ShowDialog();
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
