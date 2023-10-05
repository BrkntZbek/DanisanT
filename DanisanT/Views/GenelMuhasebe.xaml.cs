using DanisanT.Data;
using Realms;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanisanT.Views
{
    
	[XamlCompilation(XamlCompilationOptions.Compile)]
    
	
    public partial class GenelMuhasebe : ContentPage
	{
        int SeansGeliri = 0;
        int AtolyeGeliri = 0;
        int OfisGideri = 0;
		public GenelMuhasebe ()
		{
			InitializeComponent ();
            var realmdb = Realm.GetInstance();
            ToplamSeans(realmdb);
            ToplamGelir(realmdb);
            ErkekDanisan(realmdb);
            KadinDanisan(realmdb);
            ToplamOfisKirasi(realmdb);
            Atolye(realmdb);
            AtolyeGelir(realmdb);
            GenelToplam(realmdb);
        }

        private  void cks_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushPopupAsync();
        }

		private void ToplamSeans(Realm Baglanti)
		{
            
            var TSeans = Baglanti.All<Seans>();
            var SeansCount = TSeans.Count();
            xToplamSeans.Text =SeansCount.ToString();
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
                SeansGeliri = Convert.ToInt32( toplamK);
                xToplamGelir.Text = toplamK.ToString() + "₺";
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
                xToplamOkirasi.Text = Tgider.ToString() + "₺";
                OfisGideri = Convert.ToInt32( Tgider ); 
            }
            else
            {
                xToplamOkirasi.Text = "0" + "₺";
            }
        }
        private void ErkekDanisan(Realm baglanti)
        {
            var Erkek = baglanti.All<Danisan>().Where(x => x.Cinsiyet == "Erkek").Count();
           
            xErkek.Text =  Erkek.ToString();
        }
        private void KadinDanisan(Realm baglanti)
        {
            var Erkek = baglanti.All<Danisan>().Where(x => x.Cinsiyet == "Kadın").Count();

            xKadin.Text = Erkek.ToString();
        }
       
        private void Atolye (Realm baglanti)
        {

            var TSeans = baglanti.All<Atolye2>();
            var SeansCount = TSeans.Count();
            xAsayisi.Text = SeansCount.ToString();
        }
        private void AtolyeGelir(Realm baglanti)
        {
            var atolye = baglanti.All<AtolyeKatilimci>().ToList();
            if (atolye != null)
            {
                var ToplamK = 0.0;
                foreach (var item in atolye)
                {
                    ToplamK += item.Odeme;
                }
                AtolyeGeliri = Convert.ToInt32(ToplamK);
                xAgeliri.Text = ToplamK.ToString() + "₺";
            }
            
            
        }
       
        private void GenelToplam(Realm baglanti)
        {

            int toplam = SeansGeliri + AtolyeGeliri;
            int sonuc = toplam - OfisGideri;


            geneltoplam.Text = sonuc.ToString() + "₺";
            }
        }
    }
