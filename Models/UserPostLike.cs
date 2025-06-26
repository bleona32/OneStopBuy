using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Models
{
    public class UserPostLike
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
    }
}
