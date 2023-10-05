using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class Atolye2:RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Atolye_İsim { get; set; }
        public int Atolye_Fiyat { get; set; }
        public string Atolye_Tarih { get; set; }
        public string Atolye_Saat { get; set; }
    }
}
