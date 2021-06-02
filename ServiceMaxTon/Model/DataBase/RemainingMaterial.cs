using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model.DataBase
{
    public class RemainingMaterial
    {
        public int id { get; set; }
        public int lenght { get; set; }
        public string manufacturer { get; set; }
        public DateTime Date { get; set; }
        public int Transparency {get; set;}
    }
}
