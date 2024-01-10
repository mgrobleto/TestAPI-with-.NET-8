using BusinessLogic.Models;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly InvoiceService _invoiceService;

       
        public WeatherForecastController(ILogger<WeatherForecastController> logger, InvoiceService service)
        {
            _logger = logger;
            _invoiceService = service;
        }

        [HttpGet]
        public IEnumerable<InvoiceDto> Get()
        {
            return _invoiceService.GetAllInvoices();
        }
    }
}
