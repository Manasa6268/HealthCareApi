using AdminApi.Models;
using AdminApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult CreateAccount([FromBody] MemberDetails memberDetails)
        {
            try
            {
                return Ok(_adminService.CreateAccount(memberDetails));
            }
            catch
            {
                return BadRequest();
            }
        }
        

        [Authorize(Policy = "Admins")]
        [HttpPost]
        [Route("AddMember")]
        public IActionResult AddMember([FromBody] MemberDetails memberDetails)
        {
            try
            {
                return Ok(_adminService.AddMember(memberDetails));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Policy = "Admins")]
        [HttpPost]
        [Route("SubmitClaim")]
        public IActionResult SubmitClaim([FromBody] ClaimDetails claimDetails)
        {
            try
            {
                return Ok(_adminService.SubmitClaim(claimDetails));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize(Policy = "Admins")]
        [HttpGet]
        [Route("GetMemberDetails")]
        public ActionResult<List<MemberList>> GetMemberDetails(string? MemberId, string? FirstName, string? LastName, string? ClaimId, string? PhysicianName)
        {
            try
            {
                return Ok(_adminService.GetMemberDetails(MemberId,FirstName,LastName,ClaimId,PhysicianName));
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}
