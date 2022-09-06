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
        [Authorize(Role.Member)]
        [HttpGet]
        [Route("login")]
        public ActionResult<string> memberlogin()
        {
            return Ok("login successfull");
        }
        [Authorize]
        [HttpPost]
        [Route("UpdateMember")]
        public IActionResult UpdateMember([FromBody] MemberDetails memberDetails)
        {
            try
            {
                return Ok(_memberService.UpdateMember(memberDetails));
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
        public ActionResult<MemberDetails> FetchDetails(string MemberId)
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
    }
}
