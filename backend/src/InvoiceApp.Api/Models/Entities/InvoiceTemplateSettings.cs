namespace InvoiceApp.Api.Models.Entities;

public class InvoiceTemplateSettings
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? TemplateName { get; set; }
    public string PrimaryColor { get; set; } = "#1a1a2e";
    public string AccentColor { get; set; } = "#e94560";
    public string FontFamily { get; set; } = "Helvetica";
    public bool ShowLogo { get; set; } = true;
    public string? HeaderText { get; set; }
    public string? FooterText { get; set; }
    public string? DefaultNotes { get; set; }
    public string? DefaultTerms { get; set; }
    public bool IsDefault { get; set; } = true;

    // Navigation property
    public User User { get; set; } = null!;
}