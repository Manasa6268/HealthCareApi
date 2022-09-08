using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models
{
   
   
    public class MemberDetails
    {
        [Key]
        
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string UserType { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string Email { get; set; }

        public string PhysicianName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }



    }

   

    public class ClaimDetails
    {
        [Key,Required]
        public int Id { get; set; }
        public string Code { get; set; }
        public string MemberId { get; set; }
        public string ClaimType { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
        public string Remarks { get; set; }

        public string CreatedBy { get; set; }



    }
    public class MemberList
    {
        [Key]
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhysicianName { get; set; }
        public string ClaimId { get; set; }
        
        
        public int ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
    }
    public struct Role
    {
        public const string Admin = "admin";
        public const string Member = "member";
    }
    public class StateDetails
    {
        [Key]
        public int id { get; set; }
        public string state { get; set; }
    }
    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        public string UserType { get; set; }
    }


}
