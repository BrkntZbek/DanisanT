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
    public partial class SeansYeriEkle : PopupPage
    {
        int turId;
        public SeansYeriEkle()
        {
            InitializeComponent();
            Goster();
        }

        private async void ekle_Clicked(object sender, EventArgs e)
        {
            var RealmDB = Realm.GetInstance();
            var Yer = RealmDB.All<Data.SeansYeri>().ToList();
            var MaxYer = 0;
            if (Yer.Count != 0)
            {
                MaxYer = Yer.Max(m => m.YerId) + 1;
            }
            var YerEkle = new Data.SeansYeri
            {
                YerId = MaxYer,
                SeansYer = Convert.ToString(Syeri.Text),
                Kira = Convert.ToInt32(kira.Text)


            };
            RealmDB.Write(() =>
            {
                RealmDB.Add(YerEkle);
            });
            var YerList = RealmDB.All<Data.SeansYeri>().ToList();


            await DisplayAlert("BAŞARILI", "Seans Yeri Eklenmiştir.", "Tamam");
            Goster();
        }

        private async void vazgeçX_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private  void LstSea_Yeri_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                Sil.IsEnabled = false;

                if (Sil.IsEnabled == false)
                {
                    Sil.BackgroundColor = Color.WhiteSmoke;
                }
                return;
            }
            else
            {
                Sil.IsEnabled = true;
                var SelectTurId = (Data.SeansYeri)e.SelectedItem;
                var listWie = (ListView)sender;
                turId = Convert.ToInt32(SelectTurId.YerId);
                return;
            }


        }

        private void Sil_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var selectedıd = realmDB.All<Data.SeansYeri>().First(a => a.YerId == Convert.ToInt32(turId));
            try
            {
                using (var db = realmDB.BeginWrite())
                {
                    realmDB.Remove(selectedıd);
                    db.Commit();
                }
                Goster();
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }
        public void Goster()
        {
            var realmDB = Realm.GetInstance();
            var myTur = realmDB.All<Data.SeansYeri>().ToList();
            LstSea_Yeri.ItemsSource = myTur;
        }
    }
}