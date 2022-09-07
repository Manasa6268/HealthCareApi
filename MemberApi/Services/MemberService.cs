using MemberApi.Models;
using System.Net;

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
                ClaimDetails claim = new ClaimDetails
                {
                    Code = "HCMC",
                    Id=0,
                    MemberId = claimDetails.MemberId,
                    ClaimType = claimDetails.ClaimType,
                    ClaimDate = DateTime.Now.Date,
                    ClaimAmount = claimDetails.ClaimAmount,
                    Remarks = claimDetails.Remarks,
                    CreatedBy = claimDetails.CreatedBy,



                };
                _memberContext.ClaimDetails.Add(claim);
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
           return _memberContext.MemberDetails.Where(member => member.Id == Id).FirstOrDefault();
        }
        public ClaimDetails FetchClaimDetails(string memberID)
        {
            return _memberContext.ClaimDetails.Where(claim => claim.MemberId == memberID).FirstOrDefault();
        }
    }
}
