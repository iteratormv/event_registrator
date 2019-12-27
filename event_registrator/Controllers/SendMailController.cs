using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_registrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(string id)
        {

 //           string ascii = Encoding.ASCII.GetString(id);
            return "email sended  - " + id.ToString();
        }
    }
}