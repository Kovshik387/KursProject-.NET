using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace KursProject
{
    internal class NetMessage
    {
        static string to_message = "pumb00sable@gmail.com";
        // Отправка файла json на почту
        public void MessageSend(string path)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("kursprojecttask5fantokin@gmail.com", "qqpytrfmzcjpaycn");
            smtpClient.EnableSsl = true;
            
            MailAddress from = new("kursprojecttask5fantokin@gmail.com", "Фантокин Н.С");

            MailAddress to = new MailAddress(to_message);

            MailMessage message = new MailMessage(from, to)
            {
                Subject = "Граф",
            };

            message.Attachments.Add(new Attachment(path));
            
            smtpClient.Send(message);
            Console.WriteLine("Отправлено: "+to_message);
            
        }
    }
}
