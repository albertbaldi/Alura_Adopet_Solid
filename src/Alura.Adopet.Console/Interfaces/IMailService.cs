using System;

namespace Alura.Adopet.Console.Interfaces;

public interface IEmailService
{
    Task SendEmailAsync(string remetente, string destinatario, string assunto, string corpo);
}
