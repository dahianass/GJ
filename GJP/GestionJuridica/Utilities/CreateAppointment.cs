using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GestionJuridica.Utilities
{
    public class CreateAppointment
    {
        public static void Create(List<string> emails, string subject, string body, DateTime date)
        {
            var user = "apineda@igga.com.co";
            var password = "Alejo8090*";
            ExchangeService service = new ExchangeService();
            service.Credentials = new NetworkCredential(user, password);
            service.AutodiscoverUrl(user, RedirectionCallback);

            Appointment appointment = new Appointment(service);

            appointment.Subject = subject;
            appointment.Body = body;
            appointment.Start = date.AddHours(12);
            appointment.End = date.AddHours(13);
            appointment.ReminderDueBy = DateTime.Now;
            foreach (var email in emails)
            {
                appointment.RequiredAttendees.Add(email);
            }

            appointment.Save(SendInvitationsMode.SendToAllAndSaveCopy);

            Item item = Item.Bind(service, appointment.Id, new PropertySet(ItemSchema.Subject));
        }

        private static bool RedirectionCallback(string redirectionUrl)
        {
            return redirectionUrl.ToLower().StartsWith("https://");
        }
    }
}