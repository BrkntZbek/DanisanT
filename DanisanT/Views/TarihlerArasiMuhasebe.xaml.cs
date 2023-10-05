using DanisanT.Data;
using Realms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanisanT.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TarihlerArasiMuhasebe : ContentPage
	{
        string tarih;
        
		public TarihlerArasiMuhasebe ()
		{
			InitializeComponent();

            var realmDB = Realm.GetInstance();
           

           


        }

        private void ToplamGelir(Realm Baglanti,string tarih)
        {
            // Tarihe GÖRE SEANSLARI GETİRİR.
            var Seans = Baglanti.All<Data.Seans>().Where(s=>s.Tarih == tarih);
            var ToplamSeans = Seans.Count();
            xToplamSeans.Text = ToplamSeans.ToString();
            // TARİHE GÖRE GELİRİ GETİRİR.
            var Odemeler = Baglanti.All<Data.Odemeler>().Where(s=>s.OdemeTarihi == tarih).ToList();
            if (Odemeler !=null)
            {
                var TK = 0.0;
                foreach (var item in Odemeler)
                {
                    TK += item.Odenen;
                }
                xToplamGelir.Text = TK.ToString()+ "₺";
            }
            
           


        }

        private void birTarih_DateSelected(object sender, DateChangedEventArgs e)
        {
         var realmdd = Realm.GetInstance();
            var Tarih = realmdd.All<Data.Seans>().ToList();

            tarih = e.NewDate.ToShortDateString();
        }

        private void ikiTarih_DateSelected(object sender, DateChangedEventArgs e)
        {
           
           
        }

        private void ara_Clicked(object sender, EventArgs e)
        {
           
           
        }
       
    }
}