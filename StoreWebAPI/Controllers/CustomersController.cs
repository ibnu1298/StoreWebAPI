using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Dtos.Customer;
using StoreWebAPI.Helpers;
using StoreWebAPI.Models;
using StoreWebAPI.Services;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CustomersController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Resgistration(CreateCustDTO custDTO)
        {
            try
            {
                var newCustomer = _mapper.Map<Customer>(custDTO);
                var response = await _userService.Registration(newCustomer);
                var view = _mapper.Map<ReadCustDTO>(response);
                return Ok(view);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public IActionResult Login(AuthenticateRequest model)
        {
            var response = _userService.Login(model);
            if (response == null)
                return BadRequest(new { message = "Email Or Password Is Incorrect" });
            return Ok(response);
        }
        //[Authorize]
        [HttpPut("UpdateBio")]
        public async Task<ActionResult> UpdateBio(ReadCustAddressDTO custDTO)
        {
            try
            {
                var resultCust = _mapper.Map<Customer>(custDTO);
                var result = await _userService.Update(resultCust);
                return Ok(custDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
