using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneStopBuy.Models
{
    public class Warranty
    {
        public string Id { get; set; }

        public string warrantyName { get; set; }
        public int warrantyYears { get; set; }
        public string warrantyCoverage { get; set; }
    }
}
