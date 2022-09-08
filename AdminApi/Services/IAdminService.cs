using AdminApi.Models;

namespace AdminApi.Services
{
    public interface IAdminService
    {
        string AddMember(MemberDetails memberDetails);
        string CreateAccount(MemberDetails memberDetails);
        List<MemberList> GetMemberDetails(string? memberId, string? firstName, string? lastName, string? claimId, string? physicianName);
        List<StateDetails> GetStates();
        List<string> GetUserNames();
        List<string> GetMails();
        List<UserTypes> GetUserTypes();
        public string SubmitClaim(ClaimDetails claimDetails);
    }
}