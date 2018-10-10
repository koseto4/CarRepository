using CarSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Data
{
    public class CarRepository : GenericRepository<Car>
    {
        public CarRepository(DbContext context) : base(context)
        {
        }


        public List<Car> GetAllForCustomer()
        {
            return new List<Car>();
        }

        public IQueryable<Car> GetAllCarsByModelId(int id)
        {
            return All().Where(x => x.CarModels.BrandId == id);
        }
        public List<Car> GetCarById(int id)
        {
            return All().Where(x => x.Id == id).ToList();
        }
       
    }
    
}
