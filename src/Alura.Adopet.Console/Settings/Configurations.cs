using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Alura.Adopet.Console.Settings;

public static class Configurations
{
    public static IConfiguration BuildConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("dbe5487d-a51e-4a61-8108-b927d68b3696")
            .AddEnvironmentVariables()
            .Build();

        return configuration;
    }

    public static MailSettings GetMailSettings()
    {
        var config = BuildConfiguration();
        return config.GetSection(MailSettings.EmailSection).Get<MailSettings>() ?? throw new InvalidOperationException("Configurações de email não encontradas.");
    }

    public static AdopetApiSettings GetAdopetApiSettings()
    {
        var config = BuildConfiguration();
        return config.GetSection(AdopetApiSettings.AdopetApiSection).Get<AdopetApiSettings>() ?? throw new InvalidOperationException("Configurações da API Adopet não encontradas.");
    }
}
