using la_mia_pizzeria_static.Database;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizzas.ToList();
                return View(pizze);
            }
        }

        public IActionResult Privacy()
        {
           return View();
        }

        public IActionResult Contacts()
        { 
            return View("Contacts");
        }

        public IActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPizza(PizzaModel newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View(newPizza);
            }
            else
            {
                using (PizzaContext db = new PizzaContext())
                {
                    db.Pizzas.Add(newPizza);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }
        public IActionResult PizzaDetails(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel matchPizza = db.Pizzas.Where(pizze => pizze.Id == id).First();
                return View("PizzaDetails", matchPizza);
            }
        }

        public IActionResult SearchPizza(string titleKeyword)
        {
            using (PizzaContext db = new())
            {
                PizzaModel matchedPizza = db.Pizzas.Where(pizze => pizze.Name.Contains(titleKeyword)).First();
                ViewData["titleKeyword"] = titleKeyword;
                return View(matchedPizza);
            }
        }
    }
    
}
