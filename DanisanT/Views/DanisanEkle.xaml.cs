using DanisanT.Data;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DanisanT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DanisanEkle : ContentPage
    {
        public DanisanEkle()
        {
            InitializeComponent();
        }

        private async void Dekle_btn_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var myDanisan = realmDB.All<Data.Danisan>().ToList();
            var maxStudentId = 0;
            var Borc = 0;
            if (myDanisan.Count != 0)
            {
                maxStudentId = myDanisan.Max(m => m.Id) + 1;
            }
            try
            {
                if (Disim.Text == null || Dtel.Text == null || DBilgi.Text == null || Dara1.Text == null)
                {
                    await DisplayAlert("UYARI", "Lütfen Boş Alan Bırakmayın.", "Tamam");
                    return;
                }
                else
                {
                    var Cniyt = " ";
                    var image1 = "";
                    int tSeans = 0;
                    if (erkek.IsChecked == true)

                    {
                        Cniyt = "Erkek";
                        Kadin.IsEnabled = false;
                        image1 = "Man.png";

                    }
                    else if (Kadin.IsChecked == true)
                    {
                        Cniyt = "Kadın";
                        erkek.IsEnabled = true;
                        image1 = "WMan.png";
                    }

                    var Daniss = new Data.Danisan
                    {
                        Id = maxStudentId,
                        İsimSoyisim = Disim.Text,
                        Telefon = Dtel.Text,
                        Aranacak1 = Dara1.Text,
                        Borc = Convert.ToInt32(Borc),
                        Bilgi = DBilgi.Text,
                        Cinsiyet = Cniyt,
                        Image = image1,
                        ToplamSeans = Convert.ToInt32(tSeans)



                    };
                    realmDB.Write(() =>
                    {
                        realmDB.Add(Daniss);
                    });


                    var DanisanList = realmDB.All<Data.Danisan>().ToList();


                    await DisplayAlert("BAŞARILI", "Danışan eklenmiştir.", "Tamam");
                    Disim.Text = "";
                    Dtel.Text = "";
                    Dara1.Text = "";
                    DBilgi.Text = "";

                }

            }
            catch (Exception)
            {
                return;

            }


        }
    }
}