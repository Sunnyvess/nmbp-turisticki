using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Muzej {
    public class Muzej : ILokacija {
        TipMuzeja tip;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            NoviEdit muzejEdit = new NoviEdit (this);
            muzejEdit.ShowDialog ();
            if (muzejEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }
        }
        public void PrikaziInfo () {
            Info muzejinfo = new Info (this);
            muzejinfo.ShowDialog ();
        }

        public override string ToString () {
            //return name;
            return base.ToString ();
        }
    }

    enum TipMuzeja {
        Prirodoslovni,
        Arheoloski,
        Tehnicki,
        Povjesni,
        Umjetnicki
    }
}
