using MemberApi.Models;
using MemberApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemberApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        
        [HttpPost]
        [Route("SubmitClaim")]
        public string SubmitClaim([FromBody] ClaimDetails claimDetails)
        {
            try
            {
                return _memberService.SubmitClaim(claimDetails);
            }
            catch
            {
                return "Claim Cannot be Submitted";
            }
        }
        [Authorize]
        [HttpGet]
        [Route("fetchDetails")]
        public MemberDetails FetchDetails(int MemberId)
        {
            try
            {
                return _memberService.FetchDetails(MemberId);
            }
            catch
            {
                return null;
            }
        }
        [Authorize]
        [HttpGet]
        [Route("fetchClaimDetails")]
        public List<ClaimDetails> FetchClaimDetails(string MemberId)
        {
            try
            {
                return _memberService.FetchClaimDetails(MemberId);
            }
            catch
            {
                return null;
            }
        }
    }
}
