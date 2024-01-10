using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IInvoiceInterface _invoiceInterface;
        public HomeController(IInvoiceInterface invoiceInterface) 
        {
            _invoiceInterface = invoiceInterface;
        }

        [HttpGet]
        public IEnumerable<InvoiceDto> GetInvoiceDetail()
        {
            return _invoiceInterface.GetAllInvoices();
        }
    }
}
