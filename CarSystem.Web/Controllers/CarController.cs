using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarSystem.Data;
using CarSystem.Models;
using CarSystem.Web.Models.CarsMod;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Threading.Tasks;

namespace CarSystem.Web.Controllers
{
    public class CarController : BaseController

    {

        public CarController(IUnitOfWork data) : base(data)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCar(int Id)
        {

            var car = this.Data.Cars.GetCarById(Id).SingleOrDefault(x => x.Id == Id);

            var carViewModel = Mapper.Map<CarViewModel>(car);

            return View(carViewModel);
        }


        public ActionResult GetCars(int? page, int id)
        {

            var car = this.Data.Cars.GetAllCarsByModelId(id).ProjectTo<CarViewModel>().ToList();


            var viewModel = new AutoViewModel()
            {
                CarCollection = car
            };

            var pageNumber = page ?? 1;
            var pageSize = 5;
            return View(viewModel.CarCollection.ToPagedList(pageNumber, pageSize));

        }
        [HttpGet]
        public ActionResult Picture(int Id)
        {
            var picture = this.Data.Cars.GetCarById(Id).SingleOrDefault(x => x.Id == Id);
            var pictureViewModel = Mapper.Map<PictureViewModel>(picture);

            return View(pictureViewModel);
        }

        [HttpGet]
        public ActionResult ViewAllCars()
        {
            var cars = this.Data.Cars.All().ProjectTo<CarViewModel>().ToList();

            //var viewModel=Mapper.Map<List<CarViewModel>>(cars);


            return View(cars);
        }
      
        public JsonResult GetCarModelsByBrandId(int BrandId)
        {

            List<SelectListItem> CarModel = this.Data.CarModels.GetCarModelsByBrandId(BrandId)
                .Select(x => new SelectListItem()
                 {
                     Value = x.Id.ToString(),
                     Text = x.ModelName
                 }).ToList();

            //ViewData["CarModels"] = CarModel;
            //return Json(new SelectList(CarModel.ToArray(),"Id","ModelName"),JsonRequestBehavior.AllowGet);
            return Json(CarModel,JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddCar()
        {
            var db = new CarSystemDbContext();
            List<SelectListItem> items = db.Brands.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.BrandName
            }).ToList();
            ViewBag.Brand = items;
            var viewModel = new AddCarViewModel();
            viewModel.Brands = items;

            // viewModel.CarModels = model;

            return View(viewModel);

        }

        [HttpPost]
        public ActionResult AddCar(AddCarViewModel car, HttpPostedFileBase file)
        {

            
            if (!ModelState.IsValid || file == null)
            {
                return View(ModelState);
            }
            
            var carToAdd = Mapper.Map<Car>(car);

            if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                || Path.GetExtension(file.FileName).ToLower() == ".png"
                || Path.GetExtension(file.FileName).ToLower() == ".gif"
                || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
            {
                var path = Path.Combine(Server.MapPath("~/Images"), file.FileName);
                file.SaveAs(path);
                carToAdd.PicturePath = file.FileName;
            }

            try
            {
                var userId = User.Identity.GetUserId();
                var currentUser = this.Data
                    .Users
                    .All()
                    .SingleOrDefault(x => x.Id == userId);

                //carToAdd.Brand = car.Brand;
                //carToAdd.Mileage = car.Mileage;
                //carToAdd.DateManufacturer = car.Year;
                this.Data.Cars.Add(carToAdd);

                carToAdd.CarModelsId = car.CarModelsId;
                

                this.Data.SaveChanges();
                return RedirectToAction("ViewAllCars", "Car");

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                      
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


           
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            Car car = this.Data.Cars.GetById(Id);
            if (car == null)
            {
                return HttpNotFound();
            }

            this.Data.Cars.DeleteById(Id);
            this.Data.SaveChanges();
            return RedirectToAction("ViewAllCars");
        }

    }
}