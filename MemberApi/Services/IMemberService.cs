using MemberApi.Models;

namespace MemberApi.Services
{
    public interface IMemberService
    {
        MemberDetails FetchDetails(string memberId);
        string SubmitClaim(ClaimDetails claimDetails);
        string UpdateMember(MemberDetails memberDetails);
    }
}