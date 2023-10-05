using Realms;
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
    public partial class NotPopup : PopupPage
    {
        public NotPopup(int SeansID,int DanisanID)
        {
            InitializeComponent();
            var realmdb = Realm.GetInstance();
            var Notlar = realmdb.All<Data.Notlar2>().Where(s=>s.Seans_ID == SeansID).Where(s=>s.DanisanID == DanisanID).ToList();
            lstNOT.ItemsSource = Notlar;
        }
    }
}