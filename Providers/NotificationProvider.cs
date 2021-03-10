using OnlineOrderPlacementSystem.Contracts;
using OnlineOrderPlacementSystem.Model;
using System;
using System.IO;
using System.Net.Mail;

namespace OnlineOrderPlacementSystem.Providers
{
    public class NotificationProvider : INotificationContract
    {
        private SmtpClient smtpClient { get; set; }

        private NotificationConfiguration Config { get; set; }

        public NotificationProvider(NotificationConfiguration config)
        {
            this.smtpClient = new SmtpClient(config.Host, config.Port);
            this.smtpClient.EnableSsl = true;
            this.smtpClient.UseDefaultCredentials = false;
            this.smtpClient.Credentials = new System.Net.NetworkCredential(config.UserName, config.Password);
            this.Config = config;
        }

        public NotificationResponse Send(Email notification)
        {
            try
            {
                var message = this.GetMailMessage(notification as Email);
                this.smtpClient.SendMailAsync(message);
                return new NotificationResponse
                {
                    DeliveryStatus = DeliveryStatus.Delivered,
                    NotificationStatus = NotificationStatus.Sent
                };
            }
            catch (Exception ex)
            {
                return new NotificationResponse
                {
                    DeliveryStatus = DeliveryStatus.Bounced,
                    NotificationStatus = NotificationStatus.Failed,
                    Exception = ex
                };
            }
        }

        private MailMessage GetMailMessage(Email mail)
        {
            try
            {
                MailMessage message = new MailMessage();
                mail.FromEmail = string.IsNullOrEmpty(mail.FromEmail) ? this.Config.UserName : mail.FromEmail;
                message.From = new MailAddress(mail.FromEmail);
                mail.To.ForEach(to =>
                {
                    message.To.Add(to);
                });

                if (mail.Attachments != null)
                {
                    mail.Attachments.ForEach(at =>
                    {
                        message.Attachments.Add(new Attachment(new MemoryStream(at.Content), at.Name));
                    });
                }

                if (mail.CC != null)
                {
                    mail.CC.ForEach(cc =>
                    {
                        message.CC.Add(cc);
                    });
                }

                if (mail.BCC != null)
                {
                    mail.BCC.ForEach(Bcc =>
                    {
                        message.Bcc.Add(Bcc);
                    });
                }

                if (mail.Priority == Model.MailPriority.High)
                {
                    message.Priority = System.Net.Mail.MailPriority.High;
                }

                message.Subject = mail.Subject;
                message.Body = mail.Content;
                return message;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
