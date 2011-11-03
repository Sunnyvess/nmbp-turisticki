using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NMBP___OR.Logic {
    public class Znamenitost : Logic.ILokacija {
        public TipZnamenitosti tip;
        public DateTime datumIzgradnje;

        public void Obrisi () {
            throw new NotImplementedException ();
        }
        public void Izmijeni () {
            Presentation.ZnamenitostNewEdit znamemEdit = new Presentation.ZnamenitostNewEdit (this);
            znamemEdit.ShowDialog ();
            if (znamemEdit.accepted) {
                //izmijena u bazi i izmijena klase
            }        
        }
        public void PrikaziInfo () {
            Presentation.ZnamenitostInfo znamenInfo = new Presentation.ZnamenitostInfo (this);
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
