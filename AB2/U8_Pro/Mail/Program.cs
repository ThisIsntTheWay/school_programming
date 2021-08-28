using System;

//dotnet add package NETCore.MailKit
using MailKit.Net.Smtp;
using MimeKit;

namespace U8_Pro_Mail
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mail composition
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin", "reg@klopfen.rocks");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Admin", "reg@example.com");
            message.To.Add(to);

            message.Subject = "My Message 1";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";
            message.Body = bodyBuilder.ToMessageBody();

            // SMTP connection
            SmtpClient client = new SmtpClient();
            string user = System.IO.File.ReadAllText(@".\secrets\user.txt");
            string pass = System.IO.File.ReadAllText(@".\secrets\pass.txt");

            client.CheckCertificateRevocation = false;
            client.Connect("mail.klopfen.rocks", 587, true);
            client.Authenticate(user, pass);

            // Dispatch mail
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
