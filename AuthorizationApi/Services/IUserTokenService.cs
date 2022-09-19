using AuthorizationApi.Models;
namespace AuthorizationApi.Services
{
    public interface IUserTokenService
    {
        public string BuildToken(string key, string issuer, IEnumerable<string> audience,List<MemberDetails> memberDetails);
        public  List<MemberDetails> UserValidation(string username, string password);
    }
}