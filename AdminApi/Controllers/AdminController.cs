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
        
        [Authorize(Role.Admin)]
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
        [Authorize]
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
        [Authorize]
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
        private UserClaims VerifyUser(ClaimsIdentity identity)
        {
            UserClaims userClaims = new UserClaims();
            userClaims.UserName = identity.FindFirst("UserName").Value.ToString();
            userClaims.UserType = identity.FindFirst("UserType").Value.ToString();
            return userClaims;
        }
    }
}
