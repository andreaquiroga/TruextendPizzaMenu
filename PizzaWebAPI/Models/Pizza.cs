using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaWebAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public int SelectedIngredientId { get; set; }
        
    }
}