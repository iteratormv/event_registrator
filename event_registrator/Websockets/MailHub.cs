using event_registrator.Data;
using event_registrator.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace event_registrator.Websockets
{
    public class UserForMailing
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Barcode { get; set; }
        public string Password { get; set; }
        public string ExhibitionName { get; set;}
    }
    public class MailHub:Hub
    {
        public Task Echo(string message)
        {
            //     var h = HttpContext.Request.Scheme;
            var h = "http";
            var t = "193.93.186.170:35000";
            var host = h + "://" + t;

            //           var host = "http://localhost:50892";






            //string usermail1 = "morozvvlad@gmail.com";
            //string userpassword1 = "111";
            //string userFirstName1 = "Vladimir";
            //string userSurName1 = "Moroz";

            //User user1 = new User
            //{
            //    Email = usermail1,
            //    firstName = userFirstName1,
            //    surName = userSurName1,
            //    Password = userpassword1
            //};

            //string usermail2 = "iteratortesti@gmail.com";
            //string userpassword2 = "111";
            //string userFirstName2 = "Vladimir";
            //string userSurName2 = "Moroz";

            //User user2 = new User
            //{
            //    Email = usermail2,
            //    firstName = userFirstName2,
            //    surName = userSurName2,
            //    Password = userpassword2
            //};






            List<UserForMailing> users = new List<UserForMailing>();
            //add user from file

            //      string target = "C://Users//iterator_pro//source//repos//event_registrator//event_registrator//wwwroot//TempFiles";

            //for debug
            //       message = target + message;
            //for deploy????????????????????????????????

            //       message = @"c:\Users\iterator_pro\source\repos\event_registrator\event_registrator\wwwroot\TempFiles\test_for_sender.xls";


            //"C:\inetpub\wwwroot\event_registrator\wwwroot\TempFiles\test_for_sender.xls"

            //for deploy
            message = @"C:\inetpub\wwwroot\event_registrator\wwwroot\TempFiles\test_for_sender.xls";

            ExelData exelData = new ExelData(message);

            users = exelData.users;

            //users.Add(user1);
            //users.Add(user2);


            foreach (var item in users)
            {
                MailAddress fromMailAddress = new MailAddress("registratortoevent@gmail.com", "event-registrator");
                MailAddress toMailAddress = new MailAddress(item.Email);


                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    //string link = host + "/api/AddUserByTocken/"
                    //    + item.Email + "|"
                    //    + item.Password + "|"
                    //    + item.firstName + "|"
                    //    + item.surName
                    //    ;


                    var qrText = item.Barcode;



                    if (qrText != null)
                    {
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(4);
                        qrCodeImage.Save("wwwroot/images/" + qrText + ".bmp");
                    }


                    //  Attachment maildata = new Attachment(qrText + ".bmp");


                    //http://193.93.186.170:35000/images/TE00874615.bmp

                    mailMessage.Subject = "My Subject";
                    mailMessage.Body = "<p>Уважаемый " + item.Name + " !</p>"+
                                       "<p>Вы получили это сообщение так как вы зарегистрированны на выставку - " + item.ExhibitionName + "</p>" +
                                       "<p>Для быстрой регистрации Вы можете воспользоваться QR-кодом</p>" + 
                                       "<p><img src=\"" + host + @"/images/" + item.Barcode + ".bmp" + "\" ></p>" +
                                       "<p>Ваш QR-код</p>";
                    //mailMessage.Body = "<form action=\""+link+"\" method=\"post\">" +
                    //                         "<button type=\"submit\">Отправить</button>" +
                    //                     "</form>";



                    mailMessage.IsBodyHtml = true;

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(fromMailAddress.Address, "!Eventregistrator1");
                    

                    smtpClient.Send(mailMessage);

                    Thread.Sleep(3000);
                    //    message = message + " sended";
                    Clients.All.SendAsync("Send", "Sended message " + toMailAddress);

                }
            }





            //for (int i = 1; i < 10; i++)
            //{
            //    Thread.Sleep(1000);
            //    //    message = message + " sended";
            //    Clients.All.SendAsync("Send", message + " sended " + i);
            //}
            ////           return Clients.All.SendAsync("Send", message);
            Clients.All.SendAsync("Send", "All operation complete!");
            Thread.Sleep(15000);

            return Clients.All.SendAsync("Send", "clear message"); ;
        }


    }
}
