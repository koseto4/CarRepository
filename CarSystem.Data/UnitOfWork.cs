﻿using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CarSystem.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();


        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        // public IRepository<Car> Cars => new CarRepository(context);
       public CarRepository Cars => new CarRepository(context);


        public CarModelRepository CarModels => new CarModelRepository(context);
        //{
        // get
        // {
        //   return this.GetRepository<CarModel>();
        //}
        // }


        public IRepository<Brand> Brands => new GenericRepository<Brand>(context);

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }



        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }


        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}

