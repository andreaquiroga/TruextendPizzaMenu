using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaWebAPI;
using PizzaWebAPI.Repositories;

namespace PizzaWebAPI.Controllers
{
    public class PizzaIngredientsAPIController : ApiController
    {
        private PizzaIngredientRepository repository = new PizzaIngredientRepository();
        
        // POST: api/PizzaIngredientsAPI
        [ResponseType(typeof(PizzaIngredient))]
        public IHttpActionResult PostPizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddPizzaIngredient(pizzaIngredient);
            return CreatedAtRoute("DefaultApi", new { id = pizzaIngredient.Id }, pizzaIngredient);
        }

        // DELETE: api/PizzaIngredientsAPI/5
        [ResponseType(typeof(PizzaIngredient))]
        public IHttpActionResult DeletePizzaIngredient(int ingredientId, int pizzaId)
        {
            if (repository.DeletePizzaIngredient(ingredientId, pizzaId))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}