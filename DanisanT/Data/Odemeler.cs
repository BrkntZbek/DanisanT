using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class Odemeler :RealmObject
    {
        [PrimaryKey]
        public int OdemeID { get; set; }
        public string Odeyen_Danisan { get; set; }
        public int Odeyen_Danisan_ID { get; set; }
        public int Odenen { get; set; }
        public string OdemeNotu { get; set; }
        public string OdemeTarihi { get; set; }
        
    }
}
