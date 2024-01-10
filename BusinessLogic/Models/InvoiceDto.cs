
namespace BusinessLogic.Models
{
    public class InvoiceDto
    {
        public long Idinvoice { get; set; }
        public required string InvoiceNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string CustomerName { get; set; }

        public required IEnumerable<InvoiceDetailDto> InvoiceDetails { get; set; }
    }
    
    public class InvoiceDetailDto
    {
        public long IdinvoiceDetail { get; set; }
        public long Idproduct { get; set; }
        public long IdproducPriceCost { get; set; }
        public string? ProductName { get; set; }
    }
}
