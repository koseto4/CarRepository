
namespace CarSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        private ICollection<Car> cars;

        public CarModel()
        {
            this.cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }
       
        public string ModelName { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }

        }

    }
}
