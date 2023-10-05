using Realms;
using Rg.Plugins.Popup.Pages;
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
    public partial class OdemeYap : PopupPage
    {
        public OdemeYap(string DanisanName)
        {
            InitializeComponent();
            var realmdb = Realm.GetInstance();
            var SeansLar = realmdb.All<Data.Seans>().Where(x => x.Seans_İsimSoyisim == DanisanName).ToList();
            var Odenmemisler = realmdb.All<Data.Seans>().Where(x => x.Seans_İsimSoyisim == DanisanName).Where(d => d.Cash == "Ödenmedi").ToList();
            
            var Borc = realmdb.All<Data.Danisan>().FirstOrDefault(a => a.İsimSoyisim == DanisanName).Borc;
            BorcTXT.Text = Borc.ToString();
            SeaList.ItemsSource = Odenmemisler;

        }
    }
}