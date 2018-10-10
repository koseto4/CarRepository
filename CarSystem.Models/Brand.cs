using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Models
{
   public class Brand
    {
        private ICollection<CarModel> carModel;

        public Brand()
        {
            this.carModel = new HashSet<CarModel>();
        }

        [Key]
        public int Id { get; set; }
       
        public string BrandName { get; set; }

        public ICollection<CarModel> CarModel
        {
            get { return this.carModel; }
            set { this.carModel = value; }

        }
    }
}
