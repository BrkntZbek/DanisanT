using System;
using Realms;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class Danisan : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string İsimSoyisim { get; set; }
        public string Telefon { get; set; }
        public string Aranacak1 { get; set; }
        public int Borc { get; set; }
        public string Bilgi { get; set; }
        public string Cinsiyet { get; set; }
        public string Image { get; set; }
        public int ToplamSeans { get; set; }
    }
}
