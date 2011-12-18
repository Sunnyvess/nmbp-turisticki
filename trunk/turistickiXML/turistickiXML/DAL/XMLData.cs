using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;
using turistickiXML.Bussines;

namespace turistickiXML.DAL
{
    class XMLData
    {
        static DataSet ds = new DataSet();
        static DataSet grad = new DataSet();
        static DataView dv = new DataView ();
        static XmlDocument xml;
        public static string filePath = "..\\..\\XML\\turistickiVodic.xml";

        public static void DeleteLocation (string location, int id) {
            XmlDocument document = new XmlDocument ();
            document.Load (filePath);
            XmlNode node = document.SelectSingleNode (string.Format ("/*/*/{0}[@id='{1}']", location.ToLower (), id));
            node.ParentNode.RemoveChild (node);
            document.Save (turistickiXML.DAL.XMLData.filePath);
        }

        public static int GetID(string nodePath) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            int maxID = 0;

            foreach (XmlNode n in doc.SelectNodes(nodePath))
            {

                int curr = int.Parse(n.Attributes[0].Value);

                if (maxID == 0 || curr > maxID)
                {

                    maxID = curr;

                }

            }
            
            return maxID+1;
        }

        #region Bolnica

        public static void InsertBolnica (Bolnica bolnicaNova) {
            xml = new XmlDocument ();
            xml.Load (filePath);

            XmlNode node = xml.CreateNode (XmlNodeType.Element, "bolnica", "");
            XmlElement bolnica = xml.CreateElement ("bolnica");
            XmlElement naziv = xml.CreateElement ("naziv");
            XmlElement ulica = xml.CreateElement ("ulica");
            XmlElement opis = xml.CreateElement ("opis");
            XmlElement radnoVrijeme = xml.CreateElement ("radnoVrijeme");
            XmlAttribute idBolnica = xml.CreateAttribute ("id");
            idBolnica.Value = GetID("*/*/bolnica").ToString();
            XmlAttribute pbr = xml.CreateAttribute ("pbr");
            pbr.Value = bolnicaNova.PostBr.ToString ();
            XmlAttribute dezurstvo = xml.CreateAttribute ("dezurstvo");
            dezurstvo.Value = bolnicaNova.Dezurna.ToString();
            XmlText nazivText = xml.CreateTextNode (bolnicaNova.Naziv);
            XmlText ulicaText = xml.CreateTextNode (bolnicaNova.Ulica);
            XmlText opisText = xml.CreateTextNode (bolnicaNova.Opis);
            XmlText radnoVrijemeText = xml.CreateTextNode (bolnicaNova.RadnoVrijeme);

            bolnica.Attributes.Append (idBolnica);
            bolnica.Attributes.Append (pbr);
            bolnica.Attributes.Append (dezurstvo);
            bolnica.AppendChild (naziv);
            bolnica.AppendChild (ulica);
            bolnica.AppendChild (opis);
            bolnica.AppendChild (radnoVrijeme);
            naziv.AppendChild (nazivText);
            ulica.AppendChild (ulicaText);
            opis.AppendChild (opisText);
            radnoVrijeme.AppendChild (radnoVrijemeText);
            xml.GetElementsByTagName ("bolnice")[0].AppendChild (bolnica);
            xml.Save (filePath);
        }
        public static void UpdateBolnica (Bolnica bolnica) {
            xml = new XmlDocument ();
            xml.Load (filePath);

            XmlNode node = xml.SelectSingleNode ("*/*/bolnica[@id='" + bolnica.ID.ToString () + "']");
            if (node != null) {
                node.Attributes[0].InnerText = bolnica.ID.ToString ();
                node.Attributes[1].InnerText = bolnica.PostBr.ToString ();
                node.Attributes[2].InnerText = bolnica.Dezurna.ToString ();

                node.ChildNodes[0].InnerText = bolnica.Naziv;
                node.ChildNodes[1].InnerText = bolnica.Ulica;
                node.ChildNodes[2].InnerText = bolnica.Opis;
                node.ChildNodes[3].InnerText = bolnica.RadnoVrijeme;
            }
            xml.Save (filePath);
        }
        public static Bolnica SelectBolnica (int id) {
            XmlDocument xml = new XmlDocument ();
            xml.Load (filePath);
            XmlNode node = xml.SelectSingleNode ("*/*/bolnica[@id='" + id.ToString () + "']");
            Bolnica bolnica = new Bolnica ();
            if (node != null) {
                bolnica.ID = Convert.ToInt32 (node.Attributes[0].InnerText);
                bolnica.PostBr = Convert.ToInt32 (node.Attributes[1].InnerText);
                bolnica.Dezurna = bool.Parse (node.Attributes[2].InnerText);

                bolnica.Naziv = node.ChildNodes[0].InnerText;
                bolnica.Ulica = node.ChildNodes[1].InnerText;
                bolnica.Opis = node.ChildNodes[2].InnerText;
                bolnica.RadnoVrijeme = node.ChildNodes[3].InnerText;
            }
            //Console.WriteLine("Odabrana bolnica" + bolnica.id.ToString());
            return bolnica;
        }

        #endregion

        public XmlNodeList Select(int PostanskiBr, string lokacija)
        {
            ds.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNodeList xnList = xml.SelectNodes("*/*/" + lokacija + "[@pbr='"+ PostanskiBr.ToString() + "']");
            return xnList;


        }   
        public static DataTable SelectAll(string tablicaName)
        {
            if (tablicaName == "grad")
            {
                grad.Clear();
                grad.ReadXml(filePath);
                return grad.Tables["grad"];
            }
            else
            {
                ds.Clear();
                ds.ReadXml(filePath);
                return ds.Tables[tablicaName];
            }
        }

        #region Pomocna funkcija....Ne brisati
        // Ko pipne ovu funkciju mrtav je.................Moje vlasnistvo!...................Daniel Kozul


        //public static DataTable ConvertXmlNodeListToDataTable(XmlNodeList xnl)
        //{
        //    DataTable dt = new DataTable();
        //    int TempColumn = 0;

        //    foreach (XmlNode node in xnl)
        //    {
        //        TempColumn++;
        //        DataColumn dc = new DataColumn(node.Name, System.Type.GetType("System.String"));
        //        if (dt.Columns.Contains(node.Name))
        //        {
        //            dt.Columns.Add(dc.ColumnName = dc.ColumnName + TempColumn.ToString());
        //        }
        //        else
        //        {
        //            dt.Columns.Add(dc);
        //        }
        //    }

        //    int ColumnsCount = dt.Columns.Count;
        //    for (int i = 0; i < xnl.Count; i++)
        //    {
        //        DataRow dr = dt.NewRow();
        //        for (int j = 0; j < ColumnsCount; j++)
        //        {
        //            dr[j] = xnl.Item(i).ChildNodes[j].InnerText;
        //        }
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
        #endregion
    }
}
