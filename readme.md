This repository is a growing collection of commonly used code written by the Developer Hut team. The repository is currently quite small, containing only code for our communications library, but expect it to grow at a decent pace.

## Communication Library
```powershell
Install-Package DeveloperHut.Core.Communication
```

#### FluentEmail
The FluentEmail class provides an easy way to send emails, using fluent LINQ-like syntax. It is built on the **SMTPClient** and **MailMessage** classes, and uses the credentials stored in your applications config file, in the same way **SMTPClient** does.  To use it, simply update the **mailSettings** config section found in your **app.config** or **web.config** file. 

```xml
<mailSettings>
    <smtp from="mail@domain.com">
        <network host="myserver.com" port="25" userName="username" password="password" enableSsl="true"/>
     </smtp>
</mailSettings>
```

Using the library dramatically simplifies the way we send email, as seen by the example below.

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
         .Send();
}
```
