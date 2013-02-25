using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VortexSoft.Bootstrap.Demo.Models;

namespace VortexSoft.Bootstrap.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoForm()
        {
            var model = new DemoFormModel
            {
                DateOfBirth = new DateTime(1984, 1, 1),
                FirstName = "John",
                LastName = "Smith",
                Password = "Hello world"
            };

            return View(model);
        }

        public ActionResult TestPage()
        {
            return View();
        }
    }
}
