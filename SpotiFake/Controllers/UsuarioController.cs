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
    
    public class UsuarioController : Controller
    {
        SpotiFakeContext conexion = new SpotiFakeContext();
        // GET: Usuario
        [Authorize]
        public ActionResult UsuarioIndex(Usuario usuario)
        {
            return View(usuario);
        }
        public ActionResult logOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult GuardarUsuario(Usuario usuario)
        {
            if (conexion.Usuarios.Any(o => o.correoElectronico == usuario.correoElectronico))
                ModelState.AddModelError("Correo", "el correo ya existe!");
            if (!ModelState.IsValid) return View("NuevoUsuario", usuario);
            usuario.fechaCreación = DateTime.Now;
            usuario.rol = "Usuario";
            conexion.Usuarios.Add(usuario);
            conexion.SaveChanges();
            //ViewBag.IdUsuario = usuario.idUsuario;

            return View("UsuarioIndex",usuario);
        }
        public ViewResult NuevoUsuario()
        {
            return View("NuevoUsuario", new Usuario());
        }
        
        public ActionResult AdminIndex(Usuario usuario)
        {
            return View();
        }
    }
}