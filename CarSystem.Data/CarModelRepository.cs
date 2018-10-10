using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Data
{
       public class CarModelRepository: GenericRepository<CarModel>
    {
        public CarModelRepository(DbContext context) : base(context)
        {
        }

        public List<CarModel> GetCarModelsByBrandId(int? id)
        {
            return this.All().Where(x => x.BrandId == id).ToList();
        }
    }
}
