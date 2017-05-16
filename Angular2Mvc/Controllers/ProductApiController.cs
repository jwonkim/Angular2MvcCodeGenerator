using Angular2Mvc.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Angular2Mvc.Controllers
{
    public class ProductApiController : ApiController
    {
        ProductService _service;

        public ProductApiController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            IHttpActionResult ret;

            var list = await _service.Load();
            if (list.Count() > 0)
            {
                ret = Ok(list);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        [HttpGet]
        public async Task< IHttpActionResult> Find(int id)
        {
            IHttpActionResult ret;

            var obj = await _service.Get(id);
            if (obj != null)
            {
                ret = Ok(obj);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

    }
}