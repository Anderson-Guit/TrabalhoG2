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
    public class OrdemServicoController : ApiController
    {
        // GET: api/OrdemServico
        public IEnumerable<OrdemServico> Get()
        {
            return OrdemServicoRepository.GetAll();
        }

        // GET: api/OrdemServico/5
        public OrdemServico Get(int id)
        {
            return OrdemServicoRepository.GetOne(id);
        }

        // POST: api/OrdemServico
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrdemServico/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrdemServico/5
        public void Delete(int id)
        {
        }
    }
}
