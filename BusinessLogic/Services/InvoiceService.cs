using BusinessLogic.Models;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class InvoiceService : IInvoiceInterface
    {
        private readonly MyPymesContext _myPymesContext;

        public InvoiceService(MyPymesContext context) 
        {
            _myPymesContext = context;
        }

        public IEnumerable<InvoiceDto> GetAllInvoices()
        {
            return _myPymesContext.Invoices.Include(x => x.InvoiceDetails).Select(data => new InvoiceDto() { 
                Idinvoice=data.Idinvoice, 
                InvoiceNumber=data.InvoiceNumber, 
                CreatedAt=data.CreatedAt, 
                CustomerName = data.CustomerName,
                InvoiceDetails=data.InvoiceDetails.Select(detail => new InvoiceDetailDto()
                {
                    IdinvoiceDetail=detail.IdinvoiceDetail,
                    IdproducPriceCost=detail.IdproducPriceCost,
                    Idproduct = detail.Idproduct,
                    ProductName = detail.ProductName
                })
            }).ToList();
        }
    }
}
