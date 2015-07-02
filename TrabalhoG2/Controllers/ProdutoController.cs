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
            if (ModelState.IsValid)
            {
                ProdutoRepository nova = new ProdutoRepository();
                nova.Create(pProduto);
                return RedirectToAction("ListProdutosView");
            }

            return View("CreateProdutoView");
        }


        public ActionResult EditProdutoView(int pId)
        {
            var produtos = ProdutoRepository.GetOne(pId);
            return View(produtos);
        }

        [HttpPost]
        public ActionResult EditProdutoView(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ProdutoRepository edit = new ProdutoRepository();
                edit.Update(produto);
                return RedirectToAction("ListProdutosView");
            }

            return View("EditProdutoView");
            

        }

        public ActionResult DeleteProdutoView(int pId)
        {
            var produto = ProdutoRepository.GetOne(pId);
            return View(produto);

        }

        [HttpPost]
        public ActionResult DeleteProdutoView(Produto produto)
        {
            ProdutoRepository exclui = new ProdutoRepository();
            exclui.Delete(produto);
            return RedirectToAction("ListProdutosView");

        }

        public ActionResult ListProdutosView()
        {
            var produto = ProdutoRepository.GetAll();

            return View(produto);

        }

        public ActionResult SearchProdutoView(String pNome)
        {
            var produto = ProdutoRepository.GetName(pNome);

            return View(produto);

        }
    }
}