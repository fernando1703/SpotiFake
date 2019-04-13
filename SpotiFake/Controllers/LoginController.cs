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

        public ActionResult Ingreso(Usuario usuario)
        {
            Usuario usuarioConfirmado;
            //con js ya no es importante usar el try catch 
            try
            {
                usuarioConfirmado = spotiFakeContext.Usuarios.Where(o => o.correoElectronico == usuario.correoElectronico && o.contraseña == usuario.contraseña).First();
                if (usuario.rol == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return RedirectToAction("AdminIndex", "Usuario", usuarioConfirmado);
                }
                FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                return RedirectToAction("UsuarioIndex", "Usuario", usuarioConfirmado);
            }
            catch (Exception)
            {
                return View("Index");
            }

        }
        public ViewResult messenge()
        {
            return View();
        }
    }
}