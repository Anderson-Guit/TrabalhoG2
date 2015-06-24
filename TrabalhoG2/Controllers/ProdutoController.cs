using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrabalhoG2.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProdutoView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProdutoView(Produto pProduto)
        {
            ProdutoRepository nova = new ProdutoRepository();
            nova.Create(pProduto);

            return RedirectToAction("Index");
        }


        public ActionResult EditProdutoView(int pId)
        {
            var produtos = ProdutoRepository.GetOne(pId);
            return View(produtos);
        }

        [HttpPost]
        public ActionResult EditProdutoView(Produto produto)
        {
            ProdutoRepository edit = new ProdutoRepository();
            edit.Update(produto);

            return RedirectToAction("Index");

        }

        public ActionResult DeleteProdutoView(int pId)
        {
            ProdutoRepository exclui = new ProdutoRepository();
            exclui.Delete(pId);
            return RedirectToAction("Index");

        }
    }
}