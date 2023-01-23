using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using ClassLibrary2;


namespace WebApplication1.Controllers
{
    public class RecipeController : ApiController
    {
        cgroup100DbContext db = new cgroup100DbContext();

        // GET: api/Recipe
        public IHttpActionResult Get()
        {
            List<RecipeModel> reclist;
            
            try
            {
                reclist = db.Recipes.Select(r => new RecipeModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Image = r.Image,
                    CookingMethod = r.CookingMethod,
                    Time = r.Time,
                    inglist = r.Ingredient.Select(i => new IngredientsModels
                    {
                        Id = i.Id,
                        Image = i.Image,
                        Calories = i.Calories,
                        Name = i.Name
                    }).ToList()
                }).ToList();

                return Ok(reclist);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
                      
        }

        // GET: api/Recipe/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recipe
       [HttpPost]
       [Route("api/createrecipe")]
        public IHttpActionResult Post([FromBody] RecipeModel value)
        {
            #region
            //Ingredient gal = new Ingredient();

            //gal.Id = 5;
            //gal.Name = "omer";
            //gal.Image = "google";
            //gal.Calories = 23;

            //List<Ingredient> omer = new List<Ingredient>();
            //omer.Add(gal);

            //var a = new Recipes
            //{
            //    Id = 6,
            //    Name = "gal",
            //    CookingMethod = "chop",
            //    Image = "%%",
            //    Ingredient = omer,
            //    Time = 2

            //};
            #endregion
            try
            {
                RecipeModel i = value;
                Recipes x = new Recipes();
                x.Name = i.Name;
                x.Image = i.Image;
                x.Time = i.Time;
                x.CookingMethod = i.CookingMethod;
                
                List<Ingredient> ing = new List<Ingredient>();
                foreach (IngredientsModels item in i.inglist)
                {
                    ing.Add(db.Ingredient.FirstOrDefault(y => y.Id == item.Id));
                }
                x.Ingredient = ing;
                db.Recipes.Add(x);
                db.SaveChanges();
                return Ok();
                // return Created(new Uri(Request.RequestUri.AbsoluteUri + i.recipeId), i);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        // PUT: api/Recipe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recipe/5
        public void Delete(int id)
        {
        }
    }
}
