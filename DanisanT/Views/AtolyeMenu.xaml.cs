using DanisanT.Popup;
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
    public partial class AtolyeMenu : ContentPage
    {
        public AtolyeMenu()
        {
            InitializeComponent();
            var realmDB = Realm.GetInstance();
            var myDanisan = realmDB.All<Data.Atolye2>().ToList();



            LstAtolye.ItemsSource = myDanisan;
        }

        private async void AtolyeEkle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Popup_Atolye());
        }

        private async void LstAtolye_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                var SecilenAtolye = (Data.Atolye2)e.SelectedItem;
                var lisw = (ListView)sender;

                await Navigation.PushPopupAsync(new AtolyePopup(SecilenAtolye.Atolye_İsim.ToString(), Convert.ToInt32(SecilenAtolye.Id)));
                lisw.SelectedItem = null;
            }
        }

        private async void RefreshViewe_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            RefreshViewe.IsRefreshing = false;
            var realmDB = Realm.GetInstance();
            var myDanisan = realmDB.All<Data.Atolye2>().ToList();



            LstAtolye.ItemsSource = myDanisan;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var RealDB = Realm.GetInstance();
            var MyDanisan = RealDB.All<Data.Atolye2>().ToList();
            LstAtolye.ItemsSource = MyDanisan.Where(s => s.Atolye_İsim.ToLower().StartsWith(e.NewTextValue));
        }
    }
}