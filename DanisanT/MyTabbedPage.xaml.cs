using DanisanT.Views;
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
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            InitializeComponent();
            var page = new AnaSayfa();
            page.IconImageSource = "psiko.png";
            page.Title = "Ana Sayfa";
            

            var Danisanekle = new DanisanEkle();
            Danisanekle.Title = "Danisan Ekle";
            Danisanekle.IconImageSource = "TabbedADD.png";





            var Seanslistesi = new SeansListesi();
            Seanslistesi.Title = "Seans Listesi";
            Seanslistesi.IconImageSource = "Seans.png";
            
            var danisanList = new DanisanListesi();
            danisanList.Title = "Danisan Listesi";
            danisanList.IconImageSource = "DanisanList.png";


            
            
            this.Children.Add(page);
            this.Children.Add(Danisanekle);


            this.Children.Add(Seanslistesi);
            this.Children.Add(danisanList);
            
        }
    }
}