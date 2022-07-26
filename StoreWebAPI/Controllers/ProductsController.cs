using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Dtos.Product;
using StoreWebAPI.Models;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduct _productDAL;
        private readonly DataContext _context;

        public ProductsController(IProduct productDAL, IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _productDAL = productDAL;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ReadProductDTO>> Get()
        {
            var results = await _productDAL.GetAll();
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results);
            return product;
        }
        [HttpGet("WithCategory")]
        public async Task<IEnumerable<ReadProductCategoryDTO>> GetWithCategory()
        {
            var results = await _productDAL.GetProductWithCategory();
            var product = _mapper.Map<IEnumerable<ReadProductCategoryDTO>>(results);
            return product;
        }
        [HttpGet("HighToLow")]
        public async Task<IEnumerable<ReadProductDTO>> GetHighToLow()
        {
            var results = await _productDAL.HighToLow();
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results);
            return product;
        }
        [HttpGet("LowToHigh")]
        public async Task<IEnumerable<ReadProductDTO>> GetLowToHigh()
        {
            var results = await _productDAL.LowToHigh();
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results);
            return product;
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateProductDTO createProduct)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(createProduct);
                var result = await _productDAL.Insert(newProduct);
                var product = _mapper.Map<ReadProductDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddProductWithCategory")]
        public async Task<ActionResult> PostWithCategory(CreateProductCategory createProduct)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(createProduct);
                var result = await _productDAL.Insert(newProduct);
                var product = _mapper.Map<ReadProductCategoryDTO>(result);
                return CreatedAtAction("Get", new { id = result.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByName/{name}")]
        public async Task<IEnumerable<ReadProductDTO>> GetByName(string name)
        {

            var results = await _productDAL.GetByName(name);
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results); ;
            return product;
        }
        [HttpGet("ByCategory/{name}")]
        public async Task<IEnumerable<ReadProductCategoryDTO>> GetSamuraiWithBattles(string name)
        {
            var results = await _productDAL.GetByCategory(name);
            var product = _mapper.Map<IEnumerable<ReadProductCategoryDTO>>(results);
            return product;
        }
        [HttpGet("ByPrice/{price}")]
        public async Task<IEnumerable<ReadProductDTO>> GetProductByPrice(double price)
        {
            var results = await _productDAL.GetByPrice(price);
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results); ;
            return product;
        }
        [HttpGet("ByPriceToLow/{price}")]
        public async Task<IEnumerable<ReadProductDTO>> GetProductByPriceToLow(double price)
        {
            var results = await _productDAL.GetByPriceToLow(price);
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results);
            return product;
        }
        [HttpGet("ByPriceToLow/{high}/{low}")]
        public async Task<IEnumerable<ReadProductDTO>> GetProductByPriceBetween(double high, double low)
        {
            var results = await _productDAL.GetPriceBetween(high,low);
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results);
            return product;
        }
        [HttpGet("ByPriceToHigh/{price}")]
        public async Task<IEnumerable<ReadProductDTO>> GetProductByPriceToHigh(double price)
        {
            var results = await _productDAL.GetByPriceToHigh(price);
            var product = _mapper.Map<IEnumerable<ReadProductDTO>>(results); ;
            return product;
        }
        [HttpGet("Pagnation/{page}")]
        public async Task<IEnumerable<ReadProductCategoryDTO>> GetPage(int page)
        {
            var results = await _productDAL.GetProductWithCategory();
            var product = _mapper.Map<IEnumerable<ReadProductCategoryDTO>>(results);
            var record = 20;
            var finalResult = product.Skip((page - 1) * record).Take(record).ToList();
            return finalResult;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _productDAL.Delete(id);
                return Ok($"Data Product dengan id {id} Berhasil di delete");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<List<ReadProductCategoryDTO>>> updateProduct(UpdateProductCategoryDTO productDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(s => s.Id == productDTO.Id);
            if (product == null)
                return BadRequest($"Product dengan Id = {productDTO.Id} Tidak ditemukan");
            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.Stock = productDTO.Stock;
            product.CategoryId = productDTO.CategoryId;
            await _context.SaveChangesAsync();
            return Ok(productDTO);
        }
    }
}
