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
using Xamarin.Forms.Xaml;

namespace DanisanT.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotEkle : PopupPage
    {
        int Danisan_ID;
        int Seans_ID;
        string Danisan_Adi;
        public NotEkle(int SeansID,int DanisanID,string DanisanAdi)
        {
            InitializeComponent();
            Danisan_ID = DanisanID;
            Seans_ID = SeansID;
            Danisan_Adi = DanisanAdi;
        }

        private async void Notlaree_Clicked(object sender, EventArgs e)
        {
            try
            {
                var realmDB = Realm.GetInstance();
                var NotX = realmDB.All<Data.Notlar2>().ToList();
                var notNo = 0;
                if (NotX.Count != 0)
                {
                    notNo = NotX.Max(m => m.NotID) + 1;
                }
                var NotEkle = new Notlar2
                {
                    NotID = notNo,
                    Baslik = NotBaslik.Text,
                    DanisanID = Danisan_ID,
                    Seans_ID = Seans_ID,
                    Not = Not.Text,
                    Danısan_İsim = Danisan_Adi

                };
                realmDB.Write(() =>
                {
                    realmDB.Add(NotEkle);
                });
                await Navigation.PopPopupAsync();
                await DisplayAlert("Not Eklenmiştir.", " ", "Tamam");
               
            }
            catch (Exception)
            {
              
                return;
            }
            
        }
    }
}