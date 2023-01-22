using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IngredientsModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Calories { get; set; }

        public override string ToString()
        {
            return $"id={Id}, name={Name}, image= {Image}, calories= {Calories}";
        }
    }
}