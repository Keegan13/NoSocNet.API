using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoSocNet.API.Extensions;
using NoSocNet.API.Models;
using static NoSocNet.API.Extensions.ObjectExtensions;

namespace NoSocNet.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Object> userManager;
        private readonly ILogger logger;
        public AuthController(
            ILogger<AuthController> logger
            //UserManager<Object> userManager
            )
        {
            this.logger = logger;
        }

        [Authorize]
        [Route("me")]
        [HttpGet]
        public async Task<UserInfoResponse> Get()
        {
            try
            {
                return new UserInfoResponse
                {
                    Data = new UserInfo
                    {

                    },
                    ResultCode = (int)ResultCode.Success
                };
            }

            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return ErrorizeObject<UserInfoResponse>(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<LoginResponseModel> Post([FromBody] LoginInputModel input)
        {
            try
            {
                return new LoginResponseModel
                {
                    ResultCode = (int)ResultCode.Success,
                    Data = new { userId = 2 }
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return ErrorizeObject<LoginResponseModel>(ex);
            }
        }

        [HttpDelete]
        [Route("login")]
        public async Task<LoginResponseModel> Delete()
        {
            try
            {
                //logout user
                return new LoginResponseModel
                {
                    ResultCode = (int)ResultCode.Success
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                return ErrorizeObject<LoginResponseModel>(ex);
            }
        }
    }
}