using MemberApi.Models;
using MemberApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        
        [Authorize]
        [HttpPost]
        [Route("SubmitClaim")]
        public IActionResult SubmitClaim([FromBody] ClaimDetails claimDetails)
        {
            try
            {
                return Ok(_memberService.SubmitClaim(claimDetails));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet]
        [Route("fetchDetails")]
        public ActionResult<MemberDetails> FetchDetails(int MemberId)
        {
            try
            {
                return Ok(_memberService.FetchDetails(MemberId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet]
        [Route("fetchClaimDetails")]
        public ActionResult<List<ClaimDetails>> FetchClaimDetails(string MemberId)
        {
            try
            {
                return Ok(_memberService.FetchClaimDetails(MemberId));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
