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
            
            var h = "http";
            var t = "193.93.186.170:35000";
            var host = h + "://" + t;

            List<UserForMailing> users = new List<UserForMailing>();

            message = @"C:\inetpub\wwwroot\event_registrator\wwwroot\TempFiles\test_for_sender.xls";

            ExelData exelData = new ExelData(message);

            users = exelData.users;

            foreach (var item in users)
            {
                MailAddress fromMailAddress = new MailAddress("registratortoevent@gmail.com", "event-registrator");
                MailAddress toMailAddress = new MailAddress(item.Email);


                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    var qrText = item.Barcode;
                    if (qrText != null)
                    {
                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCode = new QRCode(qrCodeData);
                        System.Drawing.Bitmap qrCodeImage = qrCode.GetGraphic(4);
                        qrCodeImage.Save("wwwroot/images/" + qrText + ".bmp");
                    }
                    mailMessage.Subject = "My Subject";
                    mailMessage.Body = "<p>Уважаемый " + item.Name + " !</p>"+
                                       "<p>Вы получили это сообщение так как вы зарегистрированны на выставку - " + item.ExhibitionName + "</p>" +
                                       "<p>Для быстрой регистрации Вы можете воспользоваться QR-кодом</p>" + 
                                       "<p><img src=\"" + host + @"/images/" + item.Barcode + ".bmp" + "\" ></p>" +
                                       "<p>Ваш QR-код</p>";
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

            Clients.All.SendAsync("Send", "All operation complete!");
            Thread.Sleep(15000);

            return Clients.All.SendAsync("Send", "clear message"); 
        }

        public Task SendMailToVisitor(string message)
        {
            Thread.Sleep(2000);
            return Clients.Caller.SendAsync("Send", "mail sended " + message);
        }


    }
}
