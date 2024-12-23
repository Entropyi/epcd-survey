﻿namespace Localization.Services;

public class AuthMessageSenderOptions
{
    public string? SmtpServer { get; set; }
    public int SmtpPort { get; set; }
    public string? SmtpUser { get; set; }
    public string? SmtpPass { get; set; }
}