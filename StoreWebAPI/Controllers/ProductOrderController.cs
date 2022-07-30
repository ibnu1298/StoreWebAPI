using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Dtos.Order;
using StoreWebAPI.Dtos.ShoppingCart;
using StoreWebAPI.Models;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrder _orderDAL;
        public ProductOrderController(IOrder orderDAL, IMapper mapper)
        {
            _mapper = mapper;
            _orderDAL = orderDAL;
        }


        [HttpGet("GetOrderProduct")]
        public async Task<IEnumerable<ReadOrderDTO>> Get()
        {
            var orderDal = await _orderDAL.GetAll();
            var orderDto = _mapper.Map<IEnumerable<ReadOrderDTO>>(orderDal);
            return orderDto;
        }

        [HttpPost("InsertOrderProduct")]
        public async Task<ActionResult> Post(CreateOrderDTO createOrderDTO)
        {
            try
            {
                var orderDto = _mapper.Map<Order>(createOrderDTO);
                var newOrder = await _orderDAL.Insert(orderDto);


                var orderReadDal = await _orderDAL.GetAll();
                var orderRead = _mapper.Map<IEnumerable<ReadOrderDTO>>(orderReadDal);

                return CreatedAtAction("Get",
                    new { id = newOrder.OrderId }, orderRead);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
