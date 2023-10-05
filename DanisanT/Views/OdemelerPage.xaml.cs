using DanisanT.Data;
using DanisanT.Views;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanisanT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OdemelerPage : ContentPage
    {
        int SeansGeliri = 0;
        int AtolyeGeliri = 0;
        int OfisGideri = 0;
        public OdemelerPage()
        {
            InitializeComponent();
            var realmDB = Realm.GetInstance();
            var MyOdeme = realmDB.All<Data.Odemeler>().ToList();

            // LstOdeme.ItemsSource = MyOdeme;
            ToplamSeans(realmDB);
            ToplamGelir(realmDB);
            ToplamOfisKirasi(realmDB);
            İptalSeansCount(realmDB);
            GenelToplam(realmDB);
           
            var odes = realmDB.All<Data.Odemeler>().ToList();
            odemeLİST.ItemsSource = odes;
        }

        private void LstOdeme_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void gnlMHS_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GenelMuhasebe());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Odemeler());
        }

        private async void iptaller_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new İptalSeanslar());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TarihlerArasiMuhasebe());
        }
        private void ToplamSeans(Realm baglanti)
        {
            var TSeans = baglanti.All<Seans>();
            var SeansCount = TSeans.Count();
            xToplamSeans.Text = SeansCount.ToString();
        }
        private void ToplamGelir(Realm Baglanti)
        {
            var Sirket = Baglanti.All<Data.Odemeler>().ToList();
            if (Sirket != null)
            {
                var toplamK = 0.0;
                foreach (var tgelir in Sirket)
                {
                    toplamK += tgelir.Odenen;
                }
                SeansGeliri = Convert.ToInt32(toplamK);
                double sonuc = (double)Convert.ToDecimal(toplamK);
                xToplamGelir.Text = sonuc.ToString("0,0") + "₺";
            }

        }
        private void ToplamOfisKirasi(Realm baglanti)
        {
            var Gider = baglanti.All<Data.OfisGider>().ToList();
            if (Gider != null)
            {
                var Tgider = 0.0;
                foreach (var item in Gider)
                {
                    Tgider += item.Kira;
                }
                double sonuc = Convert.ToDouble(Tgider);
                xToplamOkirasi.Text = sonuc.ToString("0,0") + "₺";
               
                OfisGideri = Convert.ToInt32(Tgider);
            }
            else
            {
                xToplamOkirasi.Text = "0" + "₺";
            }
        }
        private void İptalSeansCount(Realm baglanti) 
        {
            var TSeans = baglanti.All<Data.İptalSeans>();
            var SeansCount = TSeans.Count();
            İptalSeansx.Text = SeansCount.ToString();
        }
        private void GenelToplam(Realm baglanti)
        {

            int toplam = SeansGeliri + AtolyeGeliri;
            double sonuc = Convert.ToDouble( toplam - OfisGideri);


            geneltoplam.Text =  sonuc.ToString("0,0") + "₺";
        }

        private void genelBTN_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var MyOdeme = realmDB.All<Data.Odemeler>().ToList();
            // LstOdeme.ItemsSource = MyOdeme;
            ToplamSeans(realmDB);
            ToplamGelir(realmDB);
            ToplamOfisKirasi(realmDB);
            İptalSeansCount(realmDB);
            GenelToplam(realmDB);
            var odes = realmDB.All<Data.Odemeler>().ToList();
            odemeLİST.ItemsSource = odes;
        }

        private void AylikBTN_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            DateTime ayinIlkGunununTarihi = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime ayinSonGunununTarihi = ayinIlkGunununTarihi.AddMonths(1).AddDays(-1);
            Aylik_ToplamSeans(realmDB, ayinIlkGunununTarihi, ayinSonGunununTarihi);
            Aylik_ToplamGelir(realmDB, ayinIlkGunununTarihi, ayinSonGunununTarihi);
            Aylik_OfisKirasi(realmDB, ayinIlkGunununTarihi, ayinSonGunununTarihi);
            Aylik_İptal(realmDB, ayinIlkGunununTarihi, ayinSonGunununTarihi);
            Aylik_netGelir(realmDB, ayinIlkGunununTarihi, ayinSonGunununTarihi);
            
        }
        private void Aylik_ToplamSeans(Realm baglanti,DateTime ayinIlkGunununTarihi,DateTime ayinSonGunununTarihi)
        {

            List<string> tarihler = new List<string>();
           

            for (DateTime date = ayinIlkGunununTarihi; date <= ayinSonGunununTarihi; date = date.AddDays(1))
            {
                tarihler.Add(date.ToShortDateString());
            }
            var seanss = baglanti.All<Data.Seans>().ToList();
            List<string> seanslar = new List<string>();
            foreach (string item in tarihler)
            {
                foreach (var item1 in seanss)
                {
                    if (item1.Tarih == item)
                    {
                        seanslar.Add(item);
                    }
                }
            }
            
            var count = seanslar.Count();
            xToplamSeans.Text = count.ToString();
        }
        private void Aylik_ToplamGelir(Realm baglanti, DateTime ayinIlkGunununTarihi, DateTime ayinSonGunununTarihi)
        {

            List<string> tarihler = new List<string>();


            for (DateTime date = ayinIlkGunununTarihi; date <= ayinSonGunununTarihi; date = date.AddDays(1))
            {
                tarihler.Add(date.ToShortDateString());
            }
            var Odemeler = baglanti.All<Data.Odemeler>().ToList();
            List<string> seanslar = new List<string>();
            var toplamk = 0.0;
            foreach (string tarih in tarihler)
            {
                var filtrele = Odemeler.Where(o=> o.OdemeTarihi == tarih).ToList();
                foreach (var payment in filtrele)
                {
                   
                       
                        toplamk += payment.Odenen;
                        
                    
                }
            }
            SeansGeliri = Convert.ToInt32(toplamk);
            double sonuc = (double)Convert.ToDecimal(toplamk);
            xToplamGelir.Text = sonuc.ToString("0,0") + "₺";
        }
        private void Aylik_OfisKirasi(Realm baglanti,DateTime ayinIlkGunununTarihi,DateTime ayinSonGunununTarihi)
        {

            List<string> tarihler = new List<string>();


            for (DateTime date = ayinIlkGunununTarihi; date <= ayinSonGunununTarihi; date = date.AddDays(1))
            {
                tarihler.Add(date.ToShortDateString());
            }
            var Odemeler = baglanti.All<Data.Seans>().ToList();
            List<string> seanslar = new List<string>();
            var toplamk = 0.0;
            foreach (string tarih in tarihler)
            {
                var filtrele = Odemeler.Where(o => o.Tarih == tarih).ToList();
                foreach (var payment in filtrele)
                {


                    toplamk += payment.OfisOdeme;


                }
            }
            OfisGideri = Convert.ToInt32( toplamk);
            double sonuc = (double)Convert.ToDecimal(toplamk);
            xToplamOkirasi.Text = sonuc.ToString("0,0") + "₺";
        }
        private void Aylik_İptal(Realm baglanti, DateTime ayinIlkGunununTarihi, DateTime ayinSonGunununTarihi)
        {
            List<string> tarihler = new List<string>();


            for (DateTime date = ayinIlkGunununTarihi; date <= ayinSonGunununTarihi; date = date.AddDays(1))
            {
                tarihler.Add(date.ToShortDateString());
            }
            var seanss = baglanti.All<Data.İptalSeans>().ToList();
            List<string> seanslar = new List<string>();
            foreach (string item in tarihler)
            {
                foreach (var item1 in seanss)
                {
                    if (item1.SeansİptalTarihi == item)
                    {
                        seanslar.Add(item);
                    }
                }
            }

            var count = seanslar.Count();
            İptalSeansx.Text = count.ToString();
        }
        private void Aylik_netGelir(Realm baglanti, DateTime ayinIlkGunununTarihi, DateTime ayinSonGunununTarihi)
        {

            List<string> tarihler = new List<string>();


            for (DateTime date = ayinIlkGunununTarihi; date <= ayinSonGunununTarihi; date = date.AddDays(1))
            {
                tarihler.Add(date.ToShortDateString());
            }
            var Odemeler = baglanti.All<Data.Odemeler>().ToList();
            List<string> seanslar = new List<string>();
            var toplamk = 0.0;
            foreach (string tarih in tarihler)
            {
                var filtrele = Odemeler.Where(o => o.OdemeTarihi == tarih).ToList();
                foreach (var payment in filtrele)
                {
                    toplamk += payment.Odenen;

                }
            }
            
            double sonuc = (double)Convert.ToDecimal(toplamk)-OfisGideri;
            geneltoplam.Text = sonuc.ToString("0,0") + "₺";
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var realmdb = Realm.GetInstance();
            var iptaller = realmdb.All<Data.İptalSeans>().ToList();
            
            odemeLİST.ItemsSource = iptaller;
        }

        private void odenmeyenbtn_Clicked(object sender, EventArgs e)
        {
            var realmdb = Realm.GetInstance();
            var Odenmeyenler = realmdb.All<Data.Seans>().Where(s => s.Cash == "Ödenmedi").ToList();
            var Toplam_Odenmeyen = Odenmeyenler.Count();
            xToplamSeans.Text = Toplam_Odenmeyen.ToString();
            if (Odenmeyenler != null)
            {
                var ToplamBorc = 0.0;
                foreach (var item in Odenmeyenler)
                {
                    ToplamBorc += item.Odeme;
                }
                SeansGeliri = Convert.ToInt32(ToplamBorc);
                double sonuc = (double)Convert.ToDecimal(ToplamBorc);
                SeansGElir.Text = "Toplam Borç";
                xToplamGelir.Text = sonuc.ToString("0,0") + "₺";


                foreach (var item in Odenmeyenler)
                {
                    
                }
            }
            




            odemeLİST.ItemsSource = Odenmeyenler;
            odemeLİST.HeightRequest = 200;
            odemeLİST.Opacity = 0.5;
             
        }
    }
}
