using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Promp.Extensions;
using Promp.Models.Prom.Search;
using Promp.Options;
using Promp.Prom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Promp.Services.PromService
{
    public class EmailService : IEmailService
    {
        private readonly SmtpOptions Options;

        public EmailService(IOptions<SmtpOptions> options)
        {
            Options = options.Value;
        }

        public async Task SendMessageAsync(string email, string name, string subject, string message)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(Options.Name, Options.Address));
            mailMessage.To.Add(new MailboxAddress(name, email));
            mailMessage.Subject = subject;
            mailMessage.Body = new TextPart(TextFormat.Plain)
            {
                Text = message
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect(Options.Host, Options.Port, true);
                smtpClient.Authenticate(Options.Address, Options.Password);
                await smtpClient.SendAsync(mailMessage);
                await smtpClient.DisconnectAsync(true);
            }
        }

        public Task SendRecoveryPasswordMessageAsync(string email, string name, string resetLink)
        {
            return SendMessageAsync(email, name, "Восстановление пароля | Promp", $"Ссылка восстановления: {resetLink}");
        }

        public Task SendPasswordResetMessageAsync(string email, string name)
        {
            return SendMessageAsync(email, name, "Пароль сброшен | Promp", $"Ваш пароль был сброшен.");
        }
    }
}
