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
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DanisanT.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popup_Atolye : PopupPage
    {
        public Popup_Atolye()
        {
            InitializeComponent();

            SaatleriEkle();
        }

        private async void Atolyekle_btn_Clicked(object sender, EventArgs e)
        {
            var realmdb = Realm.GetInstance();
            var AtolyeVarmı = realmdb.All<Data.Atolye2>().ToList();
            var AtolyeID = 0;
            if (AtolyeVarmı.Count != 0)
            {
                AtolyeID = AtolyeVarmı.Max(m => m.Id) + 1;
            }
            
           
            var AtolyeEkle = new Atolye2
            {
                Id = AtolyeID,
                Atolye_İsim = xAtolyeİsim.Text.ToString(),
                Atolye_Saat = SaatPicker.SelectedItem as string,
                Atolye_Fiyat = Convert.ToInt32(xAtolyeFiyat.Text),
                Atolye_Tarih = xAtolyeTarih.Date.ToShortDateString(),
            };
            realmdb.Write(() =>
            {
                realmdb.Add(AtolyeEkle);
            });
            await DisplayAlert("Uyarı", "Atölye Eklenmiştir.", "Tamam");
        }
        private void SaatleriEkle()
        {
            List<string> Saat = new List<string>
            {
                "09:00",
                    "10:00",
                    "11:00",
                    "12:00",
                    "13:00",
                    "14:00",
                    "15:00",
                    "16:00",
                    "17:00",
                    "18:00",
                    "19:00",
                    "20:00",
                    "21:00",
                    "22:00",
                    "23:00",
                    "00:00",


            };

            SaatPicker.ItemsSource = Saat;  
        }
    }
}