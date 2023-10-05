using DanisanT.Data;
using Realms;
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
	public partial class AtolyeBilgi : ContentPage
	{
		public AtolyeBilgi (string Atolyeİsmi,int AtolyeID)
		{
			InitializeComponent ();
			var realmdb = Realm.GetInstance();

			atolyeİsmi.Text = Atolyeİsmi.ToString()	;
			var AtolyeyeKatilan = realmdb.All<Data.AtolyeKatilimci>().Where(m=> m.Atolye_ID == AtolyeID).ToList();
            LstAtolyeKatilim.ItemsSource = AtolyeyeKatilan.ToList();

			var AtolyeKatilanSayisi = realmdb.All<AtolyeKatilimci>().Where(m=>m.Atolye_ID == AtolyeID);
			var Count = AtolyeKatilanSayisi.Count();

			var AtolyeFiyat = realmdb.All<Data.Atolye2>().FirstOrDefault(m=>m.Id == AtolyeID);
			var fiyat = AtolyeFiyat.Atolye_Fiyat;
			var Gelir = Convert.ToInt32( Count * fiyat);




			var Atolye = realmdb.All<Data.Atolye2>().FirstOrDefault(m=>m.Id == AtolyeID);
			Fiyat.Text =   Atolye.Atolye_Fiyat.ToString() + "₺";
			Tarihx.Text = Atolye.Atolye_Tarih.ToString();
			SaatX.Text = Atolye.Atolye_Saat.ToString();
			Katilimx.Text = Count.ToString();
			Gelix.Text = Gelir.ToString()+ "₺";



        }

        private void LstAtolyeKatilim_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}