using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Logic {
    public class Park : ILokacija {
        public bool otvoren = false;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            Presentation.ParkNewEdit parkEdit = new Presentation.ParkNewEdit (this);
            parkEdit.ShowDialog ();
            if (parkEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }
        }
        public void PrikaziInfo () {
            Presentation.ParkInfo muzejinfo = new Presentation.ParkInfo (this);
            muzejinfo.ShowDialog ();
        }

        public override string ToString () {
            //return name;
            return base.ToString ();
        }
    }
}
