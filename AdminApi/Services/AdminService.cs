using AdminApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace AdminApi.Services
{
    public class AdminService : IAdminService
    {
        private readonly DbAdminContext _adminContext;
        public AdminService(DbAdminContext adminContext)
        {
            _adminContext = adminContext;
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string CreateAccount(UserDetails userDetails)
        {
            try
            {
                UserDetails user = new UserDetails(

                     RandomString(8),
                     userDetails.UserName,
                    userDetails.Password,
                     userDetails.UserType
                );
                _adminContext.UserDetails.Add(user);
                _adminContext.SaveChanges();
                return "Account Successfully Created";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public string AddMember(MemberDetails memberDetails)
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
                _adminContext.UserDetails.Add(user);
                
                MemberDetails member = new MemberDetails
                {
                    MemberId = id,
                    FirstName = memberDetails.FirstName,
                    LastName = memberDetails.LastName,
                    UserName = memberDetails.UserName,
                    Password = memberDetails.Password,
                    DOB = DateTime.Now,
                    Address=memberDetails.Address,
                    City=memberDetails.City,    
                    State=memberDetails.State,
                    Email=memberDetails.Email,
                    PhysicianName=memberDetails.PhysicianName,
                    CreatedDate=DateTime.Now,
                    ModifiedDate= DateTime.Now,
                    ModifiedBy=memberDetails.ModifiedBy,


                };
                _adminContext.MemberDetails.Add(member);
                _adminContext.SaveChanges();
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
                    ClaimType=claimDetails.ClaimType,
                    ClaimDate=DateTime.Now.Date,
                    ClaimAmount =claimDetails.ClaimAmount,
                   Remarks= claimDetails.Remarks,
                   CreatedBy=claimDetails.CreatedBy,



                };
                _adminContext.ClaimDetails.Add(claim);
                _adminContext.SaveChanges();
                return "Claim Successfully Submitted";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        
        public List<MemberList> GetMemberDetails(string? MemberId, string? FirstName, string? LastName, string? ClaimId,string? PhysicianName)
        {

            string sql = "EXEC [dbo].[GetMemberDetails] @MemberId,@FirstName,@LastName,@ClaimId,@PhysicianName";
            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@MemberId", Value = MemberId==null ? "" : MemberId},
         new SqlParameter { ParameterName = "@FirstName", Value = FirstName==null ? "" : FirstName },
          new SqlParameter { ParameterName = "@LastName", Value = LastName==null ? "" : LastName },
           new SqlParameter { ParameterName = "@ClaimId", Value = ClaimId==null ? "" : ClaimId },
            new SqlParameter { ParameterName = "@PhysicianName", Value = PhysicianName==null ? "" : PhysicianName },


    };

            List<MemberList> list = _adminContext.MemberList.FromSqlRaw<MemberList>(sql, parms.ToArray()).ToList();


            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list;
            }

        }
    }
}
