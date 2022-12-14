using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DataAccessLayer.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int Year { get; set; }
        public bool HaveOscar { get; set; } 
    }
}
