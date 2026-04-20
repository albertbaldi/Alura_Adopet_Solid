using System;

namespace Alura.Adopet.Console.Settings;

public class AdopetApiSettings
{
    public const string AdopetApiSection = "AdopetApi";

    public string Uri { get; set; } = string.Empty;
}
