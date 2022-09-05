using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("login")]
        public ActionResult<string> memberlogin()
        {
            return Ok("login successfull");
        }
    }
}
