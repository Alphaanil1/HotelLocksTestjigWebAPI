using HotelLockVave.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.DAL.Repositories.InterfaceRepositories
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
        bool SendUserPasswordEmail(UserAccessRights userData, string mailsubject);
        bool SendForgotPasswordEmail(UserLoginResponseViewModel userData, string mailsubject);
        bool Email(EmailSendData emailData);
        //bool SendGuestPasswordEmail(GuestLoginInformationViewModel objGuestData, string mailsubject);
        // bool SendOTPToStaffEmail(string StaffName, string StaffEmailId, string OTP, string mailsubject);        
        //bool SendOTPToStaffEmail(StaffLoginResponseViewtModel objstaff, string mailsubject);
        //bool SendOTPToGuestEmail(GuestLoginResponseViewModel objGuest, string mailsubject);
    }

}
