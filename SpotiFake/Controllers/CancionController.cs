using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class CancionController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        // GET: Cancion
        public ActionResult Index()
        {
            var cancion = spotiFakeContext.Cancions.ToList();
            return View("Index", cancion);
        }

        public ViewResult registrarCancion()
        {
            return View("FormularioCancion", new Cancion());
        }

        public ActionResult agregar(Cancion cancion)
        {
            spotiFakeContext.Cancions.Add(cancion);
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}