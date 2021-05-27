using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Data
{
    public class Expenses
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int CashExpenses { get; set; }
        public DateTime Date { get; set; }
    }
}
