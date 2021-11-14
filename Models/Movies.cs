using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieGalore.Models
{
    public class Movies
    {
        public Movies()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public double ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
