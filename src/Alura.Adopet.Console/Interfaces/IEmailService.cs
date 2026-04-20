using System;
using System.Threading.Tasks;
namespace Alura.Adopet.Console.Interfaces;

public interface IMailService
{
    Task SendEmailAsync(string remetente, string destinatario, string assunto, string corpo);
}
