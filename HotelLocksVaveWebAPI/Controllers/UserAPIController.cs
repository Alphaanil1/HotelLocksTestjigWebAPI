using HotelLockVave.BLL;
using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace  HotelLocksWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        public UserService objUserService;
        public IEmailService iemailService;
        private readonly IJWTManagerRepository _jWTManager;
        private IConfiguration configuration;

        public UserAPIController(IEmailService emailService, IJWTManagerRepository jWTManager, IConfiguration _configuration)
        {
            objUserService = new UserService(emailService, jWTManager);
            this._jWTManager = jWTManager;
            this.configuration = _configuration;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ResultViewModel<UserLoginResponseViewModel> Login(UserLoginRequestViewModel objLogin)
        {
            ResultViewModel<UserLoginResponseViewModel> objResult = objUserService.Login(objLogin.UserName, objLogin.Password);
            return objResult;
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public ActionResult<ResultViewModel<AddUserResponseViewModel>> AddUser(AddUserRequestViewModel addUserRequest)
        {
            var result = objUserService.AddUser(addUserRequest);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public ResultViewModel<List<UserDetails>> GetUsers()
        {
            ResultViewModel<List<UserDetails>> objResult = objUserService.GetUsers();
            return objResult;
        }
    }
}
