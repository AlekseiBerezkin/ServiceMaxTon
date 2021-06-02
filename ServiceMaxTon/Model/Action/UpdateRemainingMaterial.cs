using ServiceMaxTon.Data;
using ServiceMaxTon.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceMaxTon.Model.Action
{
    public class UpdateRemainingMaterial
    {
        AppDbContext db = new AppDbContext();
        //RemainingMaterial RM = new RemainingMaterial();

        public void addRemainingMaterialInformation(Material material)
        {
            var rm = db.RemainingMaterial.Where(p => p.Transparency == material.Transparency);

            RemainingMaterial remainingMaterial = new RemainingMaterial();

            if (rm.Any())
            {
                remainingMaterial = rm.Single();
                remainingMaterial.lenght+= material.lenght;
            }
            else
            {
                remainingMaterial.lenght = material.lenght;
                remainingMaterial.manufacturer = material.manufacturer;
                remainingMaterial.Transparency = material.Transparency;
                db.Add(remainingMaterial);
                
            }
            db.SaveChanges();


        }

        public void updateRemainingMaterialInformation(CompletedWork completedWork)
        {
            var cw = db.RemainingMaterial.Where(p => p.Transparency == completedWork.Transparency);

            RemainingMaterial remainingMaterial= new RemainingMaterial();

            if (cw.Any())
            {
                remainingMaterial = cw.Single();
                remainingMaterial.lenght -= completedWork.Lenght;
            }
            else
            {
                //реализовать обработку ошибки при отсутствии инфы в таблице

            }
            db.SaveChanges();


        }
    }
}
