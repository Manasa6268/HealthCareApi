using EFCore.BulkExtensions;
using MemberApi.Models;
namespace MemberApi.Services
{
    public class MemberService : IMemberService
    {
        private readonly DbMemberContext _memberContext;
        public MemberService(DbMemberContext memberContext)
        {
            _memberContext = memberContext;
        }
        public string SubmitClaim(ClaimDetails claimDetails)
        {
            try
            {
                List<ClaimDetails> claims = new List<ClaimDetails>();
                claims.Add(new ClaimDetails()
                {
                    Code = "HCMC",
                    Id = 0,
                    MemberId = claimDetails.MemberId,
                    ClaimType = claimDetails.ClaimType,
                    ClaimDate = claimDetails.ClaimDate,
                    ClaimAmount = claimDetails.ClaimAmount,
                    Remarks = claimDetails.Remarks,
                    CreatedBy = claimDetails.CreatedBy,



                });
                _memberContext.BulkInsert(claims);
                _memberContext.SaveChanges();
                return "Claim Successfully Submitted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public MemberDetails FetchDetails(int Id)
        {
           return _memberContext.MemberDetails.Where(member => member.Id == Id).First();
        }
        public List<ClaimDetails> FetchClaimDetails(string memberID)
        {
            return _memberContext.ClaimDetails.Where(claim => claim.MemberId == memberID).ToList();
        }
    }
}
