using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaChallenge.Model;
using Type = PizzaChallenge.Model.Type;

namespace PizzaChallenge.Controllers
{
    public class ManagementController : Controller
    {
		private PizzaKingContext db = new PizzaKingContext();

		[BindProperty]
		public Ingredient Ingredient { get; set; }

		[BindProperty]
		public Product Product { get; set; }

		[BindProperty]
		public Type Type { get; set; }

		[BindProperty]
		public IList<Product> ProductsList { get; private set; }

		[BindProperty]
		public IList<Ingredient> IngredientsList { get; private set; }

        // GET: Management
        public async Task<IActionResult> Index()
        {
			ProductsList = await db.Product.AsNoTracking().ToListAsync();

			return View(ProductsList);
        }

        // GET: Management/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

		// POST: Management/CreateIngredient
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIngredient()
        {
            try
            {
				if (!ModelState.IsValid) return View();

				db.Ingredient.Add(Ingredient);
				await db.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

		// POST: Management/CreateProduct
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateProduct()
		{
			try
			{
				if (!ModelState.IsValid) return View();

				db.Product.Add(Product);
				await db.SaveChangesAsync();

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

        // GET: Management/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Management/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Management/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Management/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}