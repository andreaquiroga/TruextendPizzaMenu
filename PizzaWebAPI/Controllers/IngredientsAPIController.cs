using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PizzaWebAPI.Repositories;


namespace PizzaWebAPI.Controllers
{
    public class IngredientsAPIController : ApiController
    {
        private IngredientRepository repository = new IngredientRepository();

        // GET: api/IngredientsAPI
        public IEnumerable<Ingredient> GetIngredients()
        {
            return repository.GetIngredients();
        }

        // GET: api/IngredientsAPI/5
        [ResponseType(typeof(Ingredient))]
        public IHttpActionResult GetIngredient(int id)
        {
            Ingredient ingredient = repository.GetIngredient(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // PUT: api/IngredientsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIngredient(int id, Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            try
            {
                repository.UpdateIngredient(ingredient);
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/IngredientsAPI
        [ResponseType(typeof(Ingredient))]
        public IHttpActionResult PostIngredient(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.AddIngredient(ingredient);

            return CreatedAtRoute("DefaultApi", new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/IngredientsAPI/5
        [ResponseType(typeof(Ingredient))]
        public IHttpActionResult DeleteIngredient(int id)
        {
            if(repository.DeleteIngredient(id))
            {
                return Ok();
            }
            return NotFound();
        }

        
    }
}