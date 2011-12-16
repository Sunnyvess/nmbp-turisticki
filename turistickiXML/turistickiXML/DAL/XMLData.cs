using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.DAL
{
    class XMLData
    {
        static DataSet ds = new DataSet();
        static DataSet grad = new DataSet();
        static DataView dv = new DataView();
        static string filePath = "..\\..\\XML\\turistickiVodic.xml";

        public static void save()
        {
            ds.WriteXml(filePath, XmlWriteMode.WriteSchema);
        }

        public static void Insert(int PostanskiBr, string Ime)
        {
            DataRow dr = dv.Table.NewRow();
            dr[0] = PostanskiBr;
            dr[1] = Ime;
            dv.Table.Rows.Add(dr);
        }

        public static void Update(int PostanskiBr, string Ime)
        {
            //DataRow dr = Select(PostanskiBr);
            //dr[1] = Ime;
            //save();
        }

        public XmlNodeList Select(int PostanskiBr)
        {
            ds.Clear();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNodeList xnList = xml.SelectNodes("turistickiVodic/bolnice/bolnica[@pbr='"+ PostanskiBr.ToString() + "']");
            return xnList;


        }

        public static void Delete(int PostanskiBr)
        {
            dv.RowFilter = "PostanskiBr='" + PostanskiBr + "'";
            dv.Sort = "PostanskiBr";
            dv.Delete(0);
            dv.RowFilter = "";
            save();
        }

        public static DataTable SelectAll(string tablicaName)
        {
            if (tablicaName == "grad")
            {
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
    }
}
