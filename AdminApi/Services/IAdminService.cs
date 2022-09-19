using AdminApi.Models;

namespace AdminApi.Services
{
    public interface IAdminService
    {
        
        string CreateAccount(MemberDetails memberDetails);
        List<MemberList> GetMemberDetails(string? memberId, string? firstName, string? lastName, string? claimId, string? physicianName);
        List<StateDetails> GetStates();
        List<string> GetUserNames();
        List<PhysicianDetails> GetPhysicianNames();

        List<string> GetEmails();
        List<UserTypes> GetUserTypes();
        
        public string AssignPhysician(PhysicianAssign PhysicianAssign);
    }
}