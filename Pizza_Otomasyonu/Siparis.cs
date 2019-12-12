using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Otomasyonu
{
    class Siparis
    {
        public Pizza piz { get; set; }
        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

        public override string ToString()
        {
            string spr = "";
            spr += piz.Ebati.Adi + ",";
            spr += piz.Adi + ",";
            spr += piz.KenarTipi.Adi + ",";

            foreach (string mlz in piz.Malzemeler)
            {
                spr += string.Format("{0},", mlz);
            }
            spr = spr.Remove(spr.Length - 1, 1);
            spr += string.Format(" {0} X {1} = {2}", Adet, piz.Tutar, Adet * piz.Tutar);
            return spr;
        }
    }
}
