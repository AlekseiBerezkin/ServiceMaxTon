using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model.DataBase
{
    public class CompletedWork
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public int Transparency { get; set; }
        public double Lenght { get; set; }
        public int Cash { get; set; }
        public string Manufacturer { get; set; }

    }
}
