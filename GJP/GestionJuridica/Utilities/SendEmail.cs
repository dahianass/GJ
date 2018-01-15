using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GestionJuridica.Utilities
{
    public class SendEmail
    {
        public static void SendAlerta(List<string> emails, string subject, string body)
        {
            var user = ConfigurationManager.AppSettings["EmailConfig"];
            var password = ConfigurationManager.AppSettings["PasswordConfig"];
            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(user, password);
            MailAddress from = new MailAddress(user);
            MailMessage message = new MailMessage();
            message.From = from;
            foreach (var item in emails)
            {
                message.To.Add(item);
            }
            message.Body = body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.Send(message);
        }
    }
}