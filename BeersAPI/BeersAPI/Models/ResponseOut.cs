using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersAPI.Models
{
    public class ResponseOut
    {
        public double? id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Ratings> userRatings { get; set; }
    }
}
