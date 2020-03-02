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
                    //mailMessage.Body = "<p>Уважаемый " + item.Name + " !</p>"+
                    //                   "<p>Вы получили это сообщение так как вы зарегистрированны на выставку - " + item.ExhibitionName + "</p>" +
                    //                   "<p>Для быстрой регистрации Вы можете воспользоваться QR-кодом</p>" + 
                    //                   "<p><img src=\"" + host + @"/images/" + item.Barcode + ".bmp" + "\" ></p>" +
                    //                   "<p>Ваш QR-код</p>";







                    mailMessage.Body = "<tbody>" +
                                         "< tr >" +
                                           "< td width = \"600\" valign = \"top\" style = \"width: 6.25in;padding: 0.0in 0.0in 0.0in 0.0in;\" >" +
                                             "< div align = \"center\" >" +
                                               "< table class=\"x_-2130264098MsoNormalTable\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\"" +
                                                 "style=\"max-width: 6.25in;border-collapse: collapse;border: none;\">" +
                                                 "<tbody>" +
                                                   "<tr>" +
                                                     "<td valign = \"top\"" +
                                                        "style=\"border-top: none;border-left: solid white 4.5pt;border-bottom: none;border-right: solid white 4.5pt;background: rgb(239,239,239);padding: 22.5pt 11.25pt 7.5pt 0.0in;\">" +
                                                        "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\" cellspacing=\"0\"" +
                                                          "cellpadding=\"0\" align=\"left\" width=\"100%\"" +
                                                          "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                          "<tbody>" +
                                                            "<tr>" +
                                                              "<td style = \"padding: 0.0in 0.0in 0.0in 0.0in;\" >" +
                                                                "< p class=\"MsoNormal\"><img width = \"15\" height=\"30\"" +
                                                                  "style=\"width: 0.1583in;height: 0.3083in;\"" +
                                                                  "id=\"1582737472003020001_imgsrc_url_0\"" +
                                                                  "src=\"https://cdn-images.mailchimp.com/template_images/gallery/47662b23-df38-45d4-8005-9b2f50193f4b.png\">" +
                                                                "</p>" +
                                                              "</td>" +
                                                              "<td width = \"100%\"" +
                                                                "style=\"width: 100.0%;padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\"" +
                                                                  "cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"" +
                                                                  "style=\"width: 100.0%;border-collapse: collapse;min-width: 100.0%;\">" +
                                                                  "<tbody>" +
                                                                    "<tr>" +
                                                                      "<td valign = \"top\"" +
                                                                         "style=\"padding: 6.75pt 0.0in 0.0in 0.0in;min-width: 100.0%;\">" +
                                                                         "<table class=\"x_-2130264098MsoNormalTable\"" +
                                                                           "border=\"0\" cellspacing=\"0\" cellpadding=\"0\"" +
                                                                           "align=\"left\" width=\"100%\"" +
                                                                           "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                           "<tbody>" +
                                                                              "<tr>" +
                                                                                "<td width = \"560\" valign=\"top\"" +
                                                                                   "style=\"width: 420.0pt;padding: 0.0in 0.0in 0.0in 0.0in;max-width: 100.0%;min-width: 100.0%;\">" +
                                                                                    "<table" +
                                                                                      "class=\"x_-2130264098MsoNormalTable\"" +
                                                                                       "border=\"0\" cellspacing=\"0\"" +
                                                                                       "cellpadding=\"0\" align=\"left\"" +
                                                                                       "width=\"100%\"" +
                                                                                       "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                                       "<tbody>" +
                                                                                         "<tr>" +
                                                                                           "<td valign = \"top\"" +
                                                                                             "style=\"padding: 0.0in 13.5pt 6.75pt 13.5pt;\">" +
                                                                                             "<h2><span" +
                                                                                               "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                 "style = \"font-size: 9.0pt;line-height: 125.0%;\" > Уважаемый" +




                                                                                                                "партнер" +




                                                                                                                ",</span></span><span" +



                                                                                                 "style = \"font-size: 9.0pt;line-height: 125.0%;\" >< br >< span" +
                                                                                                   "class=\"x_-2130264098mc-toc-title\">" +
                                                                                                   "Данным письмом подтверждаем ваше участие в" +
                                                                                                 "</span></span><span" +
                                                                                                 "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                   "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\" > конференции" +



                                                                                                   "& nbsp;" +





                                                                                                   "</span></span><strong><span" +



                                                                                                     "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\" >" +



                                                                                                     "Point" +


                                                                                                     "</ span ></ strong >< span" +
                                                                                                       "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                         "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\" >" +
                                                                                                       "</ span ></ span >< strong >< span" +
                                                                                                         "style=\"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\"> " +



                                                                                                         "Mobile" +

                                                                                                         "&amp;" +

                                                                                                         "Iterator" +

                                                                                                         "</span></strong><span" +
                                                                                                           "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                             "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\" >" +
                                                                                                           "</ span ></ span >< strong >< span" +
                                                                                                             "style=\"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +


                                                                                                             "Ukraine" +

                                                                                                             "</span></strong><span" +
                                                                                                               "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                                  "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\" >";















































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
