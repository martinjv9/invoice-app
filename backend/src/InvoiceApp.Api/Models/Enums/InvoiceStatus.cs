namespace InvoiceApp.Api.Models.Enums;

public enum InvoiceStatus
{
    Draft = 1,
    Sent = 2,
    Viewed = 3,
    Paid = 4,
    Late = 5,
    Canceled = 6,
}