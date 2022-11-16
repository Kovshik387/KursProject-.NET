using System.Net;
using System.Net.Mail;
using KursProject.Interface;

namespace KursProject.DeliverJson
{
    internal class NetMessage : object, IDeliveryService
    {
        public string? To_Message { get; set; } = "pumb00sable@gmail.com";
        // Отправка файла json на почту
        public void MessageSend(string path)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("kursprojecttask5fantokin@gmail.com", "qqpytrfmzcjpaycn");
            smtpClient.EnableSsl = true;

            MailAddress from = new MailAddress("kursprojecttask5fantokin@gmail.com", "Фантокин Н.С");
            MailAddress to = new MailAddress(To_Message!);

            FileInfo file = new(path);

            MailMessage message = new MailMessage(from, to)
            {
                Subject = "Граф",
                Body = file.Name.Replace(".json", ""),
            };

            message.Attachments.Add(new Attachment(path));
            message.Attachments.Add(new Attachment("temp.png"));
            smtpClient.Send(message);
            message.Attachments.Dispose();
            File.Delete("temp.png");
            Console.WriteLine("Отправлено: " + To_Message);
        }
    }
}
