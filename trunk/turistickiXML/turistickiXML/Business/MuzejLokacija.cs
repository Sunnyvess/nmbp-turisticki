using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Business {
    class MuzejLokacija : ILokacija {

        public void ShowUpdateForm(int id)
        {
            Presentation.MuzejNewEdit editMuzej = new Presentation.MuzejNewEdit(id);
            editMuzej.ShowDialog();
        }
        public void ShowInsertForm(string pbr)
        {
            Presentation.MuzejNewEdit newMuzej = new Presentation.MuzejNewEdit(pbr);
            newMuzej.ShowDialog();
        }
        public void ShowInfoForm(int id)
        {
            Presentation.MuzejInfo MuzejInfo = new Presentation.MuzejInfo(id);
            MuzejInfo.ShowDialog();
        }
        public override string ToString()
        {
            return "Muzej";
        }

        public static void InsertNew(Muzej muzej)
        {
            DAL.XMLData.InsertMuzej(muzej);
        }
        public static void Update(Muzej muzej)
        {
            DAL.XMLData.UpdateMuzej(muzej);
        }
        public static Muzej SelectMuzej(int id)
        {
            return DAL.XMLData.SelectMuzej(id);
        }
    }
}
