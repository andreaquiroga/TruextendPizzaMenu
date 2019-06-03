using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaWebAPI.Repositories
{
    public class PizzaIngredientRepository
    {
        PizzaPlaceEntities entities = new PizzaPlaceEntities();
        public void AddPizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            entities.PizzaIngredients.Add(pizzaIngredient);
            entities.SaveChanges();
        }

        public bool DeletePizzaIngredient(int ingredientId, int pizzaId)
        {
            PizzaIngredient ingredientToDelete = entities.PizzaIngredients.Where(pi => pi.IngredientId == ingredientId && pi.PizzaId == pizzaId).FirstOrDefault();
            if (ingredientToDelete != null)
            {
                entities.PizzaIngredients.Remove(ingredientToDelete);
                entities.SaveChanges();
                return true;
            }
            return false;

        }
    }
}