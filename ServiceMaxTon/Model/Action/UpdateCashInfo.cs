using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model.Action
{
    public static class UpdateCashInfo
    {
        private static Cash cash = new Cash();
        private static AppDbContext db = new AppDbContext();
        public static void  updateCashInfo(double NetProfit,int DirtyProfit)
        {
            

            

            var cashDB = db.Cash;

            if (cashDB.Any())
            {
                cash = cashDB.Single();
                cash.NetProfit += NetProfit;
                cash.DirtyProfit += DirtyProfit;
            }
            else
            {
                cash.DirtyProfit = 0;
                cash.NetProfit = 0;
                db.Add(cash);
            }
            db.SaveChanges();
        }

       
    }
}
