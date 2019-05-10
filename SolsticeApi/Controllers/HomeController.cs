using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SolsticeApi.Controllers
{
    using SolsticeData;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            var dataContext = new SolsticeDataContext();
            
            ViewBag.List = new List<string>();
            foreach (var modelContact in dataContext.Contacts)
            {
                ViewBag.List.Add(modelContact.Name + modelContact.Id);
            }


            return View(ViewBag);
        }
    }
}
