using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIServer.Controller
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Test()
        {

            return "Hello World";
        }
    }
}
