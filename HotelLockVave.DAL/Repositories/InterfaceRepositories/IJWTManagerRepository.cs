using HotelLockVave.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.DAL.Repositories.InterfaceRepositories
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(UserLoginResponseViewModel users);
        Tokens AuthenticateGuest(MobileLoginResponseViewModel users);
        Tokens AuthenticateStaffLogin(StaffLoginConfirmResponseViewtModel users);
        Tokens AuthenticateGuestLogin(GuestLoginResponseViewModel guest);
    }
}
