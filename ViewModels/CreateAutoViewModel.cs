using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.ViewModels
{
    public class CreateAutoViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        public int Auto_Production_Year { get; set; }
        public int EngineSize { get; set; }
        public string Body_Type { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Profile Picture")]
        public IFormFile Photo { get; set; }
        public string Engine { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Start_Production { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime End_Production { get; set; }

        [Required]
        public int Sets { get; set; }
        [Required]
        public int Doors { get; set; }
        [Required]
        public double Fuel_Consumption { get; set; }

        public string Fuel_Type { get; set; }
        public double Acceleration { get; set; }
        public int Max_Speed { get; set; }

        public double Power { get; set; }

        public double Torque { get; set; }
        public bool IsDogan { get; set; }

    }
}