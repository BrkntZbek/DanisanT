using DanisanT.Data;
using DanisanT.Popup;
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

namespace DanisanT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupSeansPage : PopupPage
    {
        string RealDanisanName;
        int SeansId_;
        int DanisanId_;
        public PopupSeansPage(string DanisanName, int SeansId, int DanisanId)
        {
            InitializeComponent();
            RealDanisanName = DanisanName;
            SeansId_ = SeansId;
            DanisanId_ = DanisanId;
            var realmDB = Realm.GetInstance();

            var selectedDname = realmDB.All<Data.Seans>().First(a => a.SeansId == Convert.ToInt32(SeansId_));
            var SelectDanisaniID = realmDB.All<Data.Seans>().First(a => a.SeansDanisanId == Convert.ToInt32(DanisanId_));
            DNSisim.Text = selectedDname.Seans_İsimSoyisim.ToString();



            var NotVarmı = realmDB.All<Data.Notlar2>().FirstOrDefault(a=>a.Seans_ID == Convert.ToInt32(SeansId_));    
            if (NotVarmı == null)
            {
                NotlarBTN.IsEnabled = false;
                NotlarBTN.Text = "Notlar(0)";
            }
            else 
            {
                var nottLar = realmDB.All<Data.Notlar2>().Where(a=>a.Seans_ID == Convert.ToInt32(SeansId_));
                var NotCount = nottLar.Count();
                NotlarBTN.IsEnabled = true;
                NotlarBTN.Text = "Notlar"+ "("+NotCount.ToString()+")";
            }
        }

        private async void SeansekleBTN_Clicked(object sender, EventArgs e)
        {

            var realmDB = Realm.GetInstance();
            var selectedDname = realmDB.All<Data.Seans>().Where(a => a.SeansId == Convert.ToInt32(SeansId_)).FirstOrDefault(s=> s.SeansDanisanId == DanisanId_);

            var SeansFiyati = selectedDname.Odeme;
            string isimSoyisim = selectedDname.Seans_İsimSoyisim;
            string Tarih = selectedDname.Tarih;
            string saat = selectedDname.Saat;
            string cash = selectedDname.Cash;
            string seansturu = selectedDname.SeansTuru;
            string teleon = selectedDname.Seans_Telefon;
            int ofisodeme = selectedDname.OfisOdeme;

            var selectDanisani = realmDB.All<Data.Danisan>().FirstOrDefault(a => a.Id == Convert.ToInt32(DanisanId_));
            int borc = selectDanisani.Borc;
            var BakiyeVarmı = realmDB.All<Data.Bakiye>().FirstOrDefault(s => s.Danisan_ID == Convert.ToInt32(DanisanId_));
            string Ödendi = "Ödendi";
            string Ödenmedi = "Ödenmedi";
            try
            {
                bool sorgu = await DisplayAlert("UYARI", "Seansı iptal etmek istiyor musunuz?", "Evet", "Hayır");
                if (sorgu == true) 
                {
                    var İptalNo = 0;
                    var İptalSeans = realmDB.All<Data.İptalSeans>().ToList();
                    if (İptalSeans.Count != 0)
                    {
                        İptalNo = İptalSeans.Max(m => m.İptalID) + 1;
                    }

                    var Seansİptal = new Data.İptalSeans
                    {
                        İptalID = İptalNo,
                        SeansDanisanID = DanisanId_,
                        SeansDanisan_İsim = isimSoyisim,
                        SeansID = SeansId_,
                        Odeme = Convert.ToInt32(SeansFiyati),
                        SeansTarihi = Tarih,
                        SeansSaati = saat,
                        Cash = cash,
                        SeansTuru = seansturu,
                        Telefon = teleon,
                        SeansİptalTarihi = DateTime.Now.ToShortDateString(),
                        OfisOdeme = ofisodeme
                    };
                    realmDB.Write(() =>
                    {
                        realmDB.Add(Seansİptal);
                    });

                    using (var Db = realmDB.BeginWrite())
                    {
                        if (BakiyeVarmı == null || BakiyeVarmı.SeansSayisi == 0)
                        {
                            if (selectedDname.Cash == Ödenmedi)
                            {
                                selectDanisani.Borc = (borc - Convert.ToInt32(SeansFiyati));
                                selectDanisani.ToplamSeans--;
                            }
                            else if (selectedDname.Cash == Ödendi)
                            {
                                selectDanisani.Borc = (borc + 0);
                                selectDanisani.ToplamSeans--;



                            }
                        }
                        else
                        {
                            BakiyeVarmı.SeansSayisi++;
                        }

                        
                       
                        Db.Commit();
                    }

                    var ss = realmDB.All<Data.OfisGider>().Where(s => s.Seans_ID == selectedDname.SeansId).FirstOrDefault(s => s.SeansYeri == selectedDname.SeansTuru.ToString());
                    using (var db = realmDB.BeginWrite())
                    {
                        realmDB.Remove(ss);
                        realmDB.Remove(selectedDname);
                        db.Commit();
                    }


                    await DisplayAlert("Uyarı", "Seans İptal edildi.", "Tamam");


                    await Navigation.PopPopupAsync();
                }
                else
                {
                    return;
                }
               
               

               

            }
            catch (Exception)
            {
                await DisplayAlert("Püüü", "Bi Aksilik oldu bi ara bakıcam","Tamam");
                throw;
            }
        }

        private async void seaBilgibtn_Clicked(object sender, EventArgs e)
        {
            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new SeansBilgi(RealDanisanName, SeansId_));
            }
        }

        private void NotlarBTN_Clicked(object sender, EventArgs e)
        {

        }

        private async void NotlarBTN_Clicked_1(object sender, EventArgs e)
        {
            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new NotPopup(SeansId_, DanisanId_));
            }
        }

        private async void NotEkleBTN_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new NotEkle(SeansId_,DanisanId_,RealDanisanName));
          
        }

        private void OdemeYapmıs()
        {

        }
    }
}