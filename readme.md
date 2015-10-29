# Developer Hut Core

This repository is a growing collection of commonly used code written by the Developer Hut team. The repository is currently quite small, containing only code for our communications library, but expect it to grow at a decent pace.

## FluentEmail
The FluentEmail class provides an easy way to send emails, using fluent LINQ-like syntax. It is built on the **SMTPClient** and **MailMessage** classes, and uses the credentials stored in your applications config file, in the same way **SMTPClient** does. 

```chsarp
using (var email = new FluentEmail())
{
    email.WithRecipient("unknown-client@developerhut.co.za")
         .WithBlindCarbonCopyRecipient("no-reply@developerhut.co.za")
         .WithReplyInformation("accounts@developerhut.co.za")
         .WithSubject("Invoice #1234")
         .WithHtmlBody("<b>Please find attached quote.<b>")
         .WithAttachment(new Attachment("10292015.pdf"))
         .WithPriority(MailPriority.High)
         .Send(true);
}
```
