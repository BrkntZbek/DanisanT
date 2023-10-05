using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class Notlar2:RealmObject
    {
        public int NotID { get; set; }
        public string Baslik { get; set; }
        public int DanisanID { get; set; }
        public string Danısan_İsim { get; set; }
        public int Seans_ID { get; set; }
        public string Not { get; set; }
    }
}
