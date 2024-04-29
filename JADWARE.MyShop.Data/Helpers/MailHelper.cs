using System.Net;
using System.Net.Mail;

namespace JADWARE.MyShop.Data.Helpers
{
    public class MailHelper
    {
        private string _senderMail = "jadwaremyshop@gmail.com";
        //private readonly string _password = "JADWARE2002";
        private readonly string _password = "iynd iydg bpvn klhb";
        private string _smtpServer = "smtp.gmail.com";
        private int _smtpPort = 587;

        public async Task<Boolean> SendMail(string mailReceiver, string mailSubject, string message)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(_senderMail);
                mail.To.Add(mailReceiver);
                mail.Subject = mailSubject;
                mail.Body = message;

                var smtpClient = new SmtpClient(_smtpServer, _smtpPort)
                {
                    Credentials = new NetworkCredential(_senderMail, _password),
                    EnableSsl = true
                };

                smtpClient.Send(mail);

                return true;
            }
            catch(Exception ex)
            { return false; }
            
        }
    }
}
