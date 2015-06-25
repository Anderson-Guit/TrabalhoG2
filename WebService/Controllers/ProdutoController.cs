using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ProdutoController : ApiController
    {
        // GET: api/Produto
        public IEnumerable<Produto> Get()
        {
            return ProdutoRepository.GetAll();
        }

        // GET: api/Produto/5
        public Produto Get(int pId)
        {
            return ProdutoRepository.GetOne(pId);
        }

        // POST: api/Produto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Produto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Produto/5
        public void Delete(int id)
        {
        }
    }
}
