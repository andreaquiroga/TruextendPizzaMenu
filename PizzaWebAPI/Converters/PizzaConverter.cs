using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaWebAPI.Converters
{
    public static class PizzaConverter
    {
        public static Pizza GetEntity(Models.Pizza pizzaModel)
        {
            Pizza pizzaEntity = new Pizza();
            pizzaEntity.Id = pizzaModel.Id;
            pizzaEntity.Name = pizzaModel.Name;
            pizzaEntity.PizzaIngredients = new List<PizzaIngredient>();
            foreach (var item in pizzaModel.Ingredients)
            {
                PizzaIngredient pizzaIngredient = new PizzaIngredient();
                pizzaIngredient.IngredientId = item.Id;
                pizzaIngredient.PizzaId = pizzaModel.Id;
                pizzaEntity.PizzaIngredients.Add(pizzaIngredient);
            }
            return pizzaEntity;
        }

        public static Models.Pizza GetModel(Pizza pizzaEntity)
        {
            Models.Pizza pizzaModel = new Models.Pizza();
            pizzaModel.Id = pizzaEntity.Id;
            pizzaModel.Name = pizzaEntity.Name;
            pizzaModel.Ingredients = new List<Models.Ingredient>();
            foreach (var item in pizzaEntity.PizzaIngredients)
            {
                Models.Ingredient ingredient = new Models.Ingredient();
                ingredient.Id = item.Ingredient.Id;
                ingredient.Name = item.Ingredient.Name;
                pizzaModel.Ingredients.Add(ingredient);
            }
            return pizzaModel;
        }
    }
}