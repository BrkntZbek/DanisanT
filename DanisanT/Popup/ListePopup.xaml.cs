using DanisanT.Data;
using DanisanT.Popup;
using DanisanT.Views;
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

namespace DanisanT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListePopup : PopupPage
    {

        string RealDanisanName;
        int RealId;


        public ListePopup(string DanisanName, int Id)
        {
            InitializeComponent();



            RealDanisanName = DanisanName;
            RealId = Id;
            var realmDB = Realm.GetInstance();

            var selectedDname = realmDB.All<Data.Danisan>().First(a => a.İsimSoyisim == Convert.ToString(RealDanisanName));
            var SelectedID = realmDB.All<Data.Danisan>().First(b => b.Id == RealId);
            DNSisim.Text = selectedDname.İsimSoyisim.ToString();
            if (SelectedID.Cinsiyet == "Erkek")
            {
                profil.Source = "manX.png";
            }
            else if (SelectedID.Cinsiyet == "Kadın")
            {
                profil.Source = "womanX.png";
            }
        }



        private async void SeansekleBTN_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();

            var selectedDname = realmDB.All<Data.Danisan>().First(a => a.İsimSoyisim == Convert.ToString(RealDanisanName));
            var SelectedID = realmDB.All<Data.Danisan>().First(b => b.Id == RealId);
            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new SeansEkle(RealDanisanName, RealId));

            }
        }

        private async void guncelleBTN_Clicked(object sender, EventArgs e)
        {

            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new DanisanGuncelle(RealDanisanName, RealId));


            }





        }

        private async void SilBTN_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var selectedDname = realmDB.All<Data.Danisan>().First(a => a.Id == RealId);

            try
            {
                bool sorgu = await DisplayAlert("Uyarı", "Danışanı Silmek İstiyor Musunuz?.", "Evet", "Hayır");
               if (sorgu == true)
                {
                    using (var Db = realmDB.BeginWrite())
                    {
                        realmDB.Remove(selectedDname);
                        Db.Commit();
                    }
                    await DisplayAlert("UYARI", "Danışan Silinmiştir.","Tamam");
                    await Navigation.PopPopupAsync();
                }
                else
                {
                    return;
                }
                

            }
            catch (Exception)
            {
                return;
            }
        }



        private async void BilgiBTN_Clicked_1(object sender, EventArgs e)
        {
            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new Dbilgi(RealDanisanName));

            }
            
        }

        private async void OdemeBTN_Clicked(object sender, EventArgs e)
        {
            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new DanisanOdemeler(RealDanisanName,RealId));
            }
           
        }

        private async void BakiyeBTN_Clicked(object sender, EventArgs e)
        {
            if (RealDanisanName != null)
            {
                await Navigation.PushPopupAsync(new BakiyeEkle(RealId));
            }
           
        }

        private async void vazcayBTN_Clicked(object sender, EventArgs e)
        {
          
                await Navigation.PopPopupAsync();
            
            
        }

        private async void SeanslarBTN_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var DanisanSeansları = realmDB.All<Data.Seans>().ToList().Where(s => s.SeansDanisanId == RealId);
            int ddcount = DanisanSeansları.Count();
            if (RealDanisanName != null)
            {
                if (ddcount != 0)
                {
                    await Navigation.PushPopupAsync(new DanisanSeanslar(RealId));
                }
                else
                {
                    await DisplayAlert("UYARI", "Danışana Ait Seans Bulunmamaktadır.", "Tamam");
                    return;
                }
            }
           
        }
    }
}