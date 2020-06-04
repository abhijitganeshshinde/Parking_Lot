using System;
using System.Collections.Generic;
using System.Text;

namespace MSMQ
{
    public class SMTP
    {
        /// <summary>
        /// This Method For Sending The Mail 
        /// Using SMTP
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        /// <param name="data"></param>
        public void SendMail(string name, string mail, string data)
        {
            var message = new MimeMessage();

            // Mail  Form
            message.From.Add(new MailboxAddress(mail));

            // Send The Mail To
            message.To.Add(new MailboxAddress("abhijitganeshshinde@gmail.com"));

            // Subject Of Maile
            message.Subject = "Registration";

            // Message
            message.Body = new TextPart("plain")
            {
                Text = data
            };

            using (var client = new SmtpClient())
            {
                // Connect To SMTP Server(gmail)
                client.Connect("smtp.gmail.com", 587, false);
                // Login Detail
                client.Authenticate("abhijitganeshshinde@gmail.com", "");
                // Mail Send
                client.Send(message);
                // Disconnect Server
                client.Disconnect(true);
            }
        }
    }
}
