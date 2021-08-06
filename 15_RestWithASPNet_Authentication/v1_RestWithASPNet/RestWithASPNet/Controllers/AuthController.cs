using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNet.Business;
using RestWithASPNet.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {

            try
            {

                if (user == null) return BadRequest("Invalid client request");

                var token = _loginBusiness.ValidateCredentials(user);

                if (token == null) return Unauthorized();

                return Ok(token);

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {

            try
            {

                if (tokenVo == null) return BadRequest("Invalid client request");

                var token = _loginBusiness.ValidateCredentials(tokenVo);

                if (token == null) return BadRequest("Invalid client request");

                return Ok(token);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
