using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoSocNet.API.Models;

namespace NoSocNet.API.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [HttpGet]
        public ActionResult<ListViewModel<UserViewModel>> Get([FromQuery] UserListInputModel filter)
        {
            try
            {
                return new UserList
                {
                    Error = null,
                    TotalCount = 0,
                    Items = new[] {
                    new UserViewModel {
                        Followed=false,
                        Id=111,
                        Name="TestUser",
                        Photos=new PhotoViewModel{
                            Large=null,
                            Small=null
                        },
                        Status="Hi! i am React JS Junior developer and I am looking for a job"
                    }
                }
                };
            }
            catch (Exception ex)
            {
                return new UserList
                {
                    Error = ex.Message
                };
            }
        }
    }
}