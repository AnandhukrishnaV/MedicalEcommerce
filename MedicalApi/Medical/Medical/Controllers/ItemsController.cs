using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly MedicoContext obj;

        public ItemsController(MedicoContext _obj)
        {
            obj = _obj;
        }
        [HttpGet]
        public JsonResult Getfulllist()

        {
            var items = obj.items.ToList();
            return new JsonResult(items);
        }
        [HttpGet("{id}")]
        public JsonResult medByid(int id)

        {
            if (id == 0)
            {
                var items = obj.items.ToList();
                return new JsonResult(items);
            }
            else
            {
                var items = obj.items.Where(o => o.MediTypeid == id).ToList();
                return new JsonResult(items);

            }

        }
    }
}
