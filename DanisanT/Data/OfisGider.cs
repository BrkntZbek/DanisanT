using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class OfisGider:RealmObject
    {
        [PrimaryKey]
        public int GiderID { get; set; }
        public string SeansYeri { get; set; }
        public int Kira { get; set; }

        public int Seans_ID { get; set; }
    }
}
