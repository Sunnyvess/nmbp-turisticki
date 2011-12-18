using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace turistickiXML.Bussines {
    public interface ILokacija {
        void ShowUpdateForm (int id);
        void ShowInsertForm (string pbr);
        void ShowInfoForm(int id);
    }
}
