using CarSystem.Models;
using System.Data.Entity;

namespace CarSystem.Data
{
    public interface IUnitOfWork
    {

        DbContext Context { get; }

        CarRepository Cars { get; }

        CarModelRepository CarModels { get; }

        IRepository<Brand> Brands { get; }

        IRepository<User> Users { get; }

        void Dispose();

        int SaveChanges();
    }
}
