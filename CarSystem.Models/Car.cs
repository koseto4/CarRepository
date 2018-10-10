namespace CarSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string Engine { get; set; }

        public int Mileage { get; set; }

        public int CarModelsId { get; set; }

        public virtual CarModel CarModels { get; set; }

        public int DateOfManufacturer { get; set; }

        [DefaultValue(Color.Black)]
        public Color Color { get; set; }

        public decimal Price { get; set; }

        public string PicturePath { get; set; }

        public string Description { get; set; }
    }
}
