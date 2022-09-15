using AdminApi.Models;
using AdminApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminApi.Controllers
{
    [Produces("application/json")]
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
        public string CreateAccount([FromBody] MemberDetails memberDetails)
        {
            try
            {
                return _adminService.CreateAccount(memberDetails);
            }
            catch
            {
                return "User Cannot be Created";

            }
        }
        

       // [Authorize]
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
        //[Authorize]
        //[HttpPost]
        //[Route("SubmitClaim")]
        //public string SubmitClaim([FromBody] ClaimDetails claimDetails)
        //{
        //    try
        //    {
        //        return _adminService.SubmitClaim(claimDetails);
        //    }
        //    catch
        //    {
        //        throw new Exception("Claim Cannot be Submitted");
        //    }
        //}
       // [Authorize]
        [HttpGet]
        [Route("GetMemberDetails")]
        public List<MemberList> GetMemberDetails(string? MemberId, string? FirstName, string? LastName, string? ClaimId, string? PhysicianName)
        {
            try
            {
                return _adminService.GetMemberDetails(MemberId,FirstName,LastName,ClaimId,PhysicianName);
            }
            catch 
            {
                throw new Exception("No Members found");

            }
        }
        
        [HttpGet]
        [Route("states")]
        public ActionResult<List<StateDetails>> GetStates()
        {
            try
            {
                return Ok(_adminService.GetStates());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("usertypes")]
        public ActionResult<List<UserTypes>> GetUserTypes()
        {
            try
            {
                return Ok(_adminService.GetUserTypes());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("usernames")]
        public ActionResult<List<string>> GetUserNames()
        {
            try
            { 
            
                return Ok(_adminService.GetUserNames());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("mails")]
        public ActionResult<List<string>> GetMails()
        {
            try
            {

                return Ok(_adminService.GetEmails());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("phyisiciannames")]
        public ActionResult<List<PhysicianDetails>> GetPhysicianName()
        {
            try
            {

                return Ok(_adminService.GetPhysicianNames());
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost]
        [Route("AssignPhysician")]
        public string AssignPhysician([FromBody] PhysicianAssign PhysicianAssign)
        {
            try
            {

                return _adminService.AssignPhysician(PhysicianAssign);
            }
            catch
            {
                return "Physician cannot be Assigned";
            }
        }
    }
}
