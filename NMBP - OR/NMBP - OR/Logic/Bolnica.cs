using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Logic {
    public class Bolnica : Logic.ILokacija {
        public bool dezurna = false;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            Presentation.BolnicaNewEdit bolnicaEdit = new Presentation.BolnicaNewEdit (this);
            bolnicaEdit.ShowDialog ();
            if (bolnicaEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }
        }
        public void PrikaziInfo () {
            Presentation.BolnicaInfo bolnicaInfo = new Presentation.BolnicaInfo (this);
            bolnicaInfo.ShowDialog ();
        }

        public override string ToString () {
            //return name;
            return base.ToString ();
        }
    }
}
