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
    public partial class Dbilgi : PopupPage
    {
        string RealName;


        public Dbilgi(string RealDanisanName)
        {
            InitializeComponent();
            RealName = RealDanisanName;
            try
            {
                var realmDB = Realm.GetInstance();
                var MyDanisan = realmDB.All<Data.Danisan>().First(a => a.İsimSoyisim == Convert.ToString(RealName));
                lblİsim.Text = MyDanisan.İsimSoyisim.ToString();
                lblId.Text = MyDanisan.Id.ToString();
                Lbltelefon.Text = MyDanisan.Telefon.ToString();
                lblCinsiyet.Text = MyDanisan.Cinsiyet.ToString();
                lblBilgi.Text = MyDanisan.Bilgi.ToString();
                Lblaranacak.Text = MyDanisan.Aranacak1.ToString();
                LblBorc.Text = MyDanisan.Borc.ToString() + "₺";
                resim.Source = MyDanisan.Image.ToString();
                lblSeaSayisi.Text = MyDanisan.ToplamSeans.ToString();
            }
            catch (Exception)
            {

                return;
            }

        }
    }
}