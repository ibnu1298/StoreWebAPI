using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Data.DAL;
using StoreWebAPI.Dtos.Address;
using StoreWebAPI.Models;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddress _addressDAL;
        private readonly IMapper _mapper;

        public AddressesController(IAddress adresDAL, IMapper mapper)
        {
            _addressDAL = adresDAL;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<ReadAddressDTO>> Get()
        {
            var results = await _addressDAL.GetAll();
            var samuraiDTO = _mapper.Map<IEnumerable<ReadAddressDTO>>(results);

            return samuraiDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateAddressDTO samuraiCreateDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Address>(samuraiCreateDto);
                var result = await _addressDAL.Insert(newSamurai);
                var samuraiReadDto = _mapper.Map<ReadAddressDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, samuraiReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(UpdateAddressDTO addressDTO)
        {
            try
            {
                var resultAddress = _mapper.Map<Address>(addressDTO);
                var result = await _addressDAL.Update(resultAddress);
                return Ok(addressDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _addressDAL.Delete(id);
                return Ok($"Data address dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
