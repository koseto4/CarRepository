using CarSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSystem.Web.Models.CarsMod
{
    public class AddCarViewModel : Infrastructure.IMapFrom<Car>
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }

        [Display(Name = "Brand")]

        public string Brand { get; set; }

        [Display(Name = "Brand")]
        public List<SelectListItem> Brands { get; set; }

        public string Engine { get; set; }

        [Required]
        [Range(100, 900000)]
        public int Mileage { get; set; }

        public int CarModelsId { get; set; }

        public string CarModel { get; set; }

        [Display(Name = "Car Model")]
        public List<SelectListItem> CarModels { get; set; }

        [UIHint("Enum")]
        public Color Color { get; set; }

        [Required(ErrorMessage = "Number is required!")]
        [Range(300, 1000000)]
        public decimal Price { get; set; }

        public int Year { get; set; }

        [Display(Name = "Upload picture")]
        public string PicturePath { get; set; }

        [StringLength(1000)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

    }
}