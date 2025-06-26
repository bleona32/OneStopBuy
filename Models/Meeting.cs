using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; internal set; }
    }
}
