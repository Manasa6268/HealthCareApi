using AuthorizationApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthorizationApi.Services
{
    public class UserTokenService : IUserTokenService
    {
        private readonly DbMasterContext _dbMasterContext;
        public UserTokenService(DbMasterContext dbMasterContext)
        {
            _dbMasterContext = dbMasterContext;
        }

        public List<MemberDetails> UserValidation(string username, string password)
        {
            try
            {
                var status = _dbMasterContext.memberDetails.Where(x => x.UserName == username && x.Password == password).ToList();
                if (status.Count!=0)
                {
                    return status;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)     
            {
                throw new Exception(ex.Message);

            }
        }
        public string BuildToken(string key, string issuer, IEnumerable<string> audience, List<MemberDetails> memberDetails)
        {
            
            try
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("sub", ((memberDetails[0].Code) + (memberDetails[0].Id)).ToString()));
                claims.Add(new Claim("Id", (memberDetails[0].Id).ToString()));
                claims.Add(new Claim("UserName", memberDetails[0].UserName));
                claims.Add(new Claim(ClaimTypes.Role, memberDetails[0].UserType));
                
                claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims, notBefore: DateTime.Now, expires: DateTime.Now.Add(new TimeSpan(0, 30, 00)),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
