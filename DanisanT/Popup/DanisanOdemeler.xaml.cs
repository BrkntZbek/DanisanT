using DanisanT.Data;
using Realms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace DanisanT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DanisanOdemeler : PopupPage
    {
        string Danisan;
        int ID;
        int YatıralacakPara;
        int SeansID;
        public DanisanOdemeler(string DanisanName, int DanisanID)
        {

            InitializeComponent();
            Danisan = DanisanName;
            ID = DanisanID;
            var RealmDB = Realm.GetInstance();
            var Odemeler = RealmDB.All<Data.Odemeler>().Where(a => a.Odeyen_Danisan == DanisanName).ToList();

            ısm.Text = Danisan.ToString();
            var realmdb = Realm.GetInstance();
            var Odenmemisler = realmdb.All<Data.Seans>().Where(x => x.Seans_İsimSoyisim == Danisan).Where(d => d.Cash == "Ödenmedi").ToList();

            OdList.ItemsSource = Odenmemisler;
            OdList.IsEnabled = true;
            ///
            var Borc = RealmDB.All<Data.Danisan>().FirstOrDefault(a => a.İsimSoyisim == DanisanName).Borc;
            BorcTXT.Text = Borc.ToString()+ "₺";


            if (OdList.SelectedItem == null)
            {
                Odemeyap.IsEnabled = false;

            }
            var od = realmdb.All<Data.Danisan>().FirstOrDefault(a => a.Id == ID);
            if (od != null)
            {
                var Payment = realmdb.All<Data.Odemeler>().Where(p => p.Odeyen_Danisan_ID == od.Id).ToList();
                var Toplamodmee = 0.0;
                foreach (var payment in Payment)
                {
                    Toplamodmee += payment.Odenen;  /// TOPLAM ÖDEME
                }
                TodemeTXT.Text = Toplamodmee.ToString()+"₺";
            }
            





       }         

        private void OdList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private async  void Odemeyap_Clicked(object sender, EventArgs e)
        {
            try
            {
                var RealmDbx = Realm.GetInstance();
                var MYOdeme = RealmDbx.All<Data.Odemeler>().ToList();
                int OdemeNo = 0;
                if (OdList.SelectedItem == null)
                {
                    await DisplayAlert("Uyarı", "Ödenecek Seansı Seçiniz.", "Tamam");
                }
                else
                {
                    if (MYOdeme.Count != 0)
                    {
                        OdemeNo = MYOdeme.Max(m => m.OdemeID) + 1;
                    }

                    var OdemeEkle = new Data.Odemeler
                    {
                        OdemeID = OdemeNo,
                        Odeyen_Danisan = Danisan.ToString(),
                        Odeyen_Danisan_ID = ID,
                        Odenen = YatıralacakPara,
                        OdemeNotu = " ",
                        OdemeTarihi =  DateTime.Now.ToShortDateString(),
                    };
                    RealmDbx.Write(() =>
                    {
                        RealmDbx.Add(OdemeEkle);
                    });

                    var SelectedSEANS = RealmDbx.All<Seans>().FirstOrDefault(a => a.SeansId == SeansID);
                    using (var db = RealmDbx.BeginWrite())
                    {
                        SelectedSEANS.Cash = "Ödendi";
                        db.Commit();
                    }
                    var SelectedDanisan = RealmDbx.All<Danisan>().First(a => a.Id == ID);
                    var borc = SelectedDanisan.Borc;
                    using (var db = RealmDbx.BeginWrite())
                    {
                        SelectedDanisan.Borc = Convert.ToInt32( borc) -Convert.ToInt32( YatıralacakPara);
                        db.Commit();
                    }
                   
                }
                await DisplayAlert("BAŞARILI", "Ödeme Yapılmıştır.", "Tamam");
                Goster(Danisan, ID);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void Odenmeyen_Clicked(object sender, EventArgs e)
        {

          

        }

        private void Odenen_Clicked(object sender, EventArgs e)
        {
           

        }

        private async void RefreshView12_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            RefreshView12.IsRefreshing = false;
        }

        private void LblTArih_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

      

        private async void OdList_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {

            await Task.Delay(10);
            this.OdList.SeparatorColor = Color.Red;
            if (e != null)
            {
                Odemeyap.IsEnabled = true;
            }
            else if (e == null)
            {
                Odemeyap.IsEnabled = false;
            }
            var yt = (Seans)e.SelectedItem;
            YatıralacakPara = Convert.ToInt32( yt.Odeme); 
            var SeaId = (Seans)e.SelectedItem;
            SeansID = SeaId.SeansId;
        }

        private async void Vazgec_Clicked(object sender, EventArgs e)
        {

            await Navigation.PopPopupAsync();
        }
        private void Goster(string DanisanName, int DanisanID)
        {
            Danisan = DanisanName;
            ID = DanisanID;
            var RealmDB = Realm.GetInstance();
            var Odemeler = RealmDB.All<Data.Odemeler>().Where(a => a.Odeyen_Danisan == DanisanName).ToList();

            ısm.Text = Danisan.ToString();
            var realmdb = Realm.GetInstance();
            var Odenmemisler = realmdb.All<Data.Seans>().Where(x => x.Seans_İsimSoyisim == Danisan).Where(d => d.Cash == "Ödenmedi").ToList();

            OdList.ItemsSource = Odenmemisler;
            OdList.IsEnabled = true;
            ///
            var Borc = RealmDB.All<Data.Danisan>().FirstOrDefault(a => a.İsimSoyisim == DanisanName).Borc;
            BorcTXT.Text = Borc.ToString()+ "₺";

            var od = realmdb.All<Data.Danisan>().FirstOrDefault(a => a.Id == ID);
            if (od != null)
            {
                var Payment = realmdb.All<Data.Odemeler>().Where(p => p.Odeyen_Danisan_ID == od.Id).ToList();
                var Toplamodmee = 0.0;
                foreach (var payment in Payment)
                {
                    Toplamodmee += payment.Odenen;  /// TOPLAM ÖDEME
                }
                TodemeTXT.Text = Toplamodmee.ToString() + "₺";
            }

            if (OdList.SelectedItem == null)
            {
                Odemeyap.IsEnabled = false;

            }

        }
    }
}