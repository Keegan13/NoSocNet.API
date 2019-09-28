using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoSocNet.API.Models;

namespace NoSocNet.API.Controllers
{
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        [HttpPut]
        public async Task<ProfilePutResponseModel> Put([FromBody] ProfilePutInputModel input)
        {
            return new ProfilePutResponseModel
            {
                ResultCode = (int)ResultCode.Error,
                Data = new { },
                Messages = new List<string> { "something went wrong" }
            };
        }
        [HttpPut]
        [Route("status")]
        public async Task<StatusResponse> Put([FromBody] string status)
        {
            return new StatusResponse
            {
                ResultCode = (int)ResultCode.Error,
                Data = new { },
                Messages = new List<string> { "something went wrong" }
            };
        }
        [HttpGet]
        [Route("status/{userId}")]
        public async Task<string> Get(int userId)
        {
            return "Status endpoint";
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ProfileResponseModel> GetProfile(int userId)
        {
            return new ProfileResponseModel
            {

            };
        }

        [HttpPut]
        [Route("photo")]
        public async Task<PhotoViewModel> PutPhoto([FromForm] string image)
        {
            return null;
        }

    }
}