using MemberApi.Models;
using MemberApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        
        [Authorize(Policy = "Members")]
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
        [Authorize(Policy = "Members")]
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
        [Authorize(Policy = "Members")]
        [HttpGet]
        [Route("fetchClaimDetails")]
        public ActionResult<ClaimDetails> FetchClaimDetails(string MemberId)
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
