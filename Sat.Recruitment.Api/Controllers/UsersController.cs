using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Domain.Extensions;
using Sat.Recruitment.Api.Domain.Helpers;
using Sat.Recruitment.Api.Domain.IHelpers;
using Sat.Recruitment.Api.Domain.Model;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        IUserHelper userHelper;
        public UsersController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        [HttpPost]
        [Route("Test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Test()
        {
            return Ok();
        }

        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Result> CreateUser(string name, string email, string address, string phone, string userType, decimal money)
        {
            Result result = null;
            IUser newUser = userHelper.CreateUser(name, email, address, phone, userType, money);
            var errors = newUser.ValidateObject();
            if (errors != null)
            {
                result = new Result()
                {
                    IsSuccess = false,
                    Errors = errors.ErrorsToString()
                };
                return BadRequest(result);
            }
            else
            {
                if (userHelper.IsDuplicated(newUser))
                {
                    Debug.WriteLine("The user is duplicated");
                    result = new Result()
                    {
                        IsSuccess = false,
                        Errors = "The user is duplicated"
                    };
                    return BadRequest(result);
                }
                else
                {
                    Debug.WriteLine("User Created");
                    result = new Result()
                    {
                        IsSuccess = true,
                        Errors = "User Created"
                    };
                    return Ok(result);
                }
            }
        }
    }
}
