using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace turistickiXML.Business {
    class Znamenitost : Lokacija {
        public string TipZnamenitosti {
            get;
            set;
        }
        public string godinaIzgradnje
        {
            get;
            set;
        }
    }
}
