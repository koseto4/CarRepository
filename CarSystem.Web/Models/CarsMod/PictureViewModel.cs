using CarSystem.Models;
using CarSystem.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarSystem.Web.Models.CarsMod
{
    public class PictureViewModel:IMapFrom<Car>
    {
        [Key]
        public int Id { get; set; }

        public string PicturePath { get; set; }
    }
}