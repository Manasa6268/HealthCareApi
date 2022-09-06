using AdminApi.Models;

namespace AdminApi.Services
{
    public interface IAdminService
    {
        string AddMember(MemberDetails memberDetails);
        string CreateAccount(UserDetails userDetails);
        List<MemberList> GetMemberDetails(string? memberId, string? firstName, string? lastName, string? claimId, string? physicianName);
        public string SubmitClaim(ClaimDetails claimDetails);
    }
}