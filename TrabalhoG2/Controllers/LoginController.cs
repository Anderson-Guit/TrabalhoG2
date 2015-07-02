using Repository;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoG2.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUserView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserView(Usuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioRepository novo = new UsuarioRepository();
                novo.Create(pUsuario);
                return RedirectToAction("ListUsersView");
            }

            return View("CreateUserView");
        }


        public ActionResult EditUserView(int pId)
        {
            var user = UsuarioRepository.GetOne(pId);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUserView(Usuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioRepository edit = new UsuarioRepository();
                edit.Update(pUsuario);
                return RedirectToAction("ListUsersView");
            }

            return View("EditUserView");
            

        }

        [HttpGet]
        public ActionResult DeleteUserView(int pId)
        {
            UsuarioRepository exclui = new UsuarioRepository();
            exclui.Delete(pId);
            return RedirectToAction("ListUsersView");
        }


        [HttpPost]
        public ActionResult ListUsersView(String Nome, String Senha)
        {
            var login = UsuarioRepository.CheckUser(Nome, Senha);
            if (login.Nome != null)
            {
                var usuario = UsuarioRepository.GetAll();
                Session["Nome"] = Nome;

                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ListUsersView()
        {
            if (Session["Nome"] != null) { 
                var usuario = UsuarioRepository.GetAll();

                return View(usuario);
            }
            else
            {
                return View();
            }
        }

	}
}