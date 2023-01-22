using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CookingMethod { get; set; }
        public int Time { get; set; }

        public List<IngredientsModels> inglist;

        public override string ToString()
        {
            return $"id={Id}, name={Name}, image= {Image}, cooking method= {CookingMethod} Time= {Time}";
        }
    }
}
