using Medical.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Medical.Model.MedicoContext;

namespace Medical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MedicoContext obj;

        public LoginController(MedicoContext _obj)
        {
            obj = _obj;
        }

        [HttpPost]
        public JsonResult Post(Login _login)
        {
            try
            {
                var usrname = obj.login.Where(I => I.username == _login.username).ToList();
                if (usrname.Count > 0)
                {
                    var password = obj.login.Where(i => i.password == _login.password).ToList();
                    if (password.Count > 0)
                    {
                        return new JsonResult(password);
                    }
                    else
                    {
                        return new JsonResult("0");
                    }
                }
                else
                {
                    return new JsonResult("-1");
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        [HttpGet("{id}")]
        public JsonResult Getuserdetails(int id)

        {
            var items = obj.login.Where(i => i.userid == id);
            return new JsonResult(items);
        }
    }
}
