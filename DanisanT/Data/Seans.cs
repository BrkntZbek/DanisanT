using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class Seans :RealmObject
    {
        [PrimaryKey]
        public int SeansId { get; set; }
        public string Seans_İsimSoyisim { get; set; }
        public int SeansDanisanId { get; set; }
        
        public string Tarih { get; set; }
        public string Saat { get; set; }
        public int Odeme { get; set; }

        public string Seans_Telefon { get; set; }   
        public string Cash { get; set; }
        public string SeansTuru { get; set; }
        public int OfisOdeme { get; set; }
    }
}
