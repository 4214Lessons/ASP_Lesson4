using FirstMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FirstMvc.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new()
        {
            new(){ Id = 0, Name = "Kartof", Price = 1.2 },
            new(){ Id = 1, Name = "Alma", Price = 2 },
            new(){ Id = 2, Name = "Armud", Price = 6 },
        };

        public IActionResult GetAll()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            // way 1
            return View(products[id]);

            // way 2
            //ViewBag.Product = products[id];

            // way 3
            //ViewData["Product"] = products[id];

            // way 4
            //var json = JsonSerializer.Serialize(products[id]);
            //TempData["Product"] = json;
            //return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            products.Remove(products.FirstOrDefault(p => p.Id == id));

            return RedirectToAction("GetAll");
        }
    }
}
