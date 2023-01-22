using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using ClassLibrary2;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class IngredientsController : ApiController
    {


        cgroup100DbContext db = new cgroup100DbContext();

        // GET: api/Ingredients
        public IHttpActionResult Get()
        {
            try
            {
                List<IngredientsModels> ing;
                ing = db.Ingredient.Select(i => new IngredientsModels
                {
                    Name = i.Name,
                    Image=i.Image,
                    Calories=i.Calories,
                    Id=i.Id

                }).ToList();
                return Ok(ing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Ingredients/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST: api/Ingredients
        public IHttpActionResult AddNewIngredient([FromBody] Ingredient value) ///Insert information to database
        {
            //return Created(Request.RequestUri.AbsolutePath + value.Id, value); //מהסיכום של ניר, יעזור לקשר דף לריאקט
            try
            {
                db.Ingredient.Add(value);
                db.SaveChanges();
                return Ok(value);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

           
        }      

        // PUT: api/Ingredients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Ingredients/5
        public void Delete(int id)
        {
        }
    }
}
