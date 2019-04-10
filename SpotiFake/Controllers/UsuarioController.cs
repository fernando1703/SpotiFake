using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class UsuarioController : Controller
    {
        SpotiFakeContext conexion = new SpotiFakeContext();
        // GET: Usuario
        public ActionResult UsuarioIndex(Usuario usuario)
        {
            return View(usuario);
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
        public ActionResult Ingreso(Usuario usuario)
        {
            Usuario usuario_Confirmado;
            //con js ya no es importante usar el try catch 
            try
            {
                usuario_Confirmado = conexion.Usuarios.Where(o => o.correoElectronico == usuario.correoElectronico && o.contraseña == usuario.contraseña).First();
            }
            catch (Exception)
            {

                return View("UsuarioIndex");
            }
            if (usuario.rol=="Admin")
            {
                return View("AdminIndex",usuario_Confirmado);
            }
            return View("UsuarioIndex",usuario_Confirmado);
        }
        public ActionResult AdminIndex(Usuario usuario)
        {
            return View();
        }
    }
}