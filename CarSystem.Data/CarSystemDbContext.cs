

using CarSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CarSystem.Data
{
    public class CarSystemDbContext : IdentityDbContext<User>
    {
        public CarSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Car> Cars { get;set;}

        public virtual IDbSet<CarModel> CarModels { get; set; }
       
        public virtual IDbSet<Brand> Brands { get; set; }

        public static CarSystemDbContext Create()
        {
            return new CarSystemDbContext();
        }
    }
}
