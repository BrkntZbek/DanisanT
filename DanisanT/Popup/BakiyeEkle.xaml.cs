using Realms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanisanT.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BakiyeEkle : PopupPage
    {
        int Danisan_ID;
        public BakiyeEkle(int DanisanID)
        {
            InitializeComponent();
            Danisan_ID = DanisanID;
        }

        private async void BakiyeEkle1BTN_Clicked(object sender, EventArgs e)
        {
            var realmdb = Realm.GetInstance();
            var MYOdeme = realmdb.All<Data.Odemeler>().ToList();
            var Bakiye = realmdb.All<Data.Bakiye>().ToList();
            var Bakiyebul = realmdb.All<Data.Bakiye>().FirstOrDefault(s => s.Danisan_ID == Danisan_ID);
            int OdemeIDs = 0;
            if (MYOdeme.Count != 0)
            {
                OdemeIDs = MYOdeme.Max(s => s.OdemeID) + 1;
            }
            var Danisan = realmdb.All<Data.Danisan>().FirstOrDefault(s => s.Id == Danisan_ID);
           var OdemeEkle = new Data.Odemeler
            {
                OdemeID = OdemeIDs,
                Odeyen_Danisan = Danisan.İsimSoyisim,
                Odeyen_Danisan_ID = Danisan_ID,
                Odenen = Convert.ToInt32(bakiyeİnt.Text),
                OdemeNotu = "",
                OdemeTarihi = DateTime.Now.ToShortDateString()

            };
            realmdb.Write(() =>
            {
                realmdb.Add(OdemeEkle);
            });
          
            int bakiyeID = 0;
            if (Bakiye.Count != 0)
            {
                bakiyeID = Bakiye.Max(s=>s.ID) + 1;
            }
            if (Bakiyebul == null)
            {
                var bakiyeekle = new Data.Bakiye
                {
                    ID = bakiyeID,
                    Danisan_ID = Danisan_ID,
                    OdemeTarihi = DateTime.Now.ToShortDateString(),
                    Toplambakiye = Convert.ToInt32(bakiyeİnt.Text),
                    SeansSayisi = Convert.ToInt32(seansİnt.Text),
                    SeansFiyati = Convert.ToInt32(Fiyatİnt.Text)
                };
                realmdb.Write(() =>
                {
                    realmdb.Add(bakiyeekle);
                });
            }
            else
            {
               
                int sayi = Convert.ToInt32(Bakiyebul.SeansSayisi);
                using (var db = realmdb.BeginWrite())
                {
                    Bakiyebul.SeansSayisi = sayi+Convert.ToInt32(seansİnt);
                    db.Commit();
                }
            }
           
            await DisplayAlert("Toplu Ödeme Kaydedilmiştir.", "Toplu Ödemeler Danışan Seans aldıkça sistemden otomatik düşecektir.", "Tamam");
            await Navigation.PopPopupAsync();
        }

        private async void Vazcay1BTN_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}