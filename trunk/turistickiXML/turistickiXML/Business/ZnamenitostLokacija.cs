using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Business {
    class ZnamenitostLokacija : ILokacija {

        public void ShowUpdateForm(int id)
        {
            Presentation.ZnamenitostNewEdit editZnamenitost = new Presentation.ZnamenitostNewEdit(id);
            editZnamenitost.ShowDialog();
        }
        public void ShowInsertForm(string pbr)
        {
            Presentation.ZnamenitostNewEdit newZnamenitost = new Presentation.ZnamenitostNewEdit(pbr);
            newZnamenitost.ShowDialog();
        }
        public void ShowInfoForm(int id)
        {
            Presentation.ZnamenitostInfo znamenitostInfo = new Presentation.ZnamenitostInfo(id);
            znamenitostInfo.ShowDialog();
        }
        public override string ToString()
        {
            return "Znamenitost";
        }

        public static void InsertNew(Znamenitost znam)
        {
            DAL.XMLData.InsertZnamenitost(znam);
        }
        public static void Update(Znamenitost znam)
        {
            DAL.XMLData.UpdateZnamenitost(znam);
        }
        public static Znamenitost SelectZnamenitost(int id)
        {
            return DAL.XMLData.SelectZnamenitost(id);
        }
    }
}
