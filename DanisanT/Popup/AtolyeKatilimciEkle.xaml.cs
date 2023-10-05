using DanisanT.Data;
using Realms;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Xamarin.Forms.Xaml;

namespace DanisanT.Popup
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AtolyeKatilimciEkle : ContentPage
	{
        string Atolye_İsim;
        int Atolye_ID;
		public AtolyeKatilimciEkle (string Atolyeİsmi,int AtolyeID)
		{
			InitializeComponent ();
            Atolye_İsim = Atolyeİsmi;
            Atolye_ID = AtolyeID;
            var realmDB = Realm.GetInstance();
            var myDanisan = realmDB.All<Data.Danisan>().ToList();

            

            LstDanisan1.ItemsSource = myDanisan;
        }

        private void KatilimciEkle_Clicked(object sender, EventArgs e)
        {
          
        }

        private void DKatilimciEkle_Clicked(object sender, EventArgs e)
        {
            
        }

        private async void LstDanisan1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var selectName = (Danisan)e.SelectedItem;
           
            var listWie = (Xamarin.Forms.ListView)sender;
            await Navigation.PushPopupAsync(new AtolyeKatilimciEkleniyor(selectName.İsimSoyisim.ToString(), Convert.ToInt32(selectName.Id),Convert.ToInt32(Atolye_ID)));
            listWie.SelectedItem = null;
        }

        private void dd_TextChanged(object sender, TextChangedEventArgs e)
        {
            var RealDB = Realm.GetInstance();
            var MyDanisan = RealDB.All<Data.Danisan>().ToList();
            LstDanisan1.ItemsSource = MyDanisan.Where(s => s.İsimSoyisim.ToLower().StartsWith(e.NewTextValue));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
          /*bool sorgu = await DisplayAlert("UYARI", "Danışanı Atölyeye eklemek mi istiyorsunuz?", "Evet","Hayır");
            if (sorgu == true)
            {
                Xamarin.Forms.ImageButton clickbutton = (Xamarin.Forms.ImageButton)sender;
                Danisan clickdanisan = (Danisan);*/
                
            
        }
    }
}