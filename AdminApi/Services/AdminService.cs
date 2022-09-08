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
        
        public string CreateAccount(MemberDetails memberDetails)
        {
            try
            {
                string code = null;
                if (memberDetails.UserType == "Admin")
                {
                    code = "HCMP";
                }
                else
                {
                    code = "HCMM";
                }
                MemberDetails member = new MemberDetails
                {
                    
                    Code = code,
                    Id = 0,
                    FirstName = memberDetails.FirstName,
                    LastName = memberDetails.LastName,
                    UserName = memberDetails.UserName,
                    Password = memberDetails.Password,
                    UserType = memberDetails.UserType,
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
                _adminContext.MemberDetails.Add(member);

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

                MemberDetails member = new MemberDetails
                {
                    Code = "HCMM",
                    Id = 0,
                    FirstName = memberDetails.FirstName,
                    LastName = memberDetails.LastName,
                    UserName = memberDetails.UserName,
                    Password = memberDetails.Password,
                    UserType = "Member",
                    DOB = DateTime.Now,
                    Address=memberDetails.Address,
                    City=memberDetails.City,    
                    State=memberDetails.State,
                    Email=memberDetails.Email,
                    PhysicianName=memberDetails.PhysicianName,
                    CreatedDate=DateTime.Now,
                    
                ModifiedDate = DateTime.Now,
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
                    Code = "HCMC",
                    Id = 0,
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

        public List<StateDetails> GetStates()
        {
            return _adminContext.stateDetails.ToList();
        }

        public List<UserTypes> GetUserTypes()
        {
            return _adminContext.userTypes.ToList();
        }

        public List<string> GetUserNames()
        {
            return _adminContext.MemberDetails.Select(member =>member.UserName).ToList();
        }
        public List<string> GetMails()
        {
            return _adminContext.MemberDetails.Select(member => member.Email).ToList();
        }
    }
}
