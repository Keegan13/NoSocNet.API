using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoSocNet.API.Models;
using static NoSocNet.API.Extensions.ObjectExtensions;

namespace NoSocNet.API.Controllers
{

    [ApiController]
    [Route("security")]
    public class SecurityController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public CaptchaUrlResponse Get()
        {
            return new CaptchaUrlResponse
            {
                Url = null
            };
        }
    }
}