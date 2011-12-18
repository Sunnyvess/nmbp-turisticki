using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Business {
    class ParkLokacija : ILokacija {

        public void ShowUpdateForm(int id)
        {
            Presentation.ParkNewEdit editPark = new Presentation.ParkNewEdit(id);
            editPark.ShowDialog();
        }
        public void ShowInsertForm(string pbr)
        {
            Presentation.ParkNewEdit newPark = new Presentation.ParkNewEdit(pbr);
            newPark.ShowDialog();
        }
        public void ShowInfoForm(int id)
        {
            Presentation.ParkInfo ParkInfo = new Presentation.ParkInfo(id);
            ParkInfo.ShowDialog();
        }
        public override string ToString()
        {
            return "Park";
        }

        public static void InsertNew(Park park)
        {
            DAL.XMLData.InsertPark(park);
        }
        public static void Update(Park park)
        {
            DAL.XMLData.UpdatePark(park);
        }
        public static Park SelectPark(int id)
        {
            return DAL.XMLData.SelectPark(id);
        }
    }
}
