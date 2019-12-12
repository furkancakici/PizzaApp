using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Otomasyonu
{
    class Pizza
    {

        public Pizza()
        {
            Malzemeler = new List<string>();
        }

        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public Ebat Ebati { get; set; }
        public KenarTip KenarTipi { get; set; }
        public List<string> Malzemeler { get; set; }

        public decimal Tutar
        {
            get
            {
                decimal tutar = 0;
                tutar = (Fiyat * (decimal)Ebati.Carpan) + KenarTipi.EkFiyat;
                return tutar;
            }
        }

        public override string ToString() // Varsayılan metod ezilerek Adi propertysi yazdırılır.
        {
            return Adi;
        }
    }
}
