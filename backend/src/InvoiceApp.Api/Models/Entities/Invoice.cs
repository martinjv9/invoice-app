using InvoiceApp.Api.Models.Enums;

namespace InvoiceApp.Api.Models.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public InvoiceType Type { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
    public DateTime IssueDate { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal Subtotal { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal DiscountPercent { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal Total { get; set; }
    public string? Notes { get; set; }
    public string? TermsAndConditions { get; set; }
    public string? PdfStoragePath { get; set; }
    public string? GoogleDriveFileId { get; set; }
    public DateTime? SentAt { get; set; }
    public string? SentToEmail { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public User User { get; set; } = null!;
    public Client Client { get; set; } = null!;
    public List<InvoiceLineItem> LineItems { get; set; } = new();
}