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

namespace DanisanT.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DanisanSeanslar : PopupPage
    {
        int ID;
        public  DanisanSeanslar(int DanisanID)
        {
            InitializeComponent();
           ID = DanisanID;
            var realmdb = Realm.GetInstance();
            var DanisanSeansları = realmdb.All<Data.Seans>().ToList().Where(s => s.SeansDanisanId == ID);
            seansXxX.ItemsSource = DanisanSeansları;
         
            
           
        }
        



    }
}