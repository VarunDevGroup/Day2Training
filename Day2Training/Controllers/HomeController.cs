using System.Diagnostics;
using Day2Training.Models;
using Microsoft.AspNetCore.Mvc;
using DBLayer;
using DBLayer.Models;

namespace Day2Training.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Day2AppContext dbConext = new Day2AppContext();
            var products = dbConext.Products.ToList();

            return View(products);
        }

        //CRUD
        //READ
        //DELETE

        public IActionResult Create()
        {
            return View("CreateData");
        }

        [HttpPost]
        public IActionResult Create(Product incomingData)
        {
            Day2AppContext dbConext = new Day2AppContext();
            dbConext.Products.Add(incomingData);
            dbConext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            Day2AppContext dbConext = new Day2AppContext();
            var product = dbConext.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveData(Product incomingData)
        {
            Day2AppContext dbConext = new Day2AppContext();
            dbConext.Products.Update(incomingData);
            dbConext.SaveChanges();
            return RedirectToAction("Index");
        }

        //UPDATE
        public IActionResult Delete(int id)
        {
            Day2AppContext dbConext = new Day2AppContext();
            dbConext.Products.Remove(dbConext.Products.Find(id));
            dbConext.SaveChanges();

            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
