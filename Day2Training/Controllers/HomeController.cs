using System.Diagnostics;
using Day2Training.Models;
using Microsoft.AspNetCore.Mvc;
using DBLayer;
using DBLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace Day2Training.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
         //   Day2AppContext dbConext = new Day2AppContext();
            var products = new List<Product>();

            return View(products);
        }

        //CRUD
        //READ
        //DELETE

        [Authorize(Roles ="HR")]
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

            ViewBag.Message = "Data Updated Successfully";



            return View(product);
        }

        [HttpPost]
        public IActionResult SaveData(Product incomingData)
        {
            Day2AppContext dbConext = new Day2AppContext();
            dbConext.Products.Update(incomingData);
            dbConext.SaveChanges();
           
            TempData["message"]="Data Updated Successfully";

            return RedirectToAction("Delete");

            //return RedirectToAction("Delete?id=" + incomingData.Id);
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
