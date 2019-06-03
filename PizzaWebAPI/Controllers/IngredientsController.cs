using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PizzaWebAPI;
using PizzaWebAPI.Models;

namespace PizzaWebAPI.Controllers
{
    public class IngredientsController : Controller
    {
        private HttpClient client = new HttpClient();

        private void setUpClient()
        {
            client.BaseAddress = new Uri("http://localhost:27328/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Ingredients
        public async Task<ActionResult> Index()
        {
            using ( client )
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("IngredientsAPI");
                if (response.IsSuccessStatusCode)
                {
                    var ingredients = response.Content.ReadAsAsync<IEnumerable<Ingredient>>().Result;
                    return View(ingredients);
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: Ingredients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("IngredientsAPI/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var ingredient = response.Content.ReadAsAsync<Ingredient>().Result;
                    return View(ingredient);
                }
                else
                {
                    return View();
                }
            }
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Ingredient ingredient)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync("IngredientsAPI/", ingredient);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(ingredient);

                }
            }          
        }

        // GET: Ingredients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("IngredientsAPI/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var ingredient = response.Content.ReadAsAsync<Ingredient>().Result;
                    return View(ingredient);
                }
                else
                {
                    return View();
                }
            }
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Ingredient ingredient)
        {
            using (client)
            {
                setUpClient();
                HttpResponseMessage response = client.PutAsJsonAsync("IngredientsAPI/"+ ingredient.Id.ToString(), ingredient).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(ingredient);

                }
            }
        }

        // GET: Ingredients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            using (client)
            {
                setUpClient();
                HttpResponseMessage response = await client.GetAsync("IngredientsAPI/" + id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var ingredient = response.Content.ReadAsAsync<Ingredient>().Result;
                    return View(ingredient);
                }
                else
                {
                    return View();
                }
            }
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (client)
            {
                setUpClient();
                var Result = client.DeleteAsync("IngredientsAPI/"+ id.ToString()).Result;
                if (Result.IsSuccessStatusCode == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();

                }
            }
            
        }
    }
}
