using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        SpotiFakeContext conexion = new SpotiFakeContext();
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult NuevoUsuario()
        {
            return View("NuevoUsuario", new Usuario());
        }
        public ActionResult GuardarUsuario(Usuario usuario)
        {
            if (conexion.Usuarios.Any(o => o.correoElectronico == usuario.correoElectronico))
                ModelState.AddModelError("Correo", "el correo ya existe!");
            if (!ModelState.IsValid) return View("NuevoUsuario", usuario);
            usuario.fechaCreación=DateTime.Now;
            usuario.rol = "Usuario";
            conexion.Usuarios.Add(usuario);
            conexion.SaveChanges();

            return RedirectPermanent("/Usuario/Index");
        }
    }
}