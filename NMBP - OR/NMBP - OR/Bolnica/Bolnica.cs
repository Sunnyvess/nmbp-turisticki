using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Bolnica {
    public class Bolnica : ILokacija {
        public bool dezurna = false;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            NovaEdit bolnicaEdit = new NovaEdit (this);
            bolnicaEdit.ShowDialog ();
            if (bolnicaEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }
        }
        public void PrikaziInfo () {
            Info bolnicaInfo = new Info (this);
            bolnicaInfo.ShowDialog ();
        }

        public override string ToString () {
            //return name;
            return base.ToString ();
        }
    }
}
