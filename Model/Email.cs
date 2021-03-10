using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class Email
    {
        public Email()
        {

        }

        public Email(string subject, string fromEmail, string fromName)
        {
            this.Subject = subject;
            this.FromEmail = fromEmail;
            this.FromName = fromName;
        }
        public string Subject { get; set; }

        public string Content { get; set; }

        public string FromEmail { get; set; }

        public string FromName { get; set; }

        public List<string> To { get; set; }

        public List<string> CC { get; set; }

        public List<string> BCC { get; set; }

        public IEnumerable<string> ReplyTo { get; set; }

        public MailPriority Priority { get; set; }

        public List<EmailAttachment> Attachments { get; set; }
    }


    public enum MailPriority
    {
        Normal = 0,
        Low = 1,
        High = 2
    }
}