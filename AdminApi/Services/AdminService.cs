using AdminApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;

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
                    DOB =memberDetails.DOB,
                    Address = memberDetails.Address,
                    City = memberDetails.City,
                    State = memberDetails.State,
                    Email = memberDetails.Email,
                    PhysicianName = memberDetails.PhysicianName,
                    CreatedDate = memberDetails.CreatedDate,
                    ModifiedDate = memberDetails.ModifiedDate,
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
                List<ClaimDetails> claims= new List<ClaimDetails>();
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
                _adminContext.BulkInsert(claims);
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

            string sql = "EXEC [dbo].[GetMemberDetails] @MemberId,@FirstName,@LastName,@PhysicianName,@ClaimId";
            List<SqlParameter> parms = new List<SqlParameter>
    {
        // Create parameter(s)    
        new SqlParameter { ParameterName = "@MemberId", Value = MemberId==null ? " " : MemberId},
         new SqlParameter { ParameterName = "@FirstName", Value = FirstName==null ? " " : FirstName },
          new SqlParameter { ParameterName = "@LastName", Value = LastName==null ? " " : LastName },
          new SqlParameter { ParameterName = "@PhysicianName", Value = PhysicianName==null ? " " : PhysicianName },
           new SqlParameter { ParameterName = "@ClaimId", Value = ClaimId==null ? " " : ClaimId },
            


    };
            if (parms.Count != 0)
            {
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
            else
            {
                return null;
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
        public List<string> GetEmails()
        {
            return _adminContext.MemberDetails.Select(member => member.Email).ToList();
        }

        public List<PhysicianDetails> GetPhysicianNames()
        {
            return _adminContext.PhysicianDetails.ToList();
        }

        public string AssignPhysician(PhysicianAssign PhysicianAssign)
        {
            
            int a = Convert.ToInt32(PhysicianAssign.MemberId.Substring(4));
            var member = _adminContext.MemberDetails.Find(a);
            if(member !=null)
            {
                member.PhysicianName = PhysicianAssign.PhysicianName;
                member.ModifiedDate = DateTime.Now.Date;
                member.ModifiedBy = PhysicianAssign.AdminId;
                _adminContext.MemberDetails.Update(member);
                _adminContext.SaveChanges();
                return "Physician Assigned Successfully";
            }
            else
            {
                return "Member Not found";
            }
        }
    }
}
