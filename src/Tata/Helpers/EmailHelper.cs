using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Tata.Helpers
{
    public interface IEmailHelper
    {
        Task SendEmailAsync(string recipientName, string recipientAddress, string subject, MimeEntity body);
    }

    public class EmailHelper : IEmailHelper
    {
        private readonly SmtpInfo _smtpInfo;

        public EmailHelper(IOptions<SmtpInfo> smtpInfoAccessor)
        {
            _smtpInfo = smtpInfoAccessor.Value;
        }

        public async Task SendEmailAsync(string recipientName, string recipientAddress, string subject, MimeEntity body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tata", _smtpInfo.SmtpUsername));
            message.To.Add(new MailboxAddress(recipientName, recipientAddress));
            message.Subject = subject;
            message.Body = body;

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(_smtpInfo.SmtpServer, _smtpInfo.SmtpPort, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2"); // Must be removed for Gmail SMTP
                client.Authenticate(_smtpInfo.SmtpUsername, _smtpInfo.SmtpPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }

    public class SmtpInfo
    {
        public string SmtpServer { get; set; }

        public int SmtpPort { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }
    }
}
