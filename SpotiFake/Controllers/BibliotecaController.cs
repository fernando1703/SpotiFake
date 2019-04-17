using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class BibliotecaController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();
        // GET: Biblioteca
        [Authorize]
        public ActionResult Index(int idUsuario)
        {
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == idUsuario).First();
            ViewBag.AccesoConfirmado = usuarioConfirmado;
            var listaReproduccion = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();
            return View(listaReproduccion);
        }
        public ViewResult RegistrarListaReproduccion(int idUsuario)
        {
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == idUsuario).First();
            ViewBag.AccesoConfirmado = usuarioConfirmado;
            return View(new ListaReproduccion());
        }
        public ActionResult Agregar(ListaReproduccion LS)
        {
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == LS.idTemporal).First();
            ViewBag.AccesoConfirmado = usuarioConfirmado;

            LS.idUsuario = LS.idTemporal;
            LS.idTemporal = 0;
            spotiFakeContext.ListaReproduccions.Add(LS);
            spotiFakeContext.SaveChanges();
            var ListaReproduciones = spotiFakeContext.ListaReproduccions.ToList();
            return View("Index", ListaReproduciones);
        }
    }
}