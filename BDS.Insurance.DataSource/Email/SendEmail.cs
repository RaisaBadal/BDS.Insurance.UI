using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.Email
{
    public static class SendEmail
    {
        public static bool sendMassege(string body,string subject,string to)
        {
            
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("innovationscloudsphere@gmail.com");
                mail.Priority = MailPriority.High;
                mail.Body = body;
                mail.Subject = subject;
                mail.To.Add(to);
                using (SmtpClient smp = new SmtpClient("smtp.gmail.com", 587))
                {  
                        smp.Credentials = new NetworkCredential("innovationscloudsphere@gmail.com", "zgbgstnzeejdylvm");
                        smp.EnableSsl = true;
                        smp.Send(mail);
                }

            }
            return true;
        }
    }
}
