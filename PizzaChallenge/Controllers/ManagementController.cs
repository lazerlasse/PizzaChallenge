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
		public Category Category { get; set; }

		[BindProperty]
		public IList<Product> ProductsList { get; private set; }

		[BindProperty]
		public IList<Ingredient> IngredientsList { get; private set; }

		[BindProperty]
		public IList<Category> CategoriesList { get; private set; }

		// GET: Management/Index - Product list.
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ProductsList = await db.Product.AsNoTracking().ToListAsync();

			return View(ProductsList);
		}

		// GET: Management/ProductDetails/5
		[HttpGet]
		public async Task<IActionResult> ProductDetails(int id)
		{
			Product = await db.Product.FindAsync(id);
			if (Product == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(Product);
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

		//**************************************************************//
		//******************* Ingredient Section ***********************//
		//**************************************************************//

		// GET: Management/Ingredients - Ingredient Index
		[HttpGet]
		public async Task<IActionResult> Ingredients()
		{
			IngredientsList = await db.Ingredient.AsNoTracking().ToListAsync();

			return View(IngredientsList);
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

		// Get: Management/DeleteIngredient/5
		[HttpGet]
		public async Task<IActionResult> DeleteIngredient(int id)
		{
			Ingredient ingredient = await db.Ingredient.FindAsync(id);

			if (ingredient == null)
			{
				return View("NotFound");
			}
			else
			{
				return View(ingredient);
			}
		}

		// POST: Management/DeleteIngredient/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteIngredient(int id, string confirmButton)
		{
			Ingredient ingredient = await db.Ingredient.FindAsync(id);

			if (ingredient == null)
				return View("NotFound");

			db.Ingredient.Remove(ingredient);
			await db.SaveChangesAsync();

			return RedirectToAction(nameof(Ingredients));
		}

		//**************************************************************//
		//********************* Category Section ***********************//
		//**************************************************************//

		// GET: Management/Categories - Category Index.
		[HttpGet]
		public async Task<IActionResult> Categories()
		{
			CategoriesList = await db.Category.AsNoTracking().ToListAsync();

			return View(CategoriesList);
		}

		// GET: Management/CreateCategory
		[HttpGet]
		[ActionName("CreateCategory")]
		public IActionResult CreateCategoryGet()
		{
			return View();
		}

		// POST: Management/CreateCategory
		[HttpPost]
		[ActionName("CreateCategory")]
		public async Task<IActionResult> CreateCategoryPost()
		{
			try
			{
				if (!ModelState.IsValid) return View();

				db.Category.Add(Category);
				await db.SaveChangesAsync();

				return RedirectToAction(nameof(Categories));
			}
			catch
			{
				return View();
			}
		}

		// Get: Management/DeleteCategory/5
		[HttpGet]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			Category category = await db.Category.FindAsync(id);

			if (category == null)
			{
				return View("NotFound");
			}
			else
			{
				return View(category);
			}
		}

		// POST: Management/DeleteCategory/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteCategory(int id, string confirmButton)
		{
			Category category = await db.Category.FindAsync(id);

			if (category == null)
				return View("NotFound");

			db.Category.Remove(category);
			await db.SaveChangesAsync();

			return RedirectToAction(nameof(Categories));
		}
	}
}
