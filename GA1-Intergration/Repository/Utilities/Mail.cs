using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
/*
220000213 M Tshabalala
219014331 SL Hadebe
219007267 MP Tsoaela    
*/
namespace GA1_Intergration.Repository.Utilities
{
    static public class Mail
    {
        public static Task SendMail(MailMessage mailMessage)
        {
            var credentialsUserName = mailMessage.To;
            var sentFrom = mailMessage.From;
            var pwd = "10111@Mtn";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            NetworkCredential credential = new NetworkCredential(credentialsUserName.ToString(), pwd);

            client.EnableSsl = true;
            client.Credentials = credential;

            var mail = new MailMessage(mailMessage.From.ToString(), mailMessage.To.ToString());
            mail.From = new MailAddress(mailMessage.From.ToString(), "Techtronics");
            mail.Subject = mailMessage.Subject;
            mail.Body = mailMessage.Body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mail.ReplyToList.Add("noreply_techtronics@gmail.com");
            
            return client.SendMailAsync(mail);




        }
    }
}