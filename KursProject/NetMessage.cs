﻿using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace KursProject
{
    internal class NetMessage
    {
        public string? To_Message { get; set; } = "pumb00sable@gmail.com";
        // Отправка файла json на почту
        public void MessageSend(string path)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("kursprojecttask5fantokin@gmail.com", "qqpytrfmzcjpaycn");
            smtpClient.EnableSsl = true;
            
            MailAddress from = new("kursprojecttask5fantokin@gmail.com", "Фантокин Н.С");

            MailAddress to = new MailAddress(To_Message!);

            FileInfo file = new(path);
            
            MailMessage message = new MailMessage(from, to)
            {
                Subject = "Граф",
                Body = file.Name.Replace(".json",""),
            };

            message.Attachments.Add(new Attachment(path));
            smtpClient.Send(message);
            message.Attachments.Dispose();
            Console.WriteLine("Отправлено: "+ To_Message);
        }
    }
}
