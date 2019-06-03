using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaWebAPI.Converters
{
    public static class IngredientConverter
    {
        public static Models.Ingredient GetModel(Ingredient ingredientEntity)
        {
            Models.Ingredient ingredient = new Models.Ingredient();
            ingredient.Id = ingredientEntity.Id;
            ingredient.Name = ingredientEntity.Name;
            return ingredient;
        }
        public static List<Models.Ingredient> getListIngredientsModel(IEnumerable<Ingredient> ingredients)
        {
            List<Models.Ingredient> modelIngredients = new List<Models.Ingredient>();
            foreach (var ingredient in ingredients)
            {
                Models.Ingredient modelIngredient = new Models.Ingredient();
                modelIngredient = GetModel(ingredient);
                modelIngredients.Add(modelIngredient);
            }
            return modelIngredients;
        }
    }
}