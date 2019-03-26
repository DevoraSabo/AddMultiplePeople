using ListPplJsAddButton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListPplJsAddButton.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            IEnumerable<Person> ppl = mgr.GetPeople();
            return View(ppl);
        }

        public ActionResult ShowAddPerson()
        {

            return View();
        }

        public ActionResult AddPerson(List<Person> People)
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            foreach (Person p in People)
            {
                mgr.AddPerson(p);
            }

            return Redirect("/Home/Index");
        }


    }
}