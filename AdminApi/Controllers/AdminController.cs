using AdminApi.Models;
using AdminApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult CreateAccount([FromBody] UserDetails userDetails)
        {
            try
            {
                return Ok(_adminService.CreateAccount(userDetails));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok("login Successfull");
        }
    }
}
