using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Dtos.Invoice;
using StoreWebAPI.Models;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoice _invoiceDAL;
        private readonly IMapper _mapper;

        public InvoicesController(IInvoice invoiceDAL, IMapper mapper)
        {
            _invoiceDAL = invoiceDAL;
            _mapper = mapper;

        }

        [HttpGet("GetInvoice")]
        public async Task<IEnumerable<InvoiceReadDTO>> Get()
        {
            var results = await _invoiceDAL.GetAll();
            var invoiceDto = _mapper.Map<IEnumerable<InvoiceReadDTO>>(results);

            return invoiceDto;
        }

        [HttpPost("InsertInvoiceFromOrder")]
        public async Task<ActionResult> Post(InvoiceCreateDTO invoiceCreateDTO)
        {
            try
            {
                var newInvoice = _mapper.Map<Invoice>(invoiceCreateDTO);
                var result = await _invoiceDAL.Insert(newInvoice);
                var invoiceReadDto = _mapper.Map<InvoiceReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.InvoiceId }, invoiceReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
