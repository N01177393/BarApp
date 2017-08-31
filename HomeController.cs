using System.Collections.Generic;   
using System.Web.Mvc;
using BartenderApp.Models;
using HtmlAgilityPack;

namespace BartenderApp.Controllers
{
    public class HomeController : Controller
    {

        
        private static int id = 0;
        

        
        public static List<Drink> Orders = new List<Drink>();
        


        
        private static List<Drink> drinks
            = new List<Drink>()
            {
                new Drink {Name = "Bronx Cocktail", Description = "Dry and sweet vermouth with orange juice", Price = 10},
                new Drink {Name = "French Martini", Description = "Raspberry liqueur and pineapple juice", Price = 16},
                new Drink {Name = "Gimlet", Description = "Lime cordial", Price = 19},
                new Drink {Name = "Saketini", Description = "Sake instead of vermouth", Price = 18}
            };


        
        public ActionResult Index() 
        {
            
            return View(drinks);
        }  


        
        public RedirectToRouteResult Order(Drink drink) 
        {
            drink.Id = ++id;
            Orders.Add(drink);
            return RedirectToAction("Index");
        }
        
    }
}

