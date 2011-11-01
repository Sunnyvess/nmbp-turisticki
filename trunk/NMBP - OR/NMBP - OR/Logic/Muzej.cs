using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Logic {
    public class Muzej : ILokacija {
        TipMuzeja tip;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            Presentation.MuzejNewEdit muzejEdit = new Presentation.MuzejNewEdit (this);
            muzejEdit.ShowDialog ();
            if (muzejEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }
        }
        public void PrikaziInfo () {
            Presentation.MuzejInfo muzejinfo = new Presentation.MuzejInfo (this);
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
