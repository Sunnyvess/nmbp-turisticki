using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace turistickiXML.DAL
{
    class XMLData
    {
        static DataSet ds = new DataSet();
        static DataView dv = new DataView();

        public static void save()
        {
            ds.WriteXml(".\\XML\\proba.xml", XmlWriteMode.WriteSchema);
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
            DataRow dr = Select(PostanskiBr);
            dr[1] = Ime;
            save();
        }

        public static DataRow Select(int PostanskiBr)
        {
            dv.RowFilter = "PostanskiBr='" + PostanskiBr + "'";
            dv.Sort = "PostanskiBr";
            DataRow dr = null;
            if (dv.Count > 0)
            {
                dr = dv[0].Row;
            }
            dv.RowFilter = "";
            return dr;
        }

        public static void Delete(int PostanskiBr)
        {
            dv.RowFilter = "PostanskiBr='" + PostanskiBr + "'";
            dv.Sort = "PostanskiBr";
            dv.Delete(0);
            dv.RowFilter = "";
            save();
        }

        public static DataView SelectAll()
        {
            ds.Clear();
            ds.ReadXml(".\\XML\\proba.xml", XmlReadMode.ReadSchema);
            dv = ds.Tables[0].DefaultView;
            return dv;
        }
    }
}
