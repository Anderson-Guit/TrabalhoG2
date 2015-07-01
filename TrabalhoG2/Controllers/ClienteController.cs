using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoG2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateClienteView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClienteView(Cliente pCliente)
        {
            ClienteRepository nova = new ClienteRepository();
            nova.Create(pCliente);

            return RedirectToAction("ListClientesView");
        }


        public ActionResult EditClienteView(int pId)
        {
            var clientes = ClienteRepository.GetOne(pId);
            return View(clientes);
        }

        [HttpPost]
        public ActionResult EditClienteView(Cliente cliente)
        {
            ClienteRepository edit = new ClienteRepository();
            edit.Update(cliente);

            return RedirectToAction("ListClientesView");

        }

        public ActionResult DeleteClienteView(int pId)
        {
            ClienteRepository exclui = new ClienteRepository();
            exclui.Delete(pId);
            return RedirectToAction("ListClientesView");

        }

        public ActionResult ListClientesView()
        {
            var Cliente = ClienteRepository.GetAll();

            return View(Cliente);

        }

        public ActionResult DetailsClienteView(int pId)
        {
            var cliente = ClienteRepository.GetOne(pId);

            return View(cliente);

        }

        public ActionResult SearchClienteView(String pNome)
        {
            var cliente = ClienteRepository.GetName(pNome);

            return View(cliente);

        }

    }
}