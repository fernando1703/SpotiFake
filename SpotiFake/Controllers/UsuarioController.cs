using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SpotiFake.Controllers
{
    public class UsuarioController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        // GET: Usuario
        [Authorize]
        public ActionResult UsuarioIndex()
        {
            return View();
        }
        public ActionResult logOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult GuardarUsuario(Usuario usuario)
        {
            if (spotiFakeContext.Usuarios.Any(o => o.correoElectronico == usuario.correoElectronico))
                ModelState.AddModelError("Correo", "el correo ya existe!");
            if (!ModelState.IsValid) return View("NuevoUsuario", usuario);
            usuario.fechaCreación = DateTime.Now;
            usuario.rol = "Usuario";
            spotiFakeContext.Usuarios.Add(usuario);
            spotiFakeContext.SaveChanges();
            //ViewBag.IdUsuario = usuario.idUsuario;

            return View("UsuarioIndex", usuario);
        }
        public ViewResult NuevoUsuario()
        {
            return View("NuevoUsuario", new Usuario());
        }
        [Authorize]
        public ActionResult AdminIndex(Usuario usuario)
        {
            return View();
        }
        [Authorize]
        public ActionResult SysIndex(Usuario usuario)
        {
            return View();
        }
        public ActionResult Ingreso(Usuario usuario)
        {
            Usuario usuarioConfirmado;
            //con js ya no es importante usar el try catch 
            try
            {
                usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.correoElectronico == usuario.correoElectronico && o.contraseña == usuario.contraseña).First();
                ViewBag.AccesoConfirmado = usuarioConfirmado;
                if (usuarioConfirmado.rol == "Admin")
                {

                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return View("AdminIndex");
                }
                if (usuarioConfirmado.rol == "Sys")
                {

                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return View("SysIndex");
                }
                FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);

                return View("UsuarioIndex");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Login");
            }

        }


    }
}