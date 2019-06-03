using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaWebAPI.Repositories
{
    public class PizzaRepository
    {
        PizzaPlaceEntities entities = new PizzaPlaceEntities();

        public IQueryable<Pizza> GetPizzas()
        {
            return entities.Pizzas;
        }

        public Pizza GetPizza(int id)
        {
            return entities.Pizzas.Find(id);
        }

    }
}