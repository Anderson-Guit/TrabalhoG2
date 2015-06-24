using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoG2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUserView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserView(Usuario pUser)
        {
            UsuarioRepository nova = new UsuarioRepository();
            nova.Create(pUser);

            return RedirectToAction("Index");
        }


        public ActionResult EditUserView(int pId)
        {
            var user = ClienteRepository.GetOne(pId);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUserView(Usuario user)
        {
            UsuarioRepository edit = new UsuarioRepository();
            edit.Update(user);

            return RedirectToAction("Index");

        }

        public ActionResult DeleteUserView(int pId)
        {
            UsuarioRepository exclui = new UsuarioRepository();
            exclui.Delete(pId);
            return RedirectToAction("Index");

        }
    }
}