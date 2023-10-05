using DanisanT.Data;
using DanisanT.Views;
using Realms;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Xamarin.Forms.Xaml;

namespace DanisanT
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeansEkle : PopupPage
    {
        string RealDanisanId;
        int RealId;
        string Odeme;
        int SeansFiyatıX;
        
       
        public SeansEkle(string DanisanName, int Id)
        {
            InitializeComponent();
            RealDanisanId = DanisanName;
            RealId = Id;
            var realmdb = Realm.GetInstance();

           
                var selectedName = realmdb.All<Danisan>().First(a => a.İsimSoyisim == Convert.ToString(RealDanisanId)); // Eşit Olanı alıyor
                var selectedID = realmdb.All<Danisan>().First(b => b.Id == Convert.ToInt32(RealId));
                SeansEkle_Danisan.Text ="--"+ selectedName.İsimSoyisim.ToString()+"--";



            var İtem = realmdb.All<SeansYeri>().ToList();
            var pickersİtem = İtem.Select(x => x.SeansYer).ToList();
            Pickerr.ItemsSource = pickersİtem;
            
            List<string> Saat2 = new List<string>
            {
                "09:00",
                    "10:00",
                    "11:00",
                    "12:00",
                    "13:00",
                    "14:00",
                    "15:00",
                    "16:00",
                    "17:00",
                    "18:00",
                    "19:00",
                    "20:00",
                    "21:00",
            };

            SaatPicker.ItemsSource = Saat2;


            var TopluOdemeUlas = realmdb.All<Data.Bakiye>().FirstOrDefault(s => s.Danisan_ID == Convert.ToInt32(RealId));
            if (TopluOdemeUlas != null)
            {
                if (TopluOdemeUlas.SeansSayisi != 0)
                {
                    topluOdemeUYARI.Text = "Danışan " + TopluOdemeUlas.SeansSayisi + " Seansı Toplu Ödemiştir.";
                    fiyatİnt.IsVisible = false;
                    Odendi.IsVisible = false;
                    Odenmedi.IsVisible = false;
                    SeansFiyatıX = TopluOdemeUlas.SeansFiyati;
                    OdendiText.IsVisible = false;
                    OdenmediText.IsVisible = false;
                    fiyattext.IsVisible = false;
                }
                else
                {
                    topluOdemeUYARI.Text = " ";
                }
            }
           
            

        }
        private async void SeansEkleX(string Tarih,string saat,int Fiyat,string Cash,Realm Baglanti)
        {
            var mySeansx = Baglanti.All<Data.Seans>().Where(a => a.Tarih == Tarih.ToString()).FirstOrDefault(x => x.Saat == saat.ToString());
            var selectedName = Baglanti.All<Danisan>().FirstOrDefault(a => a.Id == RealId);
           
           
            if (mySeansx == null)
            {
                
                string tel = selectedName.Telefon.ToString();//
                string ofs = Pickerr.SelectedItem.ToString();
                var ofis = Baglanti.All<Data.SeansYeri>().Where(s => s.SeansYer == ofs).FirstOrDefault();//
                var ucret = ofis.Kira; //   Ofis Kirasını bul
                
               
                using (var db = Baglanti.BeginWrite())
                {
                    selectedName.ToplamSeans ++;
                    db.Commit();
                }
                var mySeans = Baglanti.All<Data.Seans>().ToList();
                var SeansNos = 0;
                if (mySeans.Count != 0)
                {
                    SeansNos = mySeans.Max(m => m.SeansId) + 1;
                }
                var Giderno = 0;
                var gider = Baglanti.All<Data.OfisGider>().ToList();
                if (gider.Count != 0)
                {
                    Giderno = gider.Max(a => a.GiderID) + 1;
                }
                
                var OfisGideri = new OfisGider
                {
                    GiderID = Giderno,
                    SeansYeri = Pickerr.SelectedItem.ToString(),
                    Kira = ucret,
                    Seans_ID = SeansNos

                };
                Baglanti.Write(() =>
                {
                    Baglanti.Add(OfisGideri);
                });
                var SeaEkle = new Seans
                {
                    SeansId = SeansNos,
                    Seans_İsimSoyisim = RealDanisanId.ToString(),
                    Tarih = Tarih.ToString(),
                    Saat = saat.ToString(),
                    Seans_Telefon = tel.ToString(),
                    SeansTuru = Pickerr.SelectedItem.ToString(),
                    Odeme = Fiyat,
                    Cash = Cash,
                    SeansDanisanId = RealId,
                    OfisOdeme = ucret
                };
                Baglanti.Write(() =>
                {
                    Baglanti.Add(SeaEkle);
                });

                await DisplayAlert("Başarılı", "Seans Eklenmiştir.", "Tamam");


            }
            else
            {
                await DisplayAlert("Uyarı", "Seans Eklemek İstediğiniz Saat Dolu.", "Tamam");
                return;
            }
        }


        private void OdemeKontrol()
        {

        }

        private async void SeansEkle1BTN_Clicked(object sender, EventArgs e)
        {
            var RealmDbx = Realm.GetInstance();
            
            var saat = SaatPicker.SelectedItem.ToString();
            //Odeme İçin

            var MYOdeme = RealmDbx.All<Data.Odemeler>().ToList();
            int OdemeNo = 0;
            int Yatırılacakpara = 0;
            string OdemeTarihi = " ";
            //
            //SeansİÇin
            var RealmDb = Realm.GetInstance();
            
            string Secilentarih = Tarihx.Date.ToShortDateString();
            


            var TopluOdeme_Kontrol = RealmDbx.All<Data.Bakiye>().FirstOrDefault(s => s.Danisan_ID == RealId);
            if (TopluOdeme_Kontrol !=null && TopluOdeme_Kontrol.SeansSayisi != 0)  ///
            {
                
                Odeme = "Ödendi";
                SeansFiyatıX = TopluOdeme_Kontrol.SeansFiyati;
                using (var db = RealmDbx.BeginWrite())
                {
                    TopluOdeme_Kontrol.SeansSayisi--;
                    db.Commit();
                }
                SeansEkleX(Secilentarih, saat,SeansFiyatıX,Odeme, RealmDbx);
            }
            else
            {
                try
                {
                    SeansFiyatıX = Convert.ToInt32(fiyatİnt.Text);
                   

                    var borc = 0;
                    if (Odendi.IsChecked == true)//
                    {
                        Odeme = OdendiText.Text.ToString();
                        borc = 0;

                        Yatırılacakpara = SeansFiyatıX;
                        OdemeTarihi = Tarihx.Date.ToShortDateString();


                        if (MYOdeme.Count != 0)
                        {
                            OdemeNo = MYOdeme.Max(m => m.OdemeID) + 1;
                        }
                        var OdemeEkle = new Data.Odemeler
                        {
                            OdemeID = OdemeNo,
                            Odeyen_Danisan = RealDanisanId.ToString(),
                            Odeyen_Danisan_ID = RealId,
                            Odenen = Yatırılacakpara,
                            OdemeNotu = " ",
                            OdemeTarihi = OdemeTarihi
                            
                        };
                        RealmDbx.Write(() =>
                        {
                            RealmDbx.Add(OdemeEkle);
                        });

                    }
                    else if (Odenmedi.IsChecked == true)//
                    {
                        Odeme = OdenmediText.Text.ToString();
                        borc = Convert.ToInt32(fiyatİnt.Text);
                        Yatırılacakpara = 0;
                        var borcubul = RealmDb.All<Data.Danisan>().FirstOrDefault(s => s.Id == RealId);
                        int toplam = borcubul.Borc + borc;
                        using (var db = RealmDbx.BeginWrite())
                        {
                            borcubul.Borc = Convert.ToInt32( toplam);
                            db.Commit();
                        }
                    }
                    
                   
                    SeansEkleX(Secilentarih, saat, SeansFiyatıX, Odeme, RealmDbx);

                    
                    await Navigation.PopPopupAsync();
                }
                catch (Exception)
                {
                    await DisplayAlert("Uyarı", "Boş Alan Bırakmayınız", "Tamam");
                    return;
                }
               
            }
        }

        private void Tarihx_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        public void myPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* var realmdb = Realm.GetInstance();
              var seansyerleri = realmdb.All<Data.SeansYeri>().First();
              if (myPicker.SelectedIndex != -1)
              {
                  var Seansyeri = from i in realmdb 
                                  where i.
              }*/
        }

       
        }



    }





