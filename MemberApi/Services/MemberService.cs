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
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string UpdateMember(MemberDetails memberDetails)
        {
            try
            {
                string id = RandomString(8);
                UserDetails user = new UserDetails(

                    id,
                    memberDetails.UserName,
                   memberDetails.Password,
                    "member"
               );
                _memberContext.UserDetails.Add(user);

                MemberDetails member = new MemberDetails
                    {
                        MemberId = id,
                        FirstName = memberDetails.FirstName,
                        LastName = memberDetails.LastName,
                        UserName = memberDetails.UserName,
                        Password=memberDetails.Password,
                        DOB = DateTime.Now,
                        Address = memberDetails.Address,
                        City = memberDetails.City,
                        State = memberDetails.State,
                        Email = memberDetails.Email,
                        PhysicianName = memberDetails.PhysicianName,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = memberDetails.ModifiedBy,


                    };
                    _memberContext.MemberDetails.Add(member);
                    _memberContext.SaveChanges();
                    return "Member Successfully added";
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public string SubmitClaim(ClaimDetails claimDetails)
        {
            try
            {
                ClaimDetails claim = new ClaimDetails
                {
                    ClaimId = RandomString(8),
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

        public MemberDetails FetchDetails(string memberId)
        {
           return _memberContext.MemberDetails.Where(member => member.MemberId == memberId).FirstOrDefault();
        }
    }
}
