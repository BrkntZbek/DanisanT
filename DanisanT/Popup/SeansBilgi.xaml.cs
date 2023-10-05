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
    public partial class SeansBilgi : PopupPage
    {
        string RealName;
        int RealSeansId;
        public SeansBilgi(string danisanName, int SeansId)
        {
            RealName = danisanName;
            RealSeansId = SeansId;
            InitializeComponent();
            try
            {
                var realmDB = Realm.GetInstance();
                var MyDanisan = realmDB.All<Data.Danisan>().First(a => a.İsimSoyisim == Convert.ToString(RealName));
                var MYSeans = realmDB.All<Data.Seans>().First(a => a.SeansId == Convert.ToInt32(RealSeansId));
                lblId.Text = MyDanisan.Id.ToString();
                lblİsim.Text = MyDanisan.İsimSoyisim.ToString();
                Lbltelefon.Text = MYSeans.Tarih.ToString();
                Lblaranacak.Text = MyDanisan.Telefon.ToString();
               LblBorc.Text = MYSeans.SeansTuru.ToString();
              lblSeaSayisi.Text = MYSeans.Odeme.ToString()+"₺";
                lblCinsiyet.Text = MYSeans.Cash.ToString();
                resim.Source = MyDanisan.Image.ToString();

                lblBilgi.Text = MYSeans.OfisOdeme.ToString() + "₺";
                if (lblCinsiyet.Text == "Ödenmedi")
                {
                    lblCinsiyet.TextColor = Color.Red;
                }
                else if (lblCinsiyet.Text == "Ödendi")
                {
                    lblCinsiyet.TextColor = Color.Green;
                }

            }
            catch (Exception)
            {

                return;
            }
        }
    }
}