namespace CarSystem.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CarSystem.Data.CarSystemDbContext>
    {
        private const string AdministratorUserName = "kocetoo4444@abv.bg";
        private const string AdministratorPassword = "123456";

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CarSystemDbContext context)
        {
            this.SeedBrandswithModels(context);

            this.SeedCars(context);

            this.SeedUsers(context);

        }


        private void SeedUsers(CarSystemDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    UserType = UserType.Admin
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SeedBrandswithModels(CarSystemDbContext context)
        {
            if (context.Brands.Any())
            {
                return;
            }
            string[] brands = new string[] { "Volkswagen", "Audi", "BMV", "Mercedes" };

            for (int i = 0; i < brands.Length; i++)
            {
                var brand = new Brand
                {
                    BrandName = brands[i]

                };
                for (int j = 0; j < 6; j++)
                {
                    string[,] models = new string[4, 6] { { "1", "2", "3", "4", "5", "6" }, { "A3", "A4", "A5", "A6", "A7", "Q7" }, { "530xd", "X5", "X4", "X3", "M4", "M5" }, { "CLK 240", "CLK 320", "E 260", "G 280", "ML 320", "ML 340" } };
                    var carModel = new CarModel
                    {
                        ModelName = models[i, j]
                    };
                    brand.CarModel.Add(carModel);
                }
                context.Brands.Add(brand);
                context.SaveChanges();
            }

        }
        private void SeedCars(CarSystemDbContext context)
        {

            if (!context.Cars.Any())
            {
                for (int i = 1; i < 4; i++)
                {
                    var car = new Car()
                    {
                        Id=i,
                        CarModelsId=3*i,
                        DateOfManufacturer=2008,
                        Mileage=1400*i,
                        Price=6454*i,
                        Engine="1,9TDI",
                        Description="Nice car!"
                    };

                    context.Cars.Add(car);
                }
            }
        }
    }

}

