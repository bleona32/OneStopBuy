using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Models
{

    public class Product
    {

        public int Id { get; set; }
        [Required]
        public double Price { get; set; }
        public string Brand { get; set; }
        public int Auto_Production_Year { get; set; }
        [Required]
        public string Engine { get; set; }
        public int EngineSize { get; set; }
        public string Body_Type { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Start_Production { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime End_Production { get; set; }
        [Required]
        [MaxLength(256)]
        public string Photo { get; set; }

        [Required]

        public int Sets { get; set; }
        [Required]
        public int Doors { get; set; }

        public double Fuel_Consumption { get; set; }

        public string Fuel_Type { get; set; }
        public double Acceleration { get; set; }
        public double Max_Speed { get; set; }

        public double Power { get; set; }

        public double Torque { get; set; }

        public bool IsDogan { get; set; }

    }
}
