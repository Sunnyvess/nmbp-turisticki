﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml;

namespace turistickiXML.Bussines {
    class MuzejLokacija : ILokacija {

        public void ShowUpdateForm (int id) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public void ShowInsertForm (int pbr) {
            //pokrenuti formu nakon sto se implementira
            throw new NotImplementedException ();
        }

        public override string ToString () {
            return "Muzej";
        }
        public static void InsertNew (Muzej muzej) {
        }
        public static void Update (Muzej muzej) {
        }
    }
}