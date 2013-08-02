using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace TGIF.Models
{
    public class Email
    {
        private static string FromAddress;
        private static string strToAddress;
        private static string strSmtpClient;
        private static string UserID;
        private static string Password;
        private static string ReplyTo;
        private static int SMTPPort;
        private static Boolean bEnableSSL;

       
        public static void SendMail(string message, string subject )
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
 
            try
            {
                FromAddress = System.Configuration.ConfigurationManager.AppSettings.Get("FromAddress");
                strToAddress = System.Configuration.ConfigurationManager.AppSettings.Get("ToAddress");
                strSmtpClient = System.Configuration.ConfigurationManager.AppSettings.Get("SmtpClient");
                UserID = System.Configuration.ConfigurationManager.AppSettings.Get("UserID");
                Password = System.Configuration.ConfigurationManager.AppSettings.Get("Password");
                ReplyTo = System.Configuration.ConfigurationManager.AppSettings.Get("ReplyTo");
                SMTPPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("SMTPPort"));
                if (System.Configuration.ConfigurationManager.AppSettings.Get("EnableSSL").ToUpper() == "YES")
                {
                    bEnableSSL = true;
                }
                else
                {
                    bEnableSSL = false;
                }

                m.From = new MailAddress(FromAddress, "TGIF");
                m.To.Add(new MailAddress(strToAddress, "TGIFUsers"));
                //m.CC.Add(new MailAddress("CC@yahoo.com", "Display name CC"));
                //similarly BCC
                m.Subject = subject;
                m.IsBodyHtml = true;
                m.Body = message;

                //FileStream fs = new FileStream("E:\\TestFolder\\test.pdf",
                //                   FileMode.Open, FileAccess.Read);
                //Attachment a = new Attachment(fs, "test.pdf",
                //                   MediaTypeNames.Application.Octet);
                //m.Attachments.Add(a);

                //string str = "<html><body><h1>Picture</h1><br/><imgsrc=\"cid:image1\"></body></html>";
                //AlternateView av =
                //             AlternateView.CreateAlternateViewFromString(str, null,MediaTypeNames.Text.Html);
                //LinkedResource lr = new LinkedResource("E:\\Photos\\hello.jpg", MediaTypeNames.Image.Jpeg);
                //lr.ContentId = "image1";
                //av.LinkedResources.Add(lr);
                //m.AlternateViews.Add(av);

                sc.Host = strSmtpClient;
                sc.Port = SMTPPort;
                sc.UseDefaultCredentials = true;
                sc.Credentials = new System.Net.NetworkCredential(UserID, Password);
                sc.EnableSsl = bEnableSSL;
                sc.Send(m);

                //Console.ReadLine();

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}