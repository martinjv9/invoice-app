namespace InvoiceApp.Api.Models.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? BusinessName { get; set; }
    public string? BusinessAddress { get; set; }
    public string? BusinessPhone { get; set; }
    public string? BusinessEmail { get; set; }
    public string? LogoUrl { get; set; }
    public string? DefaultPaymentTerms { get; set; }
    public bool GoogleDriveConnected { get; set; }
    public string? GoogleAccessToken { get; set; }
    public string? GoogleRefreshToken { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public List<Client> Clients { get; set; } = new();
    public List<Invoice> Invoices { get; set; } = new();
    public List<RefreshToken> RefreshTokens { get; set; } = new();
    public InvoiceTemplateSettings? InvoiceTemplateSettings { get; set; }
}