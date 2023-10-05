using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class İptalSeans :RealmObject
    {
        [PrimaryKey]
        public int İptalID { get; set; }
        public int SeansID { get; set; }    
        public int SeansDanisanID { get; set; } 
        public string SeansDanisan_İsim { get; set; }
        public string SeansTarihi { get; set; }
        public string SeansİptalTarihi { get; set; }    
        public string SeansSaati { get; set; }  
        public int Odeme { get; set; }  
        public string Telefon { get; set; } 
        public string Cash { get; set; }    
        public string SeansTuru { get; set; }   
        public int OfisOdeme { get; set; }  

    }
}
