using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaChallenge.Model;

namespace PizzaChallenge.Controllers
{
	public class HomeController : Controller
	{
		private PizzaKingContext db = new PizzaKingContext();

		[BindProperty]
		public IList<Product> ProductsList { get; private set; }

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}
        public async Task<IActionResult> Menu()
        {
			ProductsList = await db.Product.AsNoTracking().ToListAsync();

            return View(ProductsList);
        }

        public IActionResult Contact()
		{
            ViewData["Message"] = "Kontakt";

            return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
