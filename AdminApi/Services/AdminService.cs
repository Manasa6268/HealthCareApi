using AdminApi.Models;

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
                _adminContext.Add(user);
                _adminContext.SaveChanges();
                return "Account Successfully Created";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
