using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Otomasyonu
{
    class Ebat
    {
        public string Adi { get; set; }
        public double Carpan { get; set; }

        public override string ToString() // Varsayılan metod ezilerek Adi propertysi yazdırılır.
        {
            return Adi;
        }
    }
}
