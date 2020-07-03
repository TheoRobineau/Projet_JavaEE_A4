using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;

namespace Backend
{
    public class Mail
    {
        public static void sendMail(string to, string head, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("viewsonic45000@gmail.com", "projetdev"),
                EnableSsl = true,
            };
            smtpClient.Send("viewsonic45000@gmail.com", to, head, body);
        }
    }
}