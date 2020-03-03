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
                    mailMessage.Subject = item.ExhibitionName;
                    //mailMessage.Subject = "My Subject";
                    //mailMessage.Body = "<p>Уважаемый " + item.Name + " !</p>"+
                    //                   "<p>Вы получили это сообщение так как вы зарегистрированны на выставку - " + item.ExhibitionName + "</p>" +
                    //                   "<p>Для быстрой регистрации Вы можете воспользоваться QR-кодом</p>" + 
                    //                   "<p><img src=\"" + host + @"/images/" + item.Barcode + ".bmp" + "\" ></p>" +
                    //                   "<p>Ваш QR-код</p>";







                    mailMessage.Body = "<tbody>" +
                                         "<tr>" +
                                           "<td width = \"600\" valign = \"top\" style = \"width: 6.25in;padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                             "<div align = \"center\" >" +
                                               "<table class=\"x_-2130264098MsoNormalTable\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\"" +
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
                                                              "<td style = \"padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                "<p class=\"MsoNormal\"><img width = \"15\" height=\"30\"" +
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
                                                                                                 "style = \"font-size: 9.0pt;line-height: 125.0%;\">Уважаемый(ая) " + item.Name +



                                                                                                                //имя
                                                                                                                //                                  "партнер" +




                                                                                                                ",</span></span><span" +



                                                                                                 "style = \"font-size: 9.0pt;line-height: 125.0%;\"><br><span" +
                                                                                                   "class=\"x_-2130264098mc-toc-title\">" +
                                                                                                   "Данным письмом подтверждаем ваше участие в" +
                                                                                                 "</span></span><span" +
                                                                                                 "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                   "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\"> конференции" +



                                                                                                   "&nbsp;" +





                                                                                                   "</span></span><strong><span" +



                                                                                                     "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +



                                                                                                     "Point" +


                                                                                                     "</span></strong><span" +
                                                                                                       "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                         "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +
                                                                                                       "</span></span><strong><span" +
                                                                                                         "style=\"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\"> " +



                                                                                        "Mobile" +

                                                                                        "&amp;" +

                                                                                        "Iterator" +

                                                                                                         "</span></strong><span" +
                                                                                                           "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                             "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +
                                                                                                           "</span></span><strong><span" +
                                                                                                             "style=\"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +


                                                                                         "Ukraine" +

                                                                                                             "</span></strong><span" +
                                                                                                               "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                                  "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +


                                                                                                             "</span></span><strong><span" +
                                                                                                               "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +
                                                                                          "Sales" +      
                                                                                                             "</span></strong><span" +
                                                                                                             "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                               "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" +
                                                                                                             "</span></span><strong><span" +
                                                                                                               "style=\"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" + 
                                                                                          "Conference 2020" + 
                                                                                                             "</span></strong><span" +
                                                                                                             "class=\"x_-2130264098mc-toc-title\"><span" +
                                                                                                                "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" + 
                                                                                          ", которая состоится" + "" +
                                                                                          "                    &nbsp;" + 
                                                                                                              "<span" +
                                                                                                                "class=\"zm_inLnk\"" +
                                                                                                                  "data-value=\"2020-03-04 19:00:00\">" +
                                                                                          "04.03.2020" +
                                                                                                              "</span>&nbsp;в&nbsp;" + 
                                                                                           "10:00" +          "&nbsp;" + 
                                                                                           "по адресу" +      "&nbsp;" + 
                                                                                                              "</span></span><strong><span" +
                                                                                                                  "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\">" + 
                                                                                           " г. Киев, ул. Антоновича, 23" + 
                                                                                                              "</span></strong><span" +
                                                                                                                "style = \"font-size: 9.0pt;line-height: 125.0%;font-family: Arial, sans-serif;\"><br><span" +
                                                                                                              "class=\"x_-2130264098mc-toc-title\">" + 
                                                                                           "Для ускорения процесса регистрации на мероприятие распечатайте это письмо с вашим персональным QR-кодом и предъявите его либо используйте свой смартфон для отображения QR-кода." +
                                                                                                              "&nbsp;&nbsp;</span></span>" +
                                                                                              "</h2>" +
                                                                                              "<p><img src=\"" + host + @"/images/" + item.Barcode + ".bmp" + "\" ></p>" +
                                                                                            "</td>" + 
                                                                                          "</tr>" +
                                                                                        "</tbody>" +
                                                                                      "</table>" +
                                                                                    "</td>" +
                                                                                  "</tr>" +
                                                                                "</tbody>" +
                                                                              "</table>" +
                                                                            "</td>" +
                                                                          "</tr>" +
                                                                        "</tbody>" +
                                                                      "</table>" +
                                                                    "<p class=\"MsoNormal\">&nbsp;</p>" +
                                                                    "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\"" +
                                                                      "cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"" +
                                                                      "style=\"width: 100.0%;border-collapse: collapse;min-width: 100.0%;\">" +
                                                                      "<tbody>" +
                                                                        "<tr>" +
                                                                          "<td valign = \"top\"" +
                                                                            "style=\"padding: 6.75pt 0.0in 0.0in 0.0in;\">" +
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
                                                                                            "<h1>" + 
                                                                                             
                                                                                            
                                                                                            
                                                                                            "Point Mobile &amp; Iterator" + 
                                                                                            "<br>" +
                                                                                            "Ukraine Sales Conference 2020" + 
                                                                                            "</h1>" +
                                                                                          "</td>" +
                                                                                        "</tr>" +
                                                                                      "</tbody>" +
                                                                                    "</table>" +
                                                                                  "</td>" +
                                                                                "</tr>" +
                                                                              "</tbody>" +
                                                                            "</table>" +
                                                                          "</td>" +
                                                                        "</tr>" +
                                                                      "</tbody>" +
                                                                    "</table>" +
                                                                  "</td>" +
                                                                "</tr>" +
                                                              "</tbody>" +
                                                            "</table>" +
                                                          "</td>" +
                                                        "</tr>" +
                                                      "<tr>" + 
                                                    "<td valign = \"top\"" +
                                                      "style=\"border-top: none;border-left: solid white 4.5pt;border-bottom: none;border-right: solid white 4.5pt;background: rgb(239,239,239);padding: 0.0in 0.0in 7.5pt 0.0in;\">" +
                                                      "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\" cellspacing=\"0\"" +
                                                        "cellpadding=\"0\" align=\"left\" width=\"100%\"" +
                                                        "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                        "<tbody>" +
                                                          "<tr>" +
                                                            "<td width = \"100%\"" +
                                                              "style=\"width: 100.0%;padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                              "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\"" +
                                                                "cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"" +
                                                                "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                "<tbody>" +
                                                                  "<tr>" +
                                                                    "<td valign = \"top\"" +
                                                                      "style=\"padding: 0.0in 0.0in 0.0in 0.0in;min-width: 100.0%;\">" +
                                                                      "<table class=\"x_-2130264098MsoNormalTable\"" +
                                                                        "border=\"0\" cellspacing=\"0\" cellpadding=\"0\"" +
                                                                        "align=\"left\" width=\"100%\"" +
                                                                        "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                        "<tbody>" +
                                                                          "<tr>" +
                                                                            "<td valign = \"top\"" +
                                                                              "style=\"padding: 0.0in 0.0in 0.0in 0.0in;min-width: 100.0%;\">" +
                                                                                "<p class=\"MsoNormal\" align=\"center\" style=\"text-align: center;\">" + 
                                                                                   "<img width = \"590\" style=\"width: 6.15in;\" id=\"1582737472003020001_imgsrc_url_1\" src=\"https://mcusercontent.com/f40ab6b24dae28f5b6be23e89/images/ff5c744a-955b-4ec3-b8fc-df023f903c0c.jpg \">" +
                                                                                    "</p>" +
                                                                                  "</td>" +
                                                                                "</tr>" +
                                                                              "</tbody>" +
                                                                            "</table>" +
                                                                          "</td>" +
                                                                        "</tr>" +
                                                                      "</tbody>" +
                                                                    "</table>" +
                                                                  "<p class=\"MsoNormal\">&nbsp;</p>" +
                                                                  "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\"" +
                                                                    "cellspacing=\"0\" cellpadding=\"0\" width=\"100%\"" +
                                                                    "style=\"width: 100.0%;border-collapse: collapse;min-width: 100.0%;\">" +
                                                                    "<tbody>" +
                                                                    "<tr>" +
                                                                    "<td valign = \"top\"" +
                                                                      "style=\"padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                      "<table class=\"x_-2130264098MsoNormalTable\"" +
                                                                        "border=\"0\" cellspacing=\"0\" cellpadding=\"0\"" +
                                                                        "align=\"left\" width=\"100%\"" +
                                                                        "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                        "<tbody>" +
                                                                          "<tr>" +
                                                                            "<td valign = \"top\"" +
                                                                              "style=\"padding: 0.0in 0.0in 0.0in 0.0in;min-width: 100.0%;\">" +
                                                                              "<p class=\"MsoNormal\" align=\"center\" style=\"text-align: center;\">" +
                                                                                //       "<img width = \"590\" style=\"width: 6.15in;\" id=\"1582737472003020001_imgsrc_url_2\" src=\"https://mcusercontent.com/f40ab6b24dae28f5b6be23e89/images/a3b3f8e5-884c-4541-8792-2a8b813ff5c9.jpg \">" +
                                                                                "<img width = \"590\" style=\"width: 6.15in;\" id=\"1582737472003020001_imgsrc_url_2\" src=\"https://ci4.googleusercontent.com/proxy/WdIL2zBMnmOTADFg9HmMEYl3yN7aaRjO4xR9AkS8JSMYwWhnJLfM8QPOC01VWkMGmBsfCDpNCszJnT7dmf47GNzTsWaCefT3GSSbFhKqOw7Jrer0iExlAIm8gx8HQfLn7A8_-QRIyPZnhN7pb158udgYYcjTKg=s0-d-e1-ft#https://mcusercontent.com/f40ab6b24dae28f5b6be23e89/images/3f26e670-37b6-4cb3-bcd1-718649ad1380.jpg \">" +
                                                                                  "</p>" +
                                                                                "</td>" +
                                                                              "</tr>" +
                                                                            "</tbody>" +
                                                                          "</table>" +
                                                                        "</td>" +
                                                                      "</tr>" +
                                                                    "</tbody>" +
                                                                  "</table>" +
                                                                "</td>" +
                                                              "</tr>" +
                                                            "</tbody>" +
                                                          "</table>" +
                                                        "</td>" +
                                                      "</tr>" + 
                                                      "<tr>" +
                                                        "<td valign = \"top\"" +
                                                          "style=\"border-top: none;border-left: solid white 4.5pt;border-bottom: none;border-right: solid white 4.5pt;background: rgb(239,239,239);padding: 0.0in 0.0in 6.75pt 0.0in;\"" +
                                                          "id=\"x_-2130264098templateColumns\">" +
                                                          "<div align = \"center\" >" +
                                                          "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\" cellspacing=\"0\"" +
                                                            "cellpadding=\"0\" width=\"100%\"" +
                                                            "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                            "<tbody>" +
                                                            "<tr>" +
                                                              "<td valign = \"top\" style=\"padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                "<div align = \"center\" >" +
                                                                  "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\"" +
                                                                  "cellspacing=\"0\" cellpadding=\"0\" width=\"600\"" +
                                                                  "style=\"width: 6.25in;border-collapse: collapse;\"" +
                                                                  "id=\"x_-2130264098templateBody\">" +
                                                                  "<tbody>" +
                                                                    "<tr>" +
                                                                      "<td width = \"400\" valign=\"top\"" +
                                                                        "style=\"width: 300.0pt;padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                        "<table class=\"x_-2130264098MsoNormalTable\"" +
                                                                          "border=\"0\" cellspacing=\"0\"" +
                                                                          "cellpadding=\"0\" align=\"left\" width=\"380\"" +
                                                                          "style=\"width: 285.0pt;background: rgb(239,239,239);border-collapse: collapse;\">" +
                                                                          "<tbody>" +
                                                                            "<tr>" +
                                                                            "<td" +
                                                                              "style = \"padding: 0.0in 0.0in 6.75pt 0.0in;min-width: 100.0%;\">" +
                                                                              "<table" +
                                                                                "class=\"x_-2130264098MsoNormalTable\"" +
                                                                                "border=\"0\"" +
                                                                                "cellspacing=\"0\"" +
                                                                                "cellpadding=\"0\"" +
                                                                                "width=\"100%\"" + 
                                                                                "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                                "<tbody>" +
                                                                                  "<tr>" +
                                                                                    "<td valign = \"top\"" +
                                                                                      "style=\"padding: 6.75pt 0.0in 0.0in 0.0in;max-width: 100.0%;min-width: 100.0%;\">" +
                                                                                      "<table" +
                                                                                        "class=\"x_-2130264098MsoNormalTable\"" +
                                                                                        "border=\"0\"" + 
                                                                                        "cellspacing=\"0\"" +
                                                                                        "cellpadding=\"0\"" +
                                                                                        "align=\"left\"" +
                                                                                        "width=\"100%\"" +
                                                                                        "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                                          "<tbody>" +
                                                                                            "<tr>" +
                                                                                              "<td width = \"380\"" +
                                                                                                "valign=\"top\"" +
                                                                                                "style=\"width: 285.0pt;padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                                                "<table" +
                                                                                                  "class=\"x_-2130264098MsoNormalTable\"" +
                                                                                                  "border=\"0\"" +
                                                                                                  "cellspacing=\"0\"" +
                                                                                                  "cellpadding=\"0\"" +
                                                                                                  "align=\"left\"" +
                                                                                                  "width=\"100%\"" +
                                                                                                  "style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                                                                  "<tbody>" +
                                                                                                    "<tr>" +
                                                                                                      "<td valign = \"top\"" +
                                                                                                        "style=\"padding: 0.0in 13.5pt 6.75pt 13.5pt;\">" +
                                                                                                        "<p class=\"MsoNormal\" align=\"center\" style=\"margin-right: 0.0in;margin-bottom: 7.5pt;margin-left: 0.0in;text-align: center;line-height: 150.0%;\">" +
                                                                                                          "<span style = \"font-size: 10.0pt;line-height: 150.0%;font-family: Helvetica, sans-serif;color: rgb(80,80,80);\"> Ждём Вас на конференции в 10.00</span><span style = \"font-size: 12.0pt;line-height: 150.0%;font-family: Helvetica, sans-serif;color: rgb(80,80,80);\"></span>" +
                                                                                                        "</p>" +
                                                                                                        "<p class=\"MsoNormal\" style=\"margin-right: 0.0in;margin-bottom: 7.5pt;margin-left: 0.0in;text-align: justify;line-height: 150.0%;\">" +
                                                                                                          "<span style = \"font-size: 12.0pt;line-height: 150.0%;font-family: Helvetica, sans-serif;color: rgb(80,80,80);\">&nbsp;</span>" +
                                                                                                        "</p>" +
                                                                                                       "</td>" +
                                                                                                      "</tr>" +
                                                                                                    "</tbody>" +
                                                                                                  "</table>" +
                                                                                                "</td>" +
                                                                                              "</tr>" +
                                                                                            "</tbody>" +
                                                                                          "</table>" +
                                                                                        "</td>" +
                                                                                      "</tr>" +
                                                                                    "</tbody>" +
                                                                                  "</table>" +
                                                                                "</td>" +
                                                                              "</tr>" +
                                                                            "</tbody>" +
                                                                          "</table>" +
                                                                        "</td>" +
                                                                        "<td width = \"200\" valign=\"top\" style=\"width: 150.0pt;padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                          "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\" cellspacing=\"0\"" +
                                                                            "cellpadding=\"0\" align=\"left\" width=\"186\" style=\"width: 139.5pt;border-collapse: collapse;\" id=\"x_-2130264098templateSidebar\">" +
                                                                            "<tbody>" +
                                                                              "<tr>" +
                                                                                "<td valign = \"top\" style=\"padding: 6.75pt 0.0in 6.75pt 0.0in;\" id=\"x_-2130264098monthContainer\">" +
                                                                                  "<div align = \"center\">" +
                                                                                    "<table class=\"x_-2130264098MsoNormalTable\" border=\"1\" cellspacing=\"0\" cellpadding=\"0\" width=\"150\" id=\"x_-2130264098calendarContainer\">" +
                                                                                      "<tbody>" +
                                                                                        "<tr>" +
                                                                                          "<td valign = \"top\" style=\"border: solid white 4.5pt;border-bottom: none;background: rgb(239,239,239);padding: 3.0pt 3.0pt 3.0pt 3.0pt;\">" +
                                                                                             "<div>" +
                                                                                               "<p class=\"MsoNormal\" align=\"center\" style=\"text-align: center;line-height: 150.0%;\">" +
                                                                                                 "<b><span style = \"font-size: 10.5pt;line-height: 150.0%;font-family: Helvetica, sans-serif;color: rgb(48,48,48);\">Март 2020</span></b>" +
                                                                                               "</p>" +
                                                                                             "</div>" +
                                                                                           "</td>" +
                                                                                         "</tr>" +
                                                                                         "<tr>" +
                                                                                           "<td valign = \"top\" style=\"border: solid white 4.5pt;border-top: none;padding: 3.0pt 3.0pt 3.0pt 3.0pt;\" id=\"x_-2130264098dayContainer\">" +
                                                                                             "<div>" +
                                                                                               "<p class=\"MsoNormal\" align=\"center\" style=\"text-align: center;\">" +
                                                                                                 "<b><span style = \"font-size: 54.0pt;font-family: Helvetica, sans-serif;color: rgb(48,48,48);\">4</span></b>" +
                                                                                               "</p>" +
                                                                                             "</div>" +
                                                                                           "</td>" +
                                                                                         "</tr>" +
                                                                                       "</tbody>" +
                                                                                     "</table>" +
                                                                                   "</div>" +
                                                                                 "</td>" +
                                                                               "</tr>" +
                                                                               "<tr>" +
                                                                                 "<td valign=\"top\" style=\"padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                                                 "</td>" +
                                                                               "</tr>" +
                                                                             "</tbody>" +
                                                                           "</table>" +                                                                       
                                                                          "</td>" +
                                                                         "</tr>" +
                                                                       "</tbody>" +
                                                                     "</table>" +
                                                                   "</div>" +
                                                                 "</td>" +
                                                                 "<td valign = \"top\" style=\"padding: 13.5pt 0.0in 0.0in 0.0in;\">" +
                                                                   "<p class=\"MsoNormal\" align=\"right\" style=\"text-align: right;\">" +
                                                                     "<img width = \"15\" height=\"30\" style=\"width: 0.1583in;height: 0.3083in;\" id=\"1582737472003020001_imgsrc_url_3\" src=\"https://cdn-images.mailchimp.com/template_images/gallery/03c9e5d8-4a2f-471e-b646-37327134c2b0.png \">" +
                                                                  "</p>" +
                                                                "</td>" +
                                                              "</tr>" +
                                                            "</tbody>" +
                                                          "</table>" +
                                                        "</div>" +
                                                      "</td>" +
                                                    "</tr>" +
                                                    "<tr>" +
                                                      "<td valign = \"top\" style=\"border-top: none;border-left: solid white 4.5pt;border-bottom: none;border-right: solid white 4.5pt;background: rgb(239,239,239);padding: 0.0in 0.0in 0.0in 0.0in;\" id=\"x_-2130264098templateLowerBody\">" +
                                                        "<table class=\"x_-2130264098MsoNormalTable\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"left\" width=\"100%\" style=\"width: 100.0%;border-collapse: collapse;\">" +
                                                        "<tbody>" +
                                                        "<tr>" +
                                                          "<td style = \"padding: 0.0in 0.0in 0.0in 0.0in;\">" +
                                                            "<p class=\"MsoNormal\">" +
                                                               "<img width = \"15\" height=\"30\" style=\"width: 0.1583in;height: 0.3083in;\" id=\"1582737472003020001_imgsrc_url_4\" src=\"https://cdn-images.mailchimp.com/template_images/gallery/47662b23-df38-45d4-8005-9b2f50193f4b.png \">" +
                                                            "</p>" +
                                                          "</td>" +
                                                          "<td width = \"100%\" style=\"width: 100.0%;padding: 0.0in 0.0in 0.0in 0.0in;\">"+
                                                          "</td>" +
                                                        "</tr>" +
                                                      "</tbody>" +
                                                    "</table>" +
                                                  "</td>" +
                                                "</tr>" +
                                                "<tr>" +
                                                  "<td valign = \"top\" style=\"border: solid white 4.5pt;border-bottom: none;background: rgb(239,239,239);padding: 6.75pt 0.0in 6.75pt 0.0in;\" id=\"x_-2130264098templateFooter\">" +
                                                  "</td>" +
                                                "</tr>" +
                                              "</tbody>" +
                                            "</table>" +
                                          "</div>" +
                                        "</td>" +
                                      "</tr>" +
                                    "</tbody>";












































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
                    Clients.All.SendAsync("Send", "Sended message " + toMailAddress + " " + item.Name);

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
