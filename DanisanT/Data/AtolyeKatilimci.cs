using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class AtolyeKatilimci :RealmObject
    {
         public int Katilimci_ID { get; set; }
        
        public int Katilimci_Danisan_ID { get; set; }   
        public string Katilimci_İsim { get; set; }
        public string Katilimci_Telefon { get; set; }   
      
        public int Atolye_ID { get; set; }  
        public string Atolye_İsim { get; set; } 
        public int Odeme { get; set; }
          
    }
}
