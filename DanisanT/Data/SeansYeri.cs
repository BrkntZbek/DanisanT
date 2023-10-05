using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanisanT.Data
{
    public class SeansYeri: RealmObject
    {
        public int YerId { get; set; }
        public string SeansYer { get; set; }
        public int Kira { get; set; }
    }
}
