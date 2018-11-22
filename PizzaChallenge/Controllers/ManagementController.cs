using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaChallenge.Model;

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

		// GET: Management/Index
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

		// GET: Management/CreateIngredient
		[HttpGet]
		[ActionName("CreateIngredient")]
		public IActionResult CreateIngredientGet()
		{
			return View();
		}

		// POST: Management/CreateIngredient
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("CreateIngredient")]
		public async Task<IActionResult> CreateIngredientPost()
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

		// GET: Management/CreateProduct
		[HttpGet]
		[ActionName("CreateProduct")]
		public IActionResult CreateProductGet()
		{
			return View();
		}

		// POST: Management/CreateProduct
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("CreateProduct")]
		public async Task<IActionResult> CreateProductPost()
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

		// GET: Management/EditProduct/5
		[HttpGet]
		[ActionName("EditProduct")]
		public async Task<IActionResult> EditProductGet(int id)
		{
			Product = await db.Product.FindAsync(id);
			if (Product == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(Product);
		}

		// POST: Management/EditProduct/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("EditProduct")]
		public async Task<IActionResult> EditProductPost()
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			db.Attach(Product).State = EntityState.Modified;

			try
			{
				await db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{

				throw new Exception($"Customer {Product.Name} Not Found", ex);
			}

			return RedirectToAction(nameof(Index));
		}

		// Get: Management/DeleteProduct/5
		[HttpGet]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			Product product = await db.Product.FindAsync(id);

			if (product == null)
			{
				return View("NotFound");
			}
			else
			{
				return View(product);
			}
		}

		// POST: Management/DeleteProduct/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteProduct(int id, string confirmButton)
		{
			Product product = await db.Product.FindAsync(id);

			if (product == null)
				return View("NotFound");

			db.Product.Remove(product);
			await db.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}
