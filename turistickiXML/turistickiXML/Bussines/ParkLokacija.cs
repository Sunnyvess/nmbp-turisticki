using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Bussines {
    class ParkLokacija : ILokacija {
        public void Delete (int id) {
            XmlDocument document = new XmlDocument ();
            document.Load (turistickiXML.DAL.XMLData.filePath);
            XmlNode node = document.SelectSingleNode ("*/*/park[@id='" + id.ToString () + "']");
            node.ParentNode.RemoveChild (node);
            document.Save (turistickiXML.DAL.XMLData.filePath);
        }

        public void Update (int id) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public void Insert (int pbr) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public override string ToString () {
            return "Park";
        }
    }
}
