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
	public partial class AtolyePopup : PopupPage
	{
        string Atolyeİsim;
        int AtolyeID;
		public AtolyePopup (string Atolyeİsmi,int AtolyeIDd)
		{
			InitializeComponent();
            Atolyeİsim = Atolyeİsmi;
            AtolyeID = AtolyeIDd;
            DNSisim.Text = Atolyeİsim;
        }

        private async void Katilim_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AtolyeKatilimciEkle(Atolyeİsim, AtolyeID));
            await Navigation.PopPopupAsync();
        }

        private void Aguncelle_Clicked(object sender, EventArgs e)
        {

        }

        private void Silb_Clicked(object sender, EventArgs e)
        {

        }

        private async void bilgia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AtolyeBilgi(Atolyeİsim, AtolyeID));
            await Navigation.PopPopupAsync();
        }

        private void Odemea_Clicked(object sender, EventArgs e)
        {

        }
    }
}