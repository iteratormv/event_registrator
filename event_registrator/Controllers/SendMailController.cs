using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using event_registrator.Data;
using event_registrator.Models;
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
            string[] userdata = id.Split('|');
            string usermail = userdata[0];
            string userpassword = userdata[1];
            string userFirstName = userdata[2];
            string userSurName = userdata[3];
            string encriptlink = Encripter.Encrypt(id);

                       string host = "http://localhos:50892";

            //              for debugin
            //var h = HttpContext.Request.Scheme;
            //var t = "192.168.0.66:50892";
            //var host = h + "://" + t;
            //              for production

            //var h = HttpContext.Request.Scheme;
            //var t = "193.93.186.170:35000";
            //var host = h + "://" + t;

            MailAddress fromMailAddress = new MailAddress("registratoriterator@gmail.com", "event_registrator");
            MailAddress toMailAddress = new MailAddress(usermail);

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                string link = host + "/api/AddUserByTocken/" + usermail+ "|" + userpassword + "|" + userFirstName + "|" + userSurName;
                mailMessage.Subject = "My Subject";
                mailMessage.Body = "<p>Для завершения регистрации перейдите по ссылке -</p><a href="+link+">ссылка на завершение регистрации</a>"; ;
                mailMessage.IsBodyHtml = true;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromMailAddress.Address, "!Qregistrator1");

                smtpClient.Send(mailMessage);
            }
            //           string ascii = Encoding.ASCII.GetString(id);
            return "  - " + id.ToString();
        }

        [HttpPost]
        public bool Post(User user)
        {
            bool result = true;
            //string usermail = user.Email;
            //string userpassword = user.Password;


            //var h = HttpContext.Request.Scheme;
            //var t = "193.93.186.170:35000";
            //var host = h + "://" + t;

            var host = "http://localhost:50892";


            MailAddress fromMailAddress = new MailAddress("registratoriterator@gmail.com", "event_registrator");
            MailAddress toMailAddress = new MailAddress(user.Email);

            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            using (SmtpClient smtpClient = new SmtpClient())
            {
                string link = host + "/api/AddUserByTocken/"
                    + user.Email + "|"
                    + user.Password + "|"
                    + user.firstName + "|"
                    + user.surName
                    ;
                mailMessage.Subject = "My Subject";
                mailMessage.Body = "<p>Для завершения регистрации перейдите по ссылке -</p><a href=" + link + ">ссылка на завершение регистрации</a>" +
                                   "<p>Если Вы пользователь мобильного устройства и Ваша ссылка не работает, попробуйте воспользоваться ссылкой на десктопном устройстве</p>" +
                                   "<p>либо скопируйте эту ссылку и вставьте в браузер</p>"; 
                //mailMessage.Body = "<form action=\""+link+"\" method=\"post\">" +
                //                         "<button type=\"submit\">Отправить</button>" +
                //                     "</form>";



                                       mailMessage.IsBodyHtml = true;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromMailAddress.Address, "!Qregistrator1");

                smtpClient.Send(mailMessage);

            }



            return result;
        }



    }
}