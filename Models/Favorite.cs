using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Models
{
    public class Favorite
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("product_Id")]
        public int Product_Id { get; set; }
        /*public object product { get; internal set; }*/
        //public product product { get; set; }
    }
}

