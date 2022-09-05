using System.ComponentModel.DataAnnotations;

namespace AdminApi.Models
{
    public class UserDetails
    {
        [Key]
        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; }
        
        public string Password { get; set; }
        public string UserType { get; set; }

        public UserDetails(string userId, string userName, string password, string userType)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            UserType = userType;
        }
    }
}
