using AdminApi.Models;
using AdminApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
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
        public List<StateDetails> GetStates()
        {
            try
            {
                return _adminService.GetStates();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("usertypes")]
        public List<UserTypes> GetUserTypes()
        {
            try
            {
                return _adminService.GetUserTypes();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("usernames")]
        public List<string> GetUserNames()
        {
            try
            { 
            
                return _adminService.GetUserNames();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("mails")]
        public List<string> GetMails()
        {
            try
            {
                return _adminService.GetEmails();
            }
            catch
            {
                return null;
            }
        }
        [HttpGet]
        [Route("phyisiciannames")]
        public List<PhysicianDetails> GetPhysicianName()
        {
            try
            {

                return _adminService.GetPhysicianNames();
            }
            catch
            {
                return null;
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
