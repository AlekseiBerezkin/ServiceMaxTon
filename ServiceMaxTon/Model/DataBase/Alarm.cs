using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model.DataBase
{
    public class Alarm
    {
        public int id { get; set; }
        public DateTime DateTime { get; set; }
        public long chatId { get; set; }
    }
}
