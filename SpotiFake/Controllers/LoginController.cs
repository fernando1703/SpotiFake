using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SpotiFake.Controllers
{
    public class LoginController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult messenge()
        {
            return View();
        }
    }
}