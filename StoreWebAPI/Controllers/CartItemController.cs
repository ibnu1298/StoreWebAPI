using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Dtos.ShoppingCart;
using StoreWebAPI.Dtos.ShoppingCartDtos;
using StoreWebAPI.Models;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CartItemController(DataContext context, IShoppingCartItem ShoppingCartItem, IMapper mapper)
        {
            _shoppingCartItem = ShoppingCartItem;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetShoppingItemCart")]
        public async Task<IEnumerable<ShoppingCartItemReadDTO>> Get()
        {
            var shoppingCartItemDal = await _shoppingCartItem.GetAll();
            var shoppingCartItemDto = _mapper.Map<IEnumerable<ShoppingCartItemReadDTO>>(shoppingCartItemDal);
            return shoppingCartItemDto;
        }

        [HttpGet("ItemCartByShoppingCartId")]
        public async Task<IEnumerable<CartItemReadDTO>> GetUserCartByid(int id)
        {
            var shoppingCartItemDal = await _shoppingCartItem.CartItemGetById(id);
            var shoppingCartItemDto = _mapper.Map<IEnumerable<CartItemReadDTO>>(shoppingCartItemDal); ;
            return shoppingCartItemDto;
        }

        [HttpPost("InsertProductToShoppingCart")]
        public async Task<ActionResult> Post(ShoppingCartItemCreateDTO shoppingCartItemCreateDTO)
        {
            try
            {
                var shoppingCartItemDTO = _mapper.Map<ShoppingCartItem>(shoppingCartItemCreateDTO);
                var newshoppingCartItem = await _shoppingCartItem.Insert(shoppingCartItemDTO);
                var shoppingCartItemRead = _mapper.Map<ShoppingCartItemCreateDTO>(newshoppingCartItem);

                return CreatedAtAction("Get",
                    new { id = newshoppingCartItem.Id }, shoppingCartItemRead);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ShoppingCartItemUpdate")]
        public async Task<ActionResult> Put(ShoppingCartItemUpdateDTO shoppingCartItemUpdate)
        {
            try
            {
                var updateShoppingCartItem = new ShoppingCartItem
                {
                    Id = shoppingCartItemUpdate.Id,
                    Quatity = shoppingCartItemUpdate.Quatity,
                    ProductId = shoppingCartItemUpdate.ProductId,
                    ShoppingCartId= shoppingCartItemUpdate.ShoppingCartId,
                };
                var shoppingCartItem = await _shoppingCartItem.Update(updateShoppingCartItem);
                return Ok(shoppingCartItemUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAllItemFromShoppingCart")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _shoppingCartItem.Delete(id);
                return Ok($"Delete Data Shopping Cart Dengan Id {id} Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
