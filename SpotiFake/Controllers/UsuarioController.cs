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
        public ActionResult UsuarioIndex(int idUsuario)
        {
            var cancion = spotiFakeContext.Cancions.ToList();
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == idUsuario).First();
            ViewBag.AccesoConfirmado = usuarioConfirmado;
            return View(cancion);
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
                var cancion = spotiFakeContext.Cancions.ToList();
                ViewBag.Usuario = null;
                usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.correoElectronico == usuario.correoElectronico && o.contraseña == usuario.contraseña).First();
                ViewBag.AccesoConfirmado = usuarioConfirmado;
                if (usuarioConfirmado.rol == "Admin")
                {

                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return RedirectToAction("AdminIndex");
                }
                if (usuarioConfirmado.rol == "Sys")
                {

                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);

                    return RedirectToAction("SysIndex");
                }
                FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);

                return View("UsuarioIndex", cancion);
            }
            catch (Exception)
            {
                return RedirectToAction("messenge", "Login");
            }

        }
        public ActionResult Reproducir(int id, int idU)
        {
            //instamcia

            var cancionesEscuchadas = new CancionesEscuchadas();
            cancionesEscuchadas.fecha = DateTime.Now;
            cancionesEscuchadas.idUsuario = idU;
            cancionesEscuchadas.idCancion = id;
            spotiFakeContext.CancionesEscuchadass.Add(cancionesEscuchadas);
            spotiFakeContext.SaveChanges();
            var cancion = spotiFakeContext.Cancions.ToList();
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == idU).First();
            ViewBag.AccesoConfirmado = usuarioConfirmado;
            return View("UsuarioIndex", cancion);            
        }

        public ActionResult AgregarPlaylist(int idCancion, int idUsuario)
        {

            var cancion = spotiFakeContext.Cancions.ToList();
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == idUsuario).ToList();
            ViewBag.AccesoConfirmado = usuarioConfirmado;
            return View("UsuarioIndex", cancion);
        }

        [Authorize]
        public ActionResult Historial(int idUsuario)
        {
            var historial = spotiFakeContext.CancionesEscuchadass.Where(o => o.idUsuario == idUsuario).Include(o => o.cancion);
            var usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.idUsuario == idUsuario).First();
            ViewBag.AccesoConfirmado = usuarioConfirmado;
            return View(historial);
        }

    }
}