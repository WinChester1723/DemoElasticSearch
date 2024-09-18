using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoElasticSearchApp.Models
{
    public class Product
    {
        public string? Title { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
    }
}