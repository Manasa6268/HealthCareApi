using AuthorizationApi.Models;
using AuthorizationApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class AuthendicationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserTokenService _UserTokenService;
        public AuthendicationController(IConfiguration configuration, IUserTokenService userTokenService)
        {
            this._configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _UserTokenService = userTokenService;
        }
        // for token generation
        /// <summary>
        /// Validations the specified userdetails.
        /// </summary>
        /// <param name="userdetails">The userdetails.</param>
        /// <returns>ActionResult&lt;System.String&gt;.</returns>
        [HttpPost]
        [Route("gettoken")]
        public ActionResult<string> Validation([FromBody] UserData userdetails)
        {
            string result = string.Empty;
            List<MemberDetails> user = _UserTokenService.UserValidation(userdetails.UserName, userdetails.Password);
            if (user == null)
            {
                return Unauthorized();
            }
                result = _UserTokenService.BuildToken(_configuration["Jwt:Key"],
                                        _configuration["Jwt:Issuer"],
                                        new[]
                                        {
                                            _configuration["Jwt:Aud1"],
                                            _configuration["Jwt:Aud2"],
                                            _configuration["Jwt:Aud3"]
                                        },
                                        user);
            return Ok(result);
        }
    }
}
