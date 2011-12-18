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
        public DataTable GetGradList()

        {
            return XMLData.SelectGrad();
        }
    }
}
