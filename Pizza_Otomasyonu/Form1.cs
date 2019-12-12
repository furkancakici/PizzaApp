using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Ebat Tanımlamaları.

            Ebat Kucuk = new Ebat { Adi = "KÜÇÜK BOY", Carpan = 1 };
            Ebat Orta = new Ebat { Adi = "ORTA BOY", Carpan = 1.25 };
            Ebat Buyuk = new Ebat { Adi = "BÜYÜK BOY", Carpan = 1.75 };
            Ebat Maxi = new Ebat { Adi = "MAXİ BOY", Carpan = 2 };
            cmbEbat.Items.Add(Kucuk);
            cmbEbat.Items.Add(Orta);
            cmbEbat.Items.Add(Buyuk);
            cmbEbat.Items.Add(Maxi);


            // Pizza Tanımlamaları.

            Pizza Klasik = new Pizza { Adi = "KLASİK PİZZA", Fiyat = 14 };
            Pizza Karisik = new Pizza { Adi = "KARIŞIK PİZZA", Fiyat = 17 };
            Pizza Turkish = new Pizza { Adi = "TURKISH PİZZA", Fiyat = 20 };
            Pizza Tuna = new Pizza { Adi = "TUNA PİZZA", Fiyat = 21 };
            Pizza Akdeniz = new Pizza { Adi = "AKDENİZ PİZZA", Fiyat = 19 };
            Pizza Karadeniz = new Pizza { Adi = "KARADENİZ PİZZA", Fiyat = 22 };
            listPizzalar.Items.Add(Klasik);
            listPizzalar.Items.Add(Karisik);
            listPizzalar.Items.Add(Turkish);
            listPizzalar.Items.Add(Tuna);
            listPizzalar.Items.Add(Akdeniz);
            listPizzalar.Items.Add(Karadeniz);


            // KenarTip Tanımlamaları.

            KenarTip İnceKenar = new KenarTip { Adi = "İNCE KENAR", EkFiyat = 0 };
            rdbInceKenar.Tag = İnceKenar;
            KenarTip KalınKenar = new KenarTip { Adi = "KALIN KENAR", EkFiyat = 2 };
            rdbKalinKenar.Tag = KalınKenar;

        }
        void Temizle()
        {
            cmbEbat.SelectedItem = 0;
           // listPizzalar.SelectedItem = -1;

            foreach (CheckBox ctrl in groupBox1.Controls)
            {
                ctrl.Checked = false;
            }
            lblTutar.Text = 0.ToString();
            nudAdet.Value = 0;
        }
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            Pizza pizza = (Pizza)listPizzalar.SelectedItem;
            pizza.Ebati = (Ebat)cmbEbat.SelectedItem;
            pizza.KenarTipi = rdbInceKenar.Checked ? (KenarTip)rdbInceKenar.Tag : (KenarTip)rdbKalinKenar.Tag;

            foreach (CheckBox ctrl in groupBox1.Controls)
            {
                if (ctrl.Checked)
                {
                    pizza.Malzemeler.Add(ctrl.Text);
                }
            }

            decimal araTutar = nudAdet.Value * pizza.Tutar;
            lblTutar.Text = araTutar.ToString();
            siparis = new Siparis();
            siparis.piz = pizza;
            siparis.Adet = (int)nudAdet.Value;
        }
        Siparis siparis;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (siparis != null)
            {
                listSepet.Items.Add(siparis);
            }
            Temizle();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int adet = 0;
            foreach (Siparis spr in listSepet.Items)
            {
                toplamTutar += spr.Adet * spr.piz.Tutar;
                adet++;
            }
            lblToplam.Text = toplamTutar.ToString();
            MessageBox.Show(string.Format("Toplam Sipariş Adediniz: {0} Toplam Sipariş Tutarınız: {1}",adet,toplamTutar));
        }
    }
}
