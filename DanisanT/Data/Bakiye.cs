using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class Bakiye : RealmObject
    {
        public  int ID { get; set; }
        public int Danisan_ID { get; set; }
        public int Toplambakiye { get; set; }
        public string OdemeTarihi { get; set; } 
        public int SeansSayisi { get; set; }
        public int SeansFiyati { get; set; }

    }
}
