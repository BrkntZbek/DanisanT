using Realms;
using Rg.Plugins.Popup.Extensions;
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
    public partial class KullaniciPaneliPage : ContentPage
    {
        public KullaniciPaneliPage()
        {
            InitializeComponent();
        }

        private void ss_Clicked(object sender, EventArgs e)
        {

        }

        private async void Ayarlarbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new SeansYeriEkle());
        }

        private  void Atolyebtn_Clicked(object sender, EventArgs e)
        {
            // await Navigation.PushModalAsync(new Views.Atolye());

        }

        private void Muhasebebtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void Odemelerx_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OdemelerPage());
        }

        private void K_Bilgileri_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void silis_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            using (var Db = realmDB.BeginWrite())
            {

                realmDB.RemoveAll();

                Db.Commit();
            }
        }
    }
}