using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net;
using DBModel;

namespace Capstone.Business
{
    /// <summary>
    /// EmailHelper class to help in sending emails
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// Method to send passcode through email
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static int SendPasscode(Account account, int passcode)
        {
            try
            {
                string subject = "Passcode for registration";
                string message = $"Hello {account.firstName} {account.lastName}\nYour passcode is {passcode}";
                SendEmail(account.emailID, subject, message);
                return passcode;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Method to send email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        public static void SendEmail(string email, string subject, string message)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = GetNetworkCredential();
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(GetMailMessage(email, subject, message));
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Method to assign property values to MailMessage object
        /// </summary>
        /// <param name="recipientEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static MailMessage GetMailMessage(string recipientEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply.nrnacanada@gmail.com");
            mail.To.Add(recipientEmail);
            mail.Subject = subject;
            mail.Body = body;
            return mail;
        }

        /// <summary>
        /// Method to return network credentials
        /// </summary>
        /// <returns></returns>
        public static NetworkCredential GetNetworkCredential()
        {
            return new NetworkCredential("noreply.nrnacanada", "HelloNrna2020");
        }
    }
}