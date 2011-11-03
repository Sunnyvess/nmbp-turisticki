using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic {
    public class Znamenitost : ILokacija {
        public TipZnamenitosti tip;
        public DateTime datumIzgradnje;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            NoviEdit znamemEdit = new NoviEdit (this);
            znamemEdit.ShowDialog ();
            if (znamemEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }        
        }
        public void PrikaziInfo () {
            Info znamenInfo = new Info (this);
            znamenInfo.ShowDialog ();
        }

        public override string ToString () {
            //return name;
            return base.ToString ();
        }
    }

    public enum TipZnamenitosti {
        Tvrdjava,
        Spomenik,
        Crkva
    }
}
