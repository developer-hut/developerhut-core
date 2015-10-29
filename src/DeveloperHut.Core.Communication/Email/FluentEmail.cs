using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperHut.Core.Communication.Email
{
    public class FluentEmail : IFluentEmail
    {
        private readonly SmtpClient client;
        private readonly MailMessage message;

        public FluentEmail()
        {
            client = new SmtpClient();
            message = new MailMessage();
        }

        public IFluentEmail WithRecipient(IList<MailAddress> addresses)
        {
            foreach (var address in addresses)
            {
                message.To.Add(address);
            }

            return this;
        }

        public IFluentEmail WithRecipient(string address, string name = null)
        {
            if (name == null)
                message.To.Add(new MailAddress(address));
            else
                message.To.Add(new MailAddress(address, name));

            return this;
        }

        public IFluentEmail WithCarbonCopyRecipient(IList<MailAddress> addresses)
        {
            foreach (var address in addresses)
            {
                message.CC.Add(address);
            }

            return this;
        }

        public IFluentEmail WithCarbonCopyRecipient(string address, string name = null)
        {
            if (name == null)
                message.CC.Add(new MailAddress(address));
            else
                message.CC.Add(new MailAddress(address, name));

            return this;
        }

        public IFluentEmail WithBlindCarbonCopyRecipient(IList<MailAddress> addresses)
        {
            foreach (var address in addresses)
            {
                message.Bcc.Add(address);
            }

            return this;
        }

        public IFluentEmail WithBlindCarbonCopyRecipient(string address, string name = null)
        {
            if (name == null)
                message.Bcc.Add(new MailAddress(address));
            else
                message.Bcc.Add(new MailAddress(address, name));

            return this;
        }

        public IFluentEmail WithReplyInformation(string address)
        {
            message.ReplyToList.Add(new MailAddress(address));

            return this;
        }

        public IFluentEmail WithReplyInformation(string address, string name)
        {
            message.ReplyToList.Add(new MailAddress(address, name));

            return this;
        }

        public IFluentEmail WithAttachment(Attachment attachment)
        {
            if (!message.Attachments.Contains(attachment))
            {
                message.Attachments.Add(attachment);
            }

            return this;
        }

        public IFluentEmail WithSubject(string subject)
        {
            message.Subject = subject;

            return this;
        }

        public IFluentEmail WithHtmlBody(string body)
        {
            message.IsBodyHtml = true;
            message.Body = body;

            return this;
        }

        public IFluentEmail WithPlainTextBody(string body)
        {
            message.IsBodyHtml = false;
            message.Body = body;

            return this;
        }

        public IFluentEmail WithPriority(MailPriority priority)
        {
            if (priority != MailPriority.Normal)
            {
                message.Priority = priority;
            }

            return this;
        }

        public void Send(bool ssl = false)
        {
            client.EnableSsl = ssl;
            client.Send(message);
        }

        public void Dispose()
        {
            if (message != null)
                message.Dispose();

            if (client != null)
                client.Dispose();
        }
    }
}
