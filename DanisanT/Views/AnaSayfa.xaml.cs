using Realms;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms.Xaml;

namespace DanisanT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaSayfa : ContentPage
    {
        public AnaSayfa()
        {
            InitializeComponent();
            var realmDB = Realm.GetInstance();
            var MySeans = realmDB.All<Data.Seans>().ToList();
            var tarih = DateTime.Now.ToShortDateString();


            YaklasanSeansLST.ItemsSource = MySeans.Where(s => s.Tarih.ToString().StartsWith(tarih.ToString())).OrderBy(x => x.Saat);


            
        }



        private async void YaklasanSeansLST_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var selectName = (Data.Seans)e.SelectedItem;
            var SelectId = (Data.Seans)e.SelectedItem;
            var selectDanisanId = (Data.Seans)e.SelectedItem;
            var listWie = (Xamarin.Forms.ListView)sender;
            await Navigation.PushPopupAsync(new PopupSeansPage(selectName.Seans_İsimSoyisim.ToString(), Convert.ToInt32(SelectId.SeansId), Convert.ToInt32(selectDanisanId.SeansDanisanId)));
            listWie.SelectedItem = null;
        }


        private async void KullaniciPaneli_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new KullaniciPaneliPage());
        }

        private void YaklasanSeansLST_Scrolled(object sender, ScrolledEventArgs e)
        {

        }

        private async void RefreshView1_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            RefreshView1.IsRefreshing = false;
            var realmDB = Realm.GetInstance();
            var MySeans = realmDB.All<Data.Seans>().ToList();
            var tarih = DateTime.Now.ToShortDateString();


            YaklasanSeansLST.ItemsSource = MySeans.Where(s => s.Tarih.ToString().StartsWith(tarih.ToString())).OrderBy(x => x.Saat);
           
        }

        private async void atolye_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AtolyeMenu());
           
        }

        private async void Muhasebe_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OdemelerPage());
        }

        private void Notebook_Clicked(object sender, EventArgs e)
        {

        }
    }
}