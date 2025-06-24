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
    public class CartController : ControllerBase
    {
        private readonly MedicoContext obj;

        public CartController(MedicoContext _obj)
        {
            obj = _obj;
        }
        [HttpPost]
        public JsonResult SaveToCart(Cart cart1)
        {

            var Dupli_Cart_value = obj.cart.Where(i => i.Medid == cart1.Medid && i.userid == cart1.userid).ToList();
            var usercartcout = obj.cart.Where(i => i.userid == cart1.userid).ToList();
            if (Dupli_Cart_value.Count == 0)
            {
                obj.Add(cart1);
                obj.SaveChanges();

                return new JsonResult(usercartcout);
            }
            else
            {

                return new JsonResult("0");
            }

        }
        [HttpGet]
        public JsonResult Getcartlist(int usid, string name)
        {

            usid = Convert.ToInt32(HttpContext.Request.Query["iid"]);
            name = HttpContext.Request.Query["uuname"];
            var items = obj.cart.Where(i => i.userid == usid && i.username == name).ToList();

            return new JsonResult(items);
        }
        [HttpDelete("{uniid}")]

        public ActionResult<List<Cart>> delCartValue(int uniid)
        {
            var emp = obj.cart.Where(x => x.cartuniid == uniid).First();
            var iid = emp.userid;
            obj.cart.Remove(emp);

            obj.SaveChanges();
            var emp1 = obj.cart.Where(x => x.userid == iid).ToList();
            return emp1;

        }
        [HttpPut]
        // Uptfoodcartlist
        public int Uptfoodcartlist(Cart cart)
        {

            var update_Cart_value = obj.cart.Where(i => (i.Medid == cart.Medid && i.userid == cart.userid)).SingleOrDefault();

            //var a = obj.cart;
            update_Cart_value.quantity = cart.quantity;
            // objFood.Entry(update_Cart_value).State = EntityState.Modified;

            //b.Quantity = Foodcart.Quantity;
            //objFood.Foodcart.Update(update_Cart_value);


            //_auctionContext.SaveChanges();
            var sum = obj.cart.Where(i => i.userid == cart.userid).AsEnumerable().Sum(o => o.amount * o.quantity);
            //objFood.Entry(Foodcart.Quantity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            obj.SaveChanges();
            return sum;



        }
        [HttpGet("value")]
        public int GetcartValue(int idd, string n)
        {
            int to = 0;
            idd = Convert.ToInt32(HttpContext.Request.Query["costid"]);
            n = HttpContext.Request.Query["costname"];
            var items = obj.cart.Where(i => i.userid == idd && i.username == n).ToList();
            //foreach (var q in items)
            //{
            to = items.AsEnumerable().Sum(o => o.amount * o.quantity);
            //to = q.Quantity * q.FoodAmount;
            //to = objFood.Foodcart.AsEnumerable().Sum(o => o.FoodAmount * o.Quantity);
            //}
            //var so = to;
            //var sum = objFood.Foodcart.AsEnumerable().Sum(o => o.FoodAmount * o.Quantity);
            return to;
        }
    }
}
