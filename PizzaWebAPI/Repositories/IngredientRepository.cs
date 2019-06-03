using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace PizzaWebAPI.Repositories
{
    public class IngredientRepository
    {
        PizzaPlaceEntities entities = new PizzaPlaceEntities();


        public IEnumerable<Ingredient> GetIngredients()
        {
            return entities.Ingredients;
        }

        public Ingredient GetIngredient(int id)
        {
            Ingredient ingredient = entities.Ingredients.Find(id);
            return ingredient;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            entities.Ingredients.Add(ingredient);
            entities.SaveChanges();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            Ingredient existentIngredient = GetIngredient(ingredient.Id);
            if (existentIngredient != null)
            {
                entities.Entry(existentIngredient).State = EntityState.Modified;
                entities.Entry(existentIngredient).CurrentValues.SetValues(ingredient);
            }
            entities.SaveChanges();
        }

        public bool DeleteIngredient(int id)
        {
            Ingredient ingredient = GetIngredient(id);
            if (ingredient != null)
            {
                entities.Ingredients.Remove(ingredient);
                entities.SaveChanges();
                return true;
            }
            else
                return false;
            
        }

    }
}