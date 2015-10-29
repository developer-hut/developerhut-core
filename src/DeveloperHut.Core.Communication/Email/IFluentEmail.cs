using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperHut.Core.Communication.Email
{
    public interface IFluentEmail : IHideObjectMembers, IDisposable
    {
        IFluentEmail WithRecipient(IList<MailAddress> addresses);
        IFluentEmail WithRecipient(string address, string name = null);

        IFluentEmail WithCarbonCopyRecipient(IList<MailAddress> addresses);
        IFluentEmail WithCarbonCopyRecipient(string address, string name = null);

        IFluentEmail WithBlindCarbonCopyRecipient(IList<MailAddress> addresses);
        IFluentEmail WithBlindCarbonCopyRecipient(string address, string name = null);

        IFluentEmail WithReplyInformation(string address);
        IFluentEmail WithReplyInformation(string address, string name);

        IFluentEmail WithSubject(string subject);

        IFluentEmail WithHtmlBody(string body);
        IFluentEmail WithPlainTextBody(string body);

        IFluentEmail WithAttachment(Attachment attachment);

        IFluentEmail WithPriority(MailPriority priority);

        void Send(bool ssl);
    }
}
