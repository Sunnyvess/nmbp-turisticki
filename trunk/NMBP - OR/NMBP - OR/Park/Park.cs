using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Park {
    public class Park : ILokacija {
        public bool otvoren = false;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            NoviEdit parkEdit = new NoviEdit (this);
            parkEdit.ShowDialog ();
            if (parkEdit.accepted) {
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
}
