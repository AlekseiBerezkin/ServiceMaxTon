using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model.Action
{
    public class UpdateCashInfo
    {
        private Cash cash = new Cash();
        private AppDbContext db = new AppDbContext();
        public void updateCashInfo(int NetProfit,int DirtyProfit)
        {
            checkData();
            cash.NetProfit += NetProfit;
            cash.DirtyProfit += DirtyProfit;
            saveChanges();
        }

        private void saveChanges()
        {
            db.Add(cash);
            db.SaveChanges();
        }

        private void checkData()
        {
            var cashDB = db.Cash;

            if (cashDB.Any())
            {
                cash = cashDB.Single();
            }
            else
            {
                cash.DirtyProfit = 0;
                cash.NetProfit = 0;
            }
        }
    }
}
