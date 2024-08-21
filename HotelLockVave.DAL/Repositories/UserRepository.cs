using Dapper;
using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.BusinessObjects.Models.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelLockVave.DAL.Repositories
{
    public class UserRepository
    {
        public UserLoginResponseViewModel Login(string username, string password)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objUser = objDBConnection.connection.Query<UserLoginResponseViewModel>("[dbo].[Usp_Sel_Login]", new { @UserName = username, @Password = password },
                 commandType: CommandType.StoredProcedure).SingleOrDefault();

                objDBConnection.CloseConnection();
                return objUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        public AddUserResponseViewModel AddUser(AddUserRequestViewModel addUserRequest)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FirstName", addUserRequest.FirstName);
                parameters.Add("@LastName", addUserRequest.LastName);
                parameters.Add("@UserName", addUserRequest.UserName);
                parameters.Add("@Password", addUserRequest.Password);
                parameters.Add("@MobileNo", addUserRequest.MobileNo);
                parameters.Add("@UserRole", addUserRequest.UserRole);
                parameters.Add("@Address", addUserRequest.Address);
                parameters.Add("@EmailID", addUserRequest.EmailID);

                return objDBConnection.connection.Query<AddUserResponseViewModel>("[dbo].[Usp_Ins_AddUser]", parameters,
                commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        public List<UserDetails> GetUsers()
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objGetUser = objDBConnection.connection.Query<UserDetails>("[dbo].[Get_UserDetails]",
                commandType: CommandType.StoredProcedure).ToList();

                objDBConnection.CloseConnection();
                return objGetUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

        public UserLoginResponseViewModel GetUser(int userID)
        {
            DBConnection objDBConnection = new DBConnection();
            try
            {
                var objUser = objDBConnection.connection.Query<UserLoginResponseViewModel>("[dbo].[Usp_Sel_GetUser]", new { @UserID = userID },
                 commandType: CommandType.StoredProcedure).SingleOrDefault();

                objDBConnection.CloseConnection();
                return objUser;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objDBConnection.CloseConnection();
            }
        }

    }
}
