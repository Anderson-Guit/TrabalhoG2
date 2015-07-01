using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoG2.Controllers
{
    public class AgendaController : Controller
    {
        // GET: /Agenda/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Agenda/Details/5
        public ActionResult DetailsAgendaView(int pId)
        {
            var agenda = AgendaRepository.GetOne(pId);
            return View(agenda);
        }

        // GET: /Agenda/Create
        public ActionResult CreateAgendaView()
        {
            return View();
        }

        // POST: /Agenda/Create
        [HttpPost]
        public ActionResult CreateAgendaView(Agenda pAgenda)
        {

             AgendaRepository nova = new AgendaRepository();
             nova.Create(pAgenda);

             return RedirectToAction("Index");

        }

        // GET: /Agenda/Edit/5
        public ActionResult EditAgendaView(int pId)
        {
            var agenda = AgendaRepository.GetOne(pId);
            return View(agenda);
        }

        // POST: /Agenda/Edit/5
        [HttpPost]
        public ActionResult EditAgendaView(Agenda pAgenda)
        {
            try
            {
                AgendaRepository edit = new AgendaRepository();
                edit.Update(pAgenda);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Agenda/Delete/5
        public ActionResult DeleteAgendaView(int pId)
        {

            try
            {
                AgendaRepository exclui = new AgendaRepository();
                exclui.Delete(pId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        public ActionResult ListAgendasView()
        {
            var agenda = AgendaRepository.GetAll();

            return View(agenda);

        }

        public ActionResult SearchAgendaView(String pNome)
        {
            var agenda = AgendaRepository.GetName(pNome);

            return View(agenda);

        }

    }
}
