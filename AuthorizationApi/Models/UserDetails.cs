using System.ComponentModel.DataAnnotations;

namespace AuthorizationApi.Models
{
    public class UserData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
      
    }

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
    public struct Role
    {
        public const string Admin = "Admin";
        public const string Guest = "Guest";
    }


}
