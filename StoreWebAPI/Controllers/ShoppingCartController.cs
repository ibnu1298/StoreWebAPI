using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Dtos.ShoppingCart;
using StoreWebAPI.Models;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCart _shoppingCartDAL;
        private readonly IMapper _mapper;
        public ShoppingCartController(IShoppingCart shoppingCartDAL, IMapper mapper)
        {
            _shoppingCartDAL = shoppingCartDAL;
            _mapper = mapper;
        }

        [HttpGet("GetShoppingCart")]
        public async Task<IEnumerable<ShoppingCartReadDTO>> Get()
        {
            var shoppingCartDal = await _shoppingCartDAL.GetAll();
            var shoppingCartDto = _mapper.Map<IEnumerable<ShoppingCartReadDTO>>(shoppingCartDal);
            return shoppingCartDto;
        }

        [HttpGet("GetShoppingCartWithCustomer")]
        public async Task<IEnumerable<ShoppingCartCustomerReadDTO>> GetShopingCartWithCustomer()
        {
            var shoppingCartDal = await _shoppingCartDAL.GetShopingCartWithCustomer();
            var shoppingCartDto = _mapper.Map<IEnumerable<ShoppingCartCustomerReadDTO>>(shoppingCartDal);
            return shoppingCartDto;
        }
    }
}
