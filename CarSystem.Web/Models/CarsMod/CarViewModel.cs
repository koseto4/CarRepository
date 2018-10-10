using System;
using CarSystem.Web.Infrastructure;
using CarSystem.Models;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Web.Mvc;
using System.Collections.Generic;

namespace CarSystem.Web.Models.CarsMod
{
    public class CarViewModel
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }
        
        [Display(Name ="Brand")]
     
        public string Brand { get; set; }

        //public List<SelectListItem> Brands { get; set; }

        public string Engine { get; set; }

        [Required]
        [Range(1000, 500000)]
        public int Mileage { get; set; }

        public int CarModelsId { get; set; }

        public string CarModel { get; set; }

       // public List<SelectListItem> CarModels { get; set; }

        public Color Color { get; set; }

        [Required(ErrorMessage = "Number is required!")]
        [Range(300, 1000000)]
        public decimal Price { get; set; }

        public int Year { get; set; }

        public string PicturePath { get; set; }
        
        public string Description { get; set; }

    }
}