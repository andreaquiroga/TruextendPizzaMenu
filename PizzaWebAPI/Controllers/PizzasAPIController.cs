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
    public class PizzasAPIController : ApiController
    {
        private PizzaRepository repository = new PizzaRepository();

        // GET: api/Pizzas
        public IQueryable<Pizza> GetPizzas()
        {
            return repository.GetPizzas();
        }

        // GET: api/Pizzas/5
        [ResponseType(typeof(Pizza))]
        public IHttpActionResult GetPizza(int id)
        {
            Pizza pizza = repository.GetPizza(id);
            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }
              
    }
}