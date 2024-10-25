using API.Data;
using API.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MailKit;
using MimeKit;
using System;
using System.ComponentModel.DataAnnotations;
using MimeKit.Text;
using MailKit.Security;


namespace API.Services;

public class MailService : API.Interfaces.IMailService
{
   private readonly MailSettings _mailSettings;
    public MailService(IOptions<MailSettings> mailSettingsOptions)
    {
        _mailSettings = mailSettingsOptions.Value;
    }

    public bool SendMail(MailData mailData)
    {
        try
        {
            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(mailData.EmailTo));
            email.Subject = mailData.EmailSubject;
            email.Body = new TextPart(TextFormat.Html) {       
                Text = mailData.EmailBody
            };
            //email.Attachments.Aggregate

            using var smtp = new SmtpClient();
            smtp.Connect(
                _mailSettings.Server,
                _mailSettings.Port,
                SecureSocketOptions.StartTls
            );

            smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);

            smtp.Send(email);
            smtp.Disconnect(true);

            return true;
        }
        catch (Exception ex)
        {
            // Exception Details
            return false;
        }
    }
}
