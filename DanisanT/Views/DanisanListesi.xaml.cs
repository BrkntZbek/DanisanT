using DanisanT.Data;
using Realms;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanisanT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DanisanListesi : ContentPage
    {


        public DanisanListesi()
        {
            InitializeComponent();
            var realmDB = Realm.GetInstance();
            var myDanisan = realmDB.All<Data.Danisan>().ToList();



            LstDanisan.ItemsSource = myDanisan;




        }

        public async void LstDanisan_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                BackgroundColor = Color.Black;
            }
            var selectedDname = (Data.Danisan)e.SelectedItem;
            var SelectedId = (Data.Danisan)e.SelectedItem;
            var listWievulas = (ListView)sender;

            await Navigation.PushPopupAsync(new ListePopup(selectedDname.İsimSoyisim.ToString(), Convert.ToInt32(SelectedId.Id)));
            listWievulas.SelectedItem = null;

        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            RefreshView.IsRefreshing = false;
            var realmDB = Realm.GetInstance();
            var myDanisan = realmDB.All<Data.Danisan>().ToList();



            LstDanisan.ItemsSource = myDanisan;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var RealDB = Realm.GetInstance();
            var MyDanisan = RealDB.All<Data.Danisan>().ToList();
            LstDanisan.ItemsSource = MyDanisan.Where(s => s.İsimSoyisim.ToLower().StartsWith(e.NewTextValue));
        }
    }
}