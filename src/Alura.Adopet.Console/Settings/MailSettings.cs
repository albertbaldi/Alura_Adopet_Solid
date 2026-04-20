using System;

namespace Alura.Adopet.Console.Settings;

public class MailSettings
{
    public const string EmailSection = "AdopetEmailConfiguration";
    public string? Usuario { get; set; }
    public string? EmailAdmin { get; set; }
    public string? Senha { get; set; }
    public string? Servidor { get; set; }
    public int Porta { get; set; }
}
