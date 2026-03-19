namespace InvoiceApp.Api.Models.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Notes { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public User User { get; set; } = null!;
        public List<Invoice> Invoices { get; set; } = new();
    }
}
