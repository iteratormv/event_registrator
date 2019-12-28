using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_registrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserByTockenController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(string id)
        {
            //string[] userdata = id.Split('|');
            //string usermail = userdata[0];
            //string userpassword = userdata[1];



            //           string ascii = Encoding.ASCII.GetString(id);
            return "  - " + id.ToString();
        }
    }
}
