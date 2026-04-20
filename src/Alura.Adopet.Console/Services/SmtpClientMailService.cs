using System;
using System.Net.Mail;
using Alura.Adopet.Console.Interfaces;

namespace Alura.Adopet.Console.Services;

public class SmtpClientMailService : IMailService
{
    private readonly SmtpClient _smtpClient;

    public SmtpClientMailService(SmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
    }


    public async Task SendEmailAsync(string remetente, string destinatario, string assunto, string corpo)
    {
        MailMessage mailMessage = new MailMessage(remetente, destinatario, assunto, corpo);
        await _smtpClient.SendMailAsync(mailMessage);
    }
}
