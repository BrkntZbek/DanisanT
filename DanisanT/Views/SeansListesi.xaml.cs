using DanisanT.Data;
using DanisanT;
using Realms;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace DanisanT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeansListesi : ContentPage
    {
        public SeansListesi()
        {
            InitializeComponent();
            var realmDB = Realm.GetInstance();
            var MySeans = realmDB.All<Data.Seans>().ToList();
            LstSeans.ItemsSource = MySeans;
        }

        private async void RefreshView1_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            RefreshView1.IsRefreshing = false;
            var realmDB = Realm.GetInstance();
            var MySeans = realmDB.All<Data.Seans>().ToList();
            LstSeans.ItemsSource = MySeans;
            
           
        }

        private async void LstSeans_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                {
                    return;
                }
                var selectName = (Data.Seans)e.SelectedItem;
                var selectId = (Data.Seans)e.SelectedItem;
                var SDanisanId = (Data.Seans)e.SelectedItem;

                var listWie = (Xamarin.Forms.ListView)sender;
                await Navigation.PushPopupAsync(new PopupSeansPage(selectName.Seans_İsimSoyisim.ToString(), Convert.ToInt32(selectId.SeansId), Convert.ToInt32(SDanisanId.SeansDanisanId)));
                listWie.SelectedItem = null;
            }
            catch (Exception)
            {
                await DisplayAlert("UYARI", "Bu Seans İptal Edilmiştir. Lütfen Sayfayı Yenileyiniz.", "Tamam");
                return;
            }
          

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var RealDB = Realm.GetInstance();
            var MyDanisan = RealDB.All<Data.Seans>().ToList();
            LstSeans.ItemsSource = MyDanisan.Where(s => s.Seans_İsimSoyisim.ToLower().StartsWith(e.NewTextValue));
        }

        private void DataPicker_SizeChanged(object sender, EventArgs e)
        {

        }

        private void DataPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var MySeans = realmDB.All<Data.Seans>().ToList();
            var tarih = e.NewDate.ToShortDateString();


            LstSeans.ItemsSource = MySeans.Where(s => s.Tarih.ToString().StartsWith(tarih.ToString())).OrderBy(x => x.Saat);


        }

        private void Label_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }
    }
}