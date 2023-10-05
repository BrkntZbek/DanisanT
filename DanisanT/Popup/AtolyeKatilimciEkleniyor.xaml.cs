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
	public partial class AtolyeKatilimciEkleniyor : PopupPage
	{
        string Danisan_İsim;
        int Danisan_ID;
        int ID_Atolye;
		public AtolyeKatilimciEkleniyor (string Danisanİsim, int DanisanID,int AtolyeID)
		{
			InitializeComponent ();
            Danisan_İsim = Danisanİsim;
            Danisan_ID = DanisanID;
            ID_Atolye = AtolyeID;
            DNSisim.Text = Danisan_İsim.ToString ();    
		}

        private async void AtolyeyeEkle_Clicked(object sender, EventArgs e)
        {
            var RealmDB = Realm.GetInstance();
            var Katilimcilar = RealmDB.All<Data.AtolyeKatilimci>().ToList();
           
            int KatilimciNO = 0;
           
            if (Katilimcilar.Count != 0 )
            {
                KatilimciNO = Katilimcilar.Max(m => m.Katilimci_ID)+1;
                
            }
            var seaTelbul = RealmDB.All<Data.Danisan>().First(s => s.Id == Danisan_ID);   //  Danışanın numarasını alır.
            string tel = seaTelbul.Telefon.ToString();//

            var AtolyeBul = RealmDB.All<Data.Atolye2>().First(s => s.Id == ID_Atolye);
            string Atolyeİsmi = AtolyeBul.Atolye_İsim.ToString();
            int Odeme = Convert.ToInt32(AtolyeBul.Atolye_Fiyat);

            var KatilimciKontrol = RealmDB.All<Data.AtolyeKatilimci>().Where(a => a.Atolye_ID == ID_Atolye).FirstOrDefault(x=> x.Katilimci_Danisan_ID == Danisan_ID);  //x=> x.Atolye_ID == ID_Atolye)
            try
            {
                if (KatilimciKontrol == null)
                {
                    var KatilimciEkle = new AtolyeKatilimci
                    {
                        Katilimci_ID = KatilimciNO,
                        Katilimci_Telefon = tel,
                        Katilimci_İsim = Danisan_İsim,
                        Katilimci_Danisan_ID = Danisan_ID,
                        Atolye_ID = ID_Atolye,
                        Atolye_İsim = Atolyeİsmi,
                        Odeme = Odeme
                    };
                    RealmDB.Write(() =>
                    {
                        RealmDB.Add(KatilimciEkle);
                    });

                   

                    await Navigation.PopPopupAsync();


                }
                else
                {
                    await DisplayAlert("Uyarı", "Eklemek İstediğiniz Kişi Zaten Atölyeye Kayıtlı.", "Tamam");
                    return;
                }
            }
            catch (Exception)
            {

                return;
            }

           


            

        }

        private async void vazcay_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ss_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
    }
}