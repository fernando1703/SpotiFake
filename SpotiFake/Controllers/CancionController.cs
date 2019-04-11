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
            cancion.fechaRegistro = DateTime.Now;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult modificar(int id)
        {
            var cancion = spotiFakeContext.Cancions.Where(o => o.idCancion == id).FirstOrDefault();
            return View("FormularioModificar", cancion);
        }

        public RedirectToRouteResult actualizar(Cancion cancion)
        {
            Cancion cancionBD = spotiFakeContext.Cancions.Where(y => y.idCancion == cancion.idCancion).FirstOrDefault();
            cancionBD.nombre = cancion.nombre;
            cancionBD.artista = cancion.artista;
            cancionBD.album = cancion.album;
            cancionBD.genero = cancion.genero;
            cancionBD.duracionCancion = cancion.duracionCancion;
            cancionBD.fechaLanzamiento = cancion.fechaLanzamiento;
            cancionBD.imagen = cancion.imagen;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult eliminar(int id)
        {
            var cancion = spotiFakeContext.Cancions.Where(d => d.idCancion == id).FirstOrDefault();
            spotiFakeContext.Cancions.Remove(cancion);
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}