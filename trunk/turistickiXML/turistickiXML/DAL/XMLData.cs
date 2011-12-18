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
        static XmlDocument xml;
        public static string filePath = "..\\..\\XML\\turistickiVodic.xml";

        public static void DeleteLocation (string location, int id) {
            XmlDocument document = new XmlDocument ();
            document.Load (filePath);
            XmlNode node = document.SelectSingleNode (string.Format ("/*/*/{0}[@id='{1}']", location.ToLower (), id));
            node.ParentNode.RemoveChild (node);
            document.Save (turistickiXML.DAL.XMLData.filePath);
        }

        public static int NewID(string nodePath)
        {
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
            
            return maxID + 1;
        }

        #region Bolnica

        public static void InsertBolnica (Bolnica bolnicaNova) {
            xml = new XmlDocument ();
            xml.Load (filePath);
            #region staro
            //XmlNode node = xml.CreateNode(XmlNodeType.Element, "bolnica", "");
            //XmlElement bolnica = xml.CreateElement("bolnica");
            //XmlElement naziv = xml.CreateElement("naziv");
            //XmlElement ulica = xml.CreateElement("ulica");
            //XmlElement opis = xml.CreateElement("opis");
            //XmlElement radnoVrijeme = xml.CreateElement("radnoVrijeme");
            //XmlAttribute idBolnica = xml.CreateAttribute("id");
            //idBolnica.Value = bolnicaNova.ID.ToString();
            //XmlAttribute pbr = xml.CreateAttribute("pbr");
            //pbr.Value = bolnicaNova.PostBr.ToString();
            //XmlAttribute dezurstvo = xml.CreateAttribute("dezurstvo");
            //dezurstvo.Value = bolnicaNova.Dezurna.ToString();
            //XmlText nazivText = xml.CreateTextNode(bolnicaNova.Naziv);
            //XmlText ulicaText = xml.CreateTextNode(bolnicaNova.Ulica);
            //XmlText opisText = xml.CreateTextNode(bolnicaNova.Opis);
            //XmlText radnoVrijemeText = xml.CreateTextNode(bolnicaNova.RadnoVrijeme);

            //bolnica.Attributes.Append(idBolnica);
            //bolnica.Attributes.Append(pbr);
            //bolnica.Attributes.Append(dezurstvo);
            //bolnica.AppendChild(naziv);
            //bolnica.AppendChild(ulica);
            //bolnica.AppendChild(opis);
            //bolnica.AppendChild(radnoVrijeme);
            //naziv.AppendChild(nazivText);
            //ulica.AppendChild(ulicaText);
            //opis.AppendChild(opisText);
            //radnoVrijeme.AppendChild(radnoVrijemeText);
            #endregion
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "bolnica", "");
            XmlElement bolnica = InsertLokacija(bolnicaNova, "bolnica", xml);
            XmlAttribute dezurstvo = xml.CreateAttribute("dezurstvo");
            dezurstvo.Value = bolnicaNova.Dezurna.ToString();
            bolnica.Attributes.Append(dezurstvo);
          
            xml.GetElementsByTagName ("bolnice")[0].AppendChild (bolnica);
            xml.Save (filePath);
        }
        public static void UpdateBolnica (Bolnica bolnica) {
            xml = new XmlDocument ();
            xml.Load (filePath);

            XmlNode node = UpdateLokacija(bolnica, "bolnica", xml);
            node.Attributes[2].InnerText = bolnica.Dezurna.ToString ();  
            xml.Save (filePath);
        }
        public static Bolnica SelectBolnica (int id) {
            XmlDocument xml = new XmlDocument ();
            xml.Load (filePath);
            Bolnica bolnica = new Bolnica ();
            XmlNode node = xml.SelectSingleNode ("*/*/bolnica[@id='" + id.ToString () + "']");
            
            if (node != null) {
                bolnica.ID = Convert.ToInt32 (node.Attributes[0].InnerText);
                bolnica.PostBr = Convert.ToInt32 (node.Attributes[1].InnerText);
                bolnica.Dezurna = bool.Parse (node.Attributes[2].InnerText);
           
                bolnica.Naziv = node.ChildNodes[0].InnerText;
                bolnica.Ulica = node.ChildNodes[1].InnerText;
                bolnica.Opis = node.ChildNodes[2].InnerText;
                bolnica.RadnoVrijeme = node.ChildNodes[3].InnerText;
            }
            return bolnica;
        }

        #endregion

        #region Muzej

        public static void InsertMuzej(Muzej muzejNovi)
        {
            xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "muzej", "");
            XmlElement muzej = InsertLokacija(muzejNovi, "muzej", xml);
            XmlAttribute tipMuzeja = xml.CreateAttribute("tipMuzeja");
            tipMuzeja.Value = muzejNovi.Tip;
            muzej.Attributes.Append(tipMuzeja);

            xml.GetElementsByTagName("muzeji")[0].AppendChild(muzej);
            xml.Save(filePath);
        }
        public static void UpdateMuzej(Muzej muzej)
        {
            xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode node = UpdateLokacija(muzej, "muzej", xml);
            node.Attributes[2].InnerText = muzej.Tip;
            xml.Save(filePath);
        }
        public static Muzej SelectMuzej(int id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            Muzej muzej = new Muzej();
            XmlNode node = xml.SelectSingleNode("*/*/muzej[@id='" + id.ToString() + "']");

            if (node != null)
            {
                muzej.ID = Convert.ToInt32(node.Attributes[0].InnerText);
                muzej.PostBr = Convert.ToInt32(node.Attributes[1].InnerText);
                muzej.Tip = node.Attributes[2].InnerText;

                muzej.Naziv = node.ChildNodes[0].InnerText;
                muzej.Ulica = node.ChildNodes[1].InnerText;
                muzej.Opis = node.ChildNodes[2].InnerText;
                muzej.RadnoVrijeme = node.ChildNodes[3].InnerText;
            }
            return muzej;
        }

        #endregion

        #region Park

        public static void InsertPark(Park parkNovi)
        {
            xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "park", "");
            XmlElement park = InsertLokacija(parkNovi, "park", xml);
            XmlAttribute otvoren = xml.CreateAttribute("otvoren");
            otvoren.Value = parkNovi.Otvoren.ToString();
            park.Attributes.Append(otvoren);

            xml.GetElementsByTagName("parkovi")[0].AppendChild(park);
            xml.Save(filePath);
        }
        public static void UpdatePark(Park park)
        {
            xml = new XmlDocument();
            xml.Load(filePath);

            XmlNode node = UpdateLokacija(park, "park", xml);
            node.Attributes[2].InnerText = park.Otvoren.ToString();
            xml.Save(filePath);
        }
        public static Park SelectPark(int id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            Park park = new Park();
            XmlNode node = xml.SelectSingleNode("*/*/park[@id='" + id.ToString() + "']");

            if (node != null)
            {
                park.ID = Convert.ToInt32(node.Attributes[0].InnerText);
                park.PostBr = Convert.ToInt32(node.Attributes[1].InnerText);
                park.Otvoren= bool.Parse(node.Attributes[2].InnerText);

                park.Naziv = node.ChildNodes[0].InnerText;
                park.Ulica = node.ChildNodes[1].InnerText;
                park.Opis = node.ChildNodes[2].InnerText;
                park.RadnoVrijeme = node.ChildNodes[3].InnerText;
            }
            return park;
        }

        #endregion

        #region Znamenitost

        public static void InsertZnamenitost(Znamenitost znamNova)
        {
            xml = new XmlDocument();
            xml.Load(filePath);
            XmlNode node = xml.CreateNode(XmlNodeType.Element, "znamenitost", "");
            XmlElement znam = InsertLokacija(znamNova, "znamenitost", xml);
            XmlAttribute tip = xml.CreateAttribute("tipZnamenitost");
            tip.Value = znamNova.TipZnamenitosti;
            znam.Attributes.Append(tip);
            XmlElement datum = xml.CreateElement("datumIzgradnje");
            XmlText datumText = xml.CreateTextNode(znamNova.godinaIzgradnje.ToString());
            znam.AppendChild(datum);
            datum.AppendChild(datumText);

            xml.GetElementsByTagName("znamenitosti")[0].AppendChild(znam);
            xml.Save(filePath);
        }
        public static void UpdateZnamenitost(Znamenitost znam)
        {
            xml = new XmlDocument();
            xml.Load(filePath);

            XmlNode node = UpdateLokacija(znam, "znamenitost", xml);
            node.Attributes[2].InnerText = znam.TipZnamenitosti;
            node.ChildNodes[4].InnerText = znam.godinaIzgradnje.ToString();
            xml.Save(filePath);
        }
        public static Znamenitost SelectZnamenitost(int id)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            Znamenitost znam = new Znamenitost();
            XmlNode node = xml.SelectSingleNode("*/*/znamenitost[@id='" + id.ToString() + "']");

            if (node != null)
            {
                znam.ID = Convert.ToInt32(node.Attributes[0].InnerText);
                znam.PostBr = Convert.ToInt32(node.Attributes[1].InnerText);
                znam.TipZnamenitosti = node.Attributes[2].InnerText;

                znam.Naziv = node.ChildNodes[0].InnerText;
                znam.Ulica = node.ChildNodes[1].InnerText;
                znam.Opis = node.ChildNodes[2].InnerText;
                znam.RadnoVrijeme = node.ChildNodes[3].InnerText;
                //znam.godinaIzgradnje = DateTime.Parse(node.ChildNodes[4].InnerText);
            }
            return znam;
        }


        #endregion

        #region Zajednicka Insert funkcija
        public static XmlElement InsertLokacija(Lokacija lokacija, string tip, XmlDocument xml)
        {
            XmlElement lokacija2 = xml.CreateElement(tip);
            XmlElement naziv = xml.CreateElement("naziv");
            XmlElement ulica = xml.CreateElement("ulica");
            XmlElement opis = xml.CreateElement("opis");
            XmlElement radnoVrijeme = xml.CreateElement("radnoVrijeme");
            XmlAttribute id = xml.CreateAttribute("id");
            id.Value = NewID("*/*/" + tip).ToString();
            XmlAttribute pbr = xml.CreateAttribute("pbr");
            pbr.Value = lokacija.PostBr.ToString();
            XmlText nazivText = xml.CreateTextNode(lokacija.Naziv);
            XmlText ulicaText = xml.CreateTextNode(lokacija.Ulica);
            XmlText opisText = xml.CreateTextNode(lokacija.Opis);
            XmlText radnoVrijemeText = xml.CreateTextNode(lokacija.RadnoVrijeme);

            lokacija2.Attributes.Append(id);
            lokacija2.Attributes.Append(pbr);
            
            lokacija2.AppendChild(naziv);
            lokacija2.AppendChild(ulica);
            lokacija2.AppendChild(opis);
            lokacija2.AppendChild(radnoVrijeme);
            naziv.AppendChild(nazivText);
            ulica.AppendChild(ulicaText);
            opis.AppendChild(opisText);
            radnoVrijeme.AppendChild(radnoVrijemeText);
            return lokacija2;
        }
        #endregion

        #region Zajednicka Update funkcija
        public static XmlNode UpdateLokacija(Lokacija lokacija, string tip, XmlDocument xml)
        {
            XmlNode node = xml.SelectSingleNode("*/*/" + tip + "[@id='" + lokacija.ID.ToString() + "']");
            if (node != null)
            {
                node.Attributes[0].InnerText = lokacija.ID.ToString();
                node.Attributes[1].InnerText = lokacija.PostBr.ToString();
                node.ChildNodes[0].InnerText = lokacija.Naziv;
                node.ChildNodes[1].InnerText = lokacija.Ulica;
                node.ChildNodes[2].InnerText = lokacija.Opis;
                node.ChildNodes[3].InnerText = lokacija.RadnoVrijeme;
            }
            return node;
        }
        #endregion

        //public static Lokacija SelectLokacija(Lokacija lokacija, XmlNode node)
        //{
        //    if (node != null)
        //    {
        //        lokacija.ID = Convert.ToInt32(node.Attributes[0].InnerText);
        //        lokacija.PostBr = Convert.ToInt32(node.Attributes[1].InnerText);
                
        //        lokacija.Naziv = node.ChildNodes[0].InnerText;
        //        lokacija.Ulica = node.ChildNodes[1].InnerText;
        //        lokacija.Opis = node.ChildNodes[2].InnerText;
        //        lokacija.RadnoVrijeme = node.ChildNodes[3].InnerText;
        //    }
        //    return lokacija;
        //}
        
        public XmlNodeList Select(int PostanskiBr, string lokacija)
        {
            ds.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNodeList xnList = xml.SelectNodes("*/*/" + lokacija + "[@pbr='"+ PostanskiBr.ToString() + "']");
            return xnList;
        }
        public static DataTable SelectGrad()
        {
            grad.Clear();
            grad.ReadXml(filePath);
            return grad.Tables["grad"];
        }
        public static DataTable SelectAll(string tablicaName)
        {
            ds.Clear();
            ds.ReadXml(filePath);
            return ds.Tables[tablicaName];
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
