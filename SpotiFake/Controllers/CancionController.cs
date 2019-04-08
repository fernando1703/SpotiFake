using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class CancionController : Controller
    {
        // GET: Cancion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult agregar()
        {
            return View();
        }
    }
}