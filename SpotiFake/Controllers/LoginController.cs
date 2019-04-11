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
        // GET: Login
        SpotiFakeContext conexion = new SpotiFakeContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ingreso(Usuario usuario)
        {
            Usuario usuario_Confirmado;
            //con js ya no es importante usar el try catch 
            try
            {
                usuario_Confirmado = conexion.Usuarios.Where(o => o.correoElectronico == usuario.correoElectronico && o.contraseña == usuario.contraseña).First();
                if (usuario.rol == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return RedirectToAction("AdminIndex", "Usuario", usuario_Confirmado);
                }
                FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                return RedirectToAction("UsuarioIndex", "Usuario", usuario_Confirmado);
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