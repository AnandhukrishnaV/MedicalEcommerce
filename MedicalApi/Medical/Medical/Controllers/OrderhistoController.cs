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
    public class OrderhistoController : ControllerBase
    {
        private readonly MedicoContext obj;

        public OrderhistoController(MedicoContext _obj)
        {
            obj = _obj;
        }
        [HttpPost]

        public JsonResult ToOrderHistory(IEnumerable<Orderhistory> his)
        {

            //var Dupli_Cart_value = obj.orderhistory.Where(i => i.userid == his.userid).ToList();
            //var usercartcout = obj.cartitems.Where(i => i.userid == cart1.userid).ToList();
            foreach (var i in his)
            {
                obj.Add(i);
            }

            obj.SaveChanges();
            return new JsonResult("done");



        }

        [HttpDelete("{useid}")]
        public JsonResult delAllCartValue(int useid)
        {
            var emp = obj.cart.Where(x => x.userid == useid).ToList();
            // var iid = emp.userid;
            foreach (var item in emp)
            {
                // item.Status = 1;
                obj.cart.Remove(item);



            }
            //obj.cartitems.Remove(emp);

            obj.SaveChanges();
            //var emp1 = obj.cartitems.Where(x => x.userid == iid).ToList();
            return new JsonResult("Cleared");

        }
        [HttpGet("{usid}")]
        public JsonResult orderhistory(int usid)
        {


            var items = obj.orderhistory.Where(i => i.userid == usid).ToList();

            return new JsonResult(items);
        }
    }
}

