using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSystem.Web.Models.CarsMod
{
    public class AutoViewModel
    {
        public ICollection<CarViewModel> VolkswagenCollection { get; set; }

        public ICollection<CarViewModel> AudiCollection { get; set; }
        
        public ICollection<CarViewModel> BMWCollection { get; set; }

        public ICollection<CarViewModel> CarCollection { get; set; }

    }
}