using Realms;
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
    public partial class Odemeler : ContentPage
    {
        public Odemeler()
        {
            InitializeComponent();
            var realmDB = Realm.GetInstance();
            var MyOdeme = realmDB.All<Data.Odemeler>().ToList();
            LstOdeme.ItemsSource = MyOdeme;
        }

        private void LstOdeme_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void sse_TextChanged(object sender, TextChangedEventArgs e)
        {
            var RealDB = Realm.GetInstance();
            var MyDanisan = RealDB.All<Data.Odemeler>().ToList();
            LstOdeme.ItemsSource = MyDanisan.Where(s => s.Odeyen_Danisan.ToLower().StartsWith(e.NewTextValue));
        }
    }
}