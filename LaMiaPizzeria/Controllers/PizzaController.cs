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

        public IActionResult SearchPizza(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel matchPizza = db.Pizzas.Where(pizze => pizze.Id == id).First();
                return View(matchPizza);
            }
        }
    }
    
}
