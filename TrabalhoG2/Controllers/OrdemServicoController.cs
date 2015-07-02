using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoG2.Controllers
{
    public class OrdemServicoController : Controller
    {
        // GET: OrdemServico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOsView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOsView(OrdemServico pOs)
        {
            if (ModelState.IsValid)
            {
                OrdemServicoRepository nova = new OrdemServicoRepository();
                nova.Create(pOs);
                return RedirectToAction("ListOsView");
            }

            return View("CreateOsView");
        }


        public ActionResult EditOsView(int pId)
        {
            var ordens = OrdemServicoRepository.GetOne(pId);
            return View(ordens);
        }

        [HttpPost]
        public ActionResult EditOsView(OrdemServico ordem)
        {
            if (ModelState.IsValid)
            {
                OrdemServicoRepository edit = new OrdemServicoRepository();
                edit.Update(ordem);
                return RedirectToAction("ListOsView");
            }

           
            return View("EditOsView");

        }

        public ActionResult DeleteOsView(int pId)
        {
            OrdemServicoRepository exclui = new OrdemServicoRepository();
            exclui.Delete(pId);
            return RedirectToAction("ListOsView");

        }
        public ActionResult ListOsView()
        {
            var os = OrdemServicoRepository.GetAll();

            return View(os);

        }

        public ActionResult SearchOsView(int pId)
        {
            var os = OrdemServicoRepository.GetOne(pId);

            return View(os);

        }
    }
}