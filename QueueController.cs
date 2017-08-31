using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BartenderApp.Models;

namespace BartenderApp.Controllers
{
     public class QueueController : Controller
    {
        
        private static List<Drink> ready = new List<Drink>();

        
        public ActionResult ViewOrdersTable () 

        {
            return View(HomeController.Orders);
        }

       
       public RedirectToRouteResult Prepared(Drink drink)
        {
            ready.Add(drink);

           var drinkToRemove = HomeController.Orders.Where(x => x.Id == drink.Id);      
            HomeController.Orders.Remove(drinkToRemove.FirstOrDefault());

            return RedirectToAction("ViewOrdersTable");  
        }


        
        public ActionResult ViewPreparedTable() 

        {
            return View(ready); 
        }

        
        
        public RedirectToRouteResult Served(Drink drink)
        {
            ready.RemoveAll(x => x.Id == drink.Id);
            return RedirectToAction("ViewPreparedTable");
        }

    }
}