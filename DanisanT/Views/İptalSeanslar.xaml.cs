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
	public partial class İptalSeanslar : ContentPage
	{
		public İptalSeanslar()
		{
			InitializeComponent ();
            var realmDB = Realm.GetInstance();
            var MyOdeme = realmDB.All<Data.İptalSeans>().ToList();
            Lstİptal.ItemsSource = MyOdeme;
        }
	}
}