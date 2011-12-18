using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using turistickiXML.DAL;

namespace turistickiXML.Bussines
{
    class GradList
    {
        //public static Grad GetGrad(int PostanskiBr)
        //{
        //    DataRow iDr = null;
        //    //iDr = XMLData.Select(PostanskiBr);
        //    Grad gr = null;
        //    if (iDr != null)
        //    {
        //        gr = new Grad();
        //        gr.PostanskiBr = Convert.ToInt32(iDr[0]);
        //        gr.Ime = iDr[1].ToString();
        //    }

        //    return gr;
        //}


        public DataTable GetGradList()

        {

            return XMLData.SelectGrad();

        }

        //public static void UpdateGrad(Grad grad)
        //{
        //    //XMLData.Update(grad.PostanskiBr, grad.Ime);
        //}

        //public static void InsertGrad(Grad grad)
        //{
        //    //XMLData.Insert(grad.PostanskiBr, grad.Ime);
        //}

        //public static void DeleteGrad(Grad grad)
        //{
        //    //XMLData.Delete(grad.PostanskiBr);
        //}

    }
}
