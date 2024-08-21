using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.BusinessObjects.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserPicURL { get; set; }
        public string Base64string { get; set; }
        public int UserRoleID { get; set; }
        public bool IsAdmin { get; set; }
        public long HotelID { get; set; }
        public long BranchID { get; set; }
        public bool Inactive { get; set; }       
        public string CountryCode { get; set; }
    }


    public class UserAccessRights :User
    {       
        public int ComponentTag   { get; set; }
        public string UserRight { get; set; }

    }

    public class UserViewModel: UserAccessRights
    {
        public string UserRoleName { get; set; }
        public int AllowConfiguration { get; set; }
        public int LiftControl { get; set; }
        public int RoomCreation { get; set; }
        public int RoomOperation { get; set; }
        public string Action { get; set; }
        public string ConfirmPassword { get; set; }

    }

    public class UserRoleMaster
    {
        [Key]
        public int RoleID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string RoleName { get; set; }

    }

   

    public class Tokens
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        public string ConfirmPassword { get; set; }
    }
    public class UserRoleRightsViewModel 
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public string TagName { get; set; }
        public bool IsView { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
    }


    //----------------------------------
    public class UserLoginRequestViewModel
    {   public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResponseViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public int RoleID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Token { get; set; }
    }


    public class AddUserRequestViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [StringLength(15)]
        public string MobileNo { get; set; }

        [Required]
        public string UserRole { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        public object AllowConfiguration { get; set; }
    }


    public class AddUserResponseViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public int RoleID { get; set; }
    }

    public class UserDetails
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
