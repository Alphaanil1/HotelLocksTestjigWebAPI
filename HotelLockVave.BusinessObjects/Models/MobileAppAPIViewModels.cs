using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLockVave.BusinessObjects.Models
{
    public class MobileLoginRequestViewModel
    {
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public int BranchID { get; set; }
    }
    public class GuestLoginResponseViewModel
    {
        public string GuestID { get; set; }
        public string GuestName { get; set; }
        public string Sex { get; set; }
        public bool Married { get; set; }
        public DateTime BirthDate { get; set; }
        public string CountryCode { get; set; }
        public string MobileNo { get; set; }
        public string OTP { get; set; }
        public string EmailID { get; set; }
        public string Token { get; set; }
        public string AccessKey { get; set; }
        public int ID { get; set; }
        public int BranchId { get; set; }
    }
    public class StaffLoginConfirmResponseViewtModel
    {
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string OTP { get; set; }
        public bool IsAdmin { get; set; }
        public long BranchID { get; set; }
        // public string BranchName { get; set; }
        public bool Inactive { get; set; }
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; }
        // public bool IsTempPassword { get; set; }
        public string Token { get; set; }
        public string EmailID { get; set; }
        // public string AccessKey { get; set; }
        // public string UserPicURL { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string StaffAccessKeys { get; set; }
        public string EmergencyAccessKeys { get; set; }

        // public int SelectLanguage { get; set; }
    }
    public class MobileLoginResponseViewModel
    {
        public string GuestID { get; set; }
        public string GuestName { get; set; }
        public string Sex { get; set; }
        public bool Married { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string Token { get; set; }
        public string AccessKey { get; set; }
    }
    public class GuestAndRoomInfoViewModel
    {
        public string doorID { get; set; }
        public string DoorNo { get; set; }
        public string DoorName { get; set; }
        public string IssueCardID { get; set; }
        public string CardNo { get; set; }
        public string GuestID { get; set; }
        public string GuestName { get; set; }
        public string Sex { get; set; }
        public bool Married { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string AccessKey { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string RoomType { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchMobileNo { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelMobileNo { get; set; }
    }


    public class StaffAssignedRoomsAndGuestInfoViewModel
    {
        public string DoorID { get; set; }
        public string DoorNo { get; set; }
        public string DoorName { get; set; }
        // public string IssueCardID { get; set; }
        // public string CardNo { get; set; }

       // public List<RoomDetails> AssignedRooms { get; set; }
        public List<GuestAndRoomInfoViewModel> GuestInfo { get; set; }
        //public List<RoomsInformationViewModel> InnerRooms { get; set; }

        //public DateTime ArrivalDate { get; set; }
        //public DateTime DepartureDate { get; set; }
        //public bool IsInnerRoom { set; get; }
        public string RoomType { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string BranchMobileNo { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string HotelMobileNo { get; set; }
    }

    
}
