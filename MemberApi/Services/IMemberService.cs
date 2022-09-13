using MemberApi.Models;

namespace MemberApi.Services
{
    public interface IMemberService
    {
        MemberDetails FetchDetails(int Id);
        List<ClaimDetails> FetchClaimDetails(string memberID);
        string SubmitClaim(ClaimDetails claimDetails);
        
    }
}