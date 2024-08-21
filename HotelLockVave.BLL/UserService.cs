using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.BusinessObjects.Models.Utility;
using HotelLockVave.DAL.Repositories;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HotelLockVave.BLL
{
    public class UserService
    {
        private UserRepository objUserRepository;
      
        IEmailService objEmailService = null;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly Encrypt _encrypt = new Encrypt("alphaict2019");
       
        public UserService(IEmailService emailService, IJWTManagerRepository jWTManager)
        {
            objUserRepository = new UserRepository();
            objEmailService = emailService;
            this._jWTManager = jWTManager;
           
        }

      

        public ResultViewModel<UserLoginResponseViewModel> Login(string username, string password)
        {
            try
            {
                UserLoginResponseViewModel objUser = new UserLoginResponseViewModel();

                if (string.IsNullOrWhiteSpace(username))
                {
                    return new ResultViewModel<UserLoginResponseViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = UserMessage.BlankUserNamePasswordMessage };  //
                }
                else if (string.IsNullOrWhiteSpace(password))
                {
                    return new ResultViewModel<UserLoginResponseViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = UserMessage.BlankUserNamePasswordMessage };
                }
                else
                {

                    // Encrypt the password before sending it to the repository
                    objUser = objUserRepository.Login(username, _encrypt.EncryptString(password));
                    if (objUser != null && objUser.UserID > 0)
                    {
                        var token = _jWTManager.Authenticate(objUser);
                        objUser.Token = token.Token.ToString();

                        return new ResultViewModel<UserLoginResponseViewModel> { Result = objUser, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.LoginSuccessMessage };
                    }
                    else
                    {
                        return new ResultViewModel<UserLoginResponseViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.Unauthorized, Message = Message.Failure.ToString(), UserMessage = "Invalid Credentials" };   //changes instead of user does not exist
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<UserLoginResponseViewModel> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };
            }
        }


        public ResultViewModel<AddUserResponseViewModel> AddUser(AddUserRequestViewModel addUserRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(addUserRequest.UserName))
                {
                    return new ResultViewModel<AddUserResponseViewModel>
                    {
                        Result = null,
                        ResponseCode = System.Net.HttpStatusCode.BadRequest,
                        Message = "Failure",
                        UserMessage = "Username is required."
                    };
                }

                addUserRequest.Password = _encrypt.EncryptString(addUserRequest.Password);
                var addedUser = objUserRepository.AddUser(addUserRequest);

                return new ResultViewModel<AddUserResponseViewModel>
                {
                    Result = addedUser,
                    ResponseCode = System.Net.HttpStatusCode.OK,
                    Message = "Success",
                    UserMessage = "User added successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultViewModel<AddUserResponseViewModel>
                {
                    Result = null,
                    ResponseCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Exception",
                    UserMessage = ex.ToString()
                };
            }
        }

        public ResultViewModel<List<UserDetails>> GetUsers()
        {
            try
            {
                    List<UserDetails> objResponse = objUserRepository.GetUsers();
                    if (objResponse == null)
                    {
                        return new ResultViewModel<List<UserDetails>> { Result = null, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Failure.ToString(), UserMessage = UserMessage.ReloginUser };
                    }
                    else
                    {
                        return new ResultViewModel<List<UserDetails>> { Result = objResponse, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = UserMessage.Success };
                    }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<List<UserDetails>> { Result = null, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = Message.Exception.ToString() + ": " + ex.Message };
            }
        }

        public ResultViewModel<bool> IsUserExists(int UserID)
        {
            try
            {
                UserLoginResponseViewModel objUser = new UserLoginResponseViewModel();

                if (UserID <= 0)
                {
                    return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.BadRequest, Message = Message.Failure.ToString(), UserMessage = "UserID is required" };  //
                }
                else
                {
                    objUser = objUserRepository.GetUser(UserID);
                    if (objUser != null && objUser.UserID > 0)
                    {
                        return new ResultViewModel<bool> { Result = true, ResponseCode = System.Net.HttpStatusCode.OK, Message = Message.Success.ToString(), UserMessage = "User exists" };
                    }
                    else
                    {
                        return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.NotFound, Message = Message.Failure.ToString(), UserMessage = "User does not exists" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultViewModel<bool> { Result = false, ResponseCode = System.Net.HttpStatusCode.InternalServerError, Message = Message.Exception.ToString(), UserMessage = ex.ToString() };

            }

        }


    
}
}
