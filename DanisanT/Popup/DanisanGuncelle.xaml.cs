using Realms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Animations;
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
    public partial class DanisanGuncelle : PopupPage
    {
        string RealDanisanId;
        int RealId;
        public DanisanGuncelle(string DanisanName, int Id)
        {
            InitializeComponent();
            RealDanisanId = DanisanName;
            RealId = Id;
            var realmdb = Realm.GetInstance();

            var Doldur = realmdb.All<Data.Danisan>().FirstOrDefault(s => s.Id == RealId);
            GisimSoyisim.Text = Doldur.İsimSoyisim;
            Gtelefon.Text = Doldur.Telefon;
            Gbilgi.Text = Doldur.Bilgi;
        }

        private async void BtnDguncelle_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var selectedDanisan = realmDB.All<Data.Danisan>().First(s => s.İsimSoyisim == Convert.ToString(RealDanisanId));
            var selectedId = realmDB.All<Data.Danisan>().First(a => a.Id == Convert.ToInt32(RealId));

            try
            {
                using (var db = realmDB.BeginWrite())
                {
                    selectedDanisan.İsimSoyisim = GisimSoyisim.Text;
                    selectedDanisan.Telefon = Gtelefon.Text;

                    //  selectedDanisan.Bilgi = Gbilgi.Text;
                    if (GisimSoyisim.Text == null)
                    {
                        await DisplayAlert("Uyarı", "Lütfen İsimSoyisim Giriniz.", "Tamam");
                        return;
                    }
                    db.Commit();
                }
                await DisplayAlert("Uyarı", "Danışan Güncellenmiştir.", "Tamam");
                await Navigation.PopPopupAsync();

            }
            catch (Exception)
            {
                return;

            }
        }

        private async void vazgecBTN_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}