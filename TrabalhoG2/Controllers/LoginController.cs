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
        public ActionResult LoginView()
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
            UsuarioRepository novo = new UsuarioRepository();
            novo.Create(pUsuario);

            return RedirectToAction("ListUsersView");
        }


        public ActionResult EditUserView(int pId)
        {
            var produtos = ProdutoRepository.GetOne(pId);
            return View(produtos);
        }

        [HttpPost]
        public ActionResult EditUserView(Usuario pUsuario)
        {
            UsuarioRepository edit = new UsuarioRepository();
            edit.Update(pUsuario);

            return RedirectToAction("ListUsersView");

        }

        public ActionResult DeleteUserView(int pId)
        {
            UsuarioRepository exclui = new UsuarioRepository();
            exclui.Delete(pId);
            return RedirectToAction("ListUsersView");

        }

        public ActionResult ListUsersView()
        {
            var usuario = UsuarioRepository.GetAll();

            return View(usuario);

        }

	}
}