using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using event_registrator.Data;
using event_registrator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_registrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserByTockenController : ControllerBase
    {
        private readonly EventContext context;

        public AddUserByTockenController(EventContext _context)
        {
            context = _context;
        }

        //[HttpGet("{id}")]
        //public booleanReturn Get(string id)
        //{
        //    booleanReturn result = new booleanReturn { retData = false };
        //    if (id == null) return result;
        //    var query = context.users.Where(s=>s.UserEmail == id).ToArray();
        //    if (query.Count()>0)
        //        result.retData = true;            
        //    return result;
        //}

        //[HttpGet]
        //public booleanReturn Get()
        //{
        //    booleanReturn result = new booleanReturn { retData = false };
        //    return result;
        //}

        //public class booleanReturn
        //{
        //    public bool retData { get; set; }
        //}



        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            string[] userdata = id.Split('|');
            string usermail = userdata[0];
            string userpassword = userdata[1];
            string userFirstName = userdata[2];
            string userSurName = userdata[3];
            var canAdd = context.users.Where(s => s.Email == usermail).Count() == 0;
            if (canAdd)
            {
                var query = context.users.Add(new User
                {
                    Email = usermail,
                    Password = userpassword,
                    firstName = userFirstName,
                    surName = userSurName
                });
            }
            else return "Что-то пошло не так, если Ваша авторизация будет неуспешной, пройдите регистрацию на сайте заново";
            await context.SaveChangesAsync();
            var result = context.users.Where(s => s.Email == usermail).FirstOrDefault();



            return "Вы успешно зарегистрированы на сайте, вернитесь на страницу сайта и следуйте инструкциям";
        }



        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }




    }
}
