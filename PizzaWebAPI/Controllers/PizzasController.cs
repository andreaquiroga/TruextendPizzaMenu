using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using PizzaWebAPI.Converters;

namespace PizzaWebAPI.Controllers
{
    public class PizzasController : Controller
    {
        private HttpClient client = new HttpClient();

        private void setUpClient()
        {
            client.BaseAddress = new Uri("http://localhost:27328/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Pizzas
        public async Task<ActionResult> Index()
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("PizzasAPI");
                if (response.IsSuccessStatusCode)
                {
                    var pizzas = response.Content.ReadAsAsync<IEnumerable<Models.Pizza>>().Result;
                    return View(pizzas);
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: Pizzas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("PizzasAPI/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var pizzaEntity = response.Content.ReadAsAsync<Pizza>().Result;
                    Models.Pizza pizzaModel = new Models.Pizza();
                    pizzaModel = PizzaConverter.GetModel(pizzaEntity);
                    return View(pizzaModel);
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: Pizzas/Create
        public async Task<ActionResult> Create(int? id)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("IngredientsAPI");
                if (response.IsSuccessStatusCode)
                {
                    var ingredients = response.Content.ReadAsAsync<IEnumerable<Ingredient>>().Result;
                    Models.Pizza pizza = new Models.Pizza();
                    pizza.Id = (int)id;
                    pizza.Ingredients = IngredientConverter.getListIngredientsModel(ingredients);
                    return View(pizza);
                }
                return View();
            }
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SelectedIngredientId")] Models.Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                using (client)
                {
                    setUpClient();
                    PizzaIngredient pizzaIngredient = new PizzaIngredient();
                    pizzaIngredient.IngredientId = pizza.SelectedIngredientId;
                    pizzaIngredient.PizzaId = pizza.Id;
                    var Result = await client.PostAsJsonAsync("PizzaIngredientsAPI/", pizzaIngredient);
                    if (Result.IsSuccessStatusCode == true)
                    {
                        return RedirectToAction("Edit", new { id = pizza.Id });
                    }
                }
            }

            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("PizzasAPI/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var pizzaEntity = response.Content.ReadAsAsync<Pizza>().Result;
                    Models.Pizza pizzaModel = new Models.Pizza();
                    pizzaModel = PizzaConverter.GetModel(pizzaEntity);
                    return View(pizzaModel);
                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<ActionResult> DeleteIngredient(int? ingredientId, int? pizzaId)
        {
            using (client)
            {
                setUpClient();
                var Result = client.DeleteAsync("PizzaIngredientsAPI/?ingredientId=" + ingredientId.ToString() + "&pizzaId=" + pizzaId.ToString()).Result;
                if (Result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Edit", new { id = pizzaId });
                }
                else
                {
                    return View();

                }
            }
        }

        

    }
}
