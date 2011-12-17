using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace turistickiXML.Bussines {
    public interface ILokacija {
        void Delete (int id);
        void Update (int id);
        void Insert (int pbr);
    }
}
