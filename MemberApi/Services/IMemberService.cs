using MemberApi.Models;

namespace MemberApi.Services
{
    public interface IMemberService
    {
        MemberDetails FetchDetails(int Id);
        ClaimDetails FetchClaimDetails(string memberID);
        string SubmitClaim(ClaimDetails claimDetails);
        
    }
}