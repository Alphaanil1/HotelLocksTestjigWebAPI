using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace HotelLockVave.BusinessObjects.Models
{

    public class ResultViewModel<T>
    {
        public T Result { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; }
        public string UserMessage { get; set; }

        public ResultViewModel()
        {
        }
        public ResultViewModel(T result, string message, string userMessage)
        {
            this.Result = result;
            this.Message = message;
            this.UserMessage = userMessage;
        }
        public ResultViewModel(T result, HttpStatusCode responseCode, string message, string userMessage)
        {
            this.Result = result;
            this.ResponseCode = responseCode;
            this.Message = message;
            this.UserMessage = userMessage;
        }

    }

    public enum Message
    {
        Success,
        NotFound,
        AlreadyExists,
        Exception,
        Failure,
        GatewayConnectionFailed,
        DataBaseError,
        NoData,
        unauthorized,
        TimeOut
    }

    public enum MasterDoorModule
    {
        Hotel = -1,
        Building = 1,
        Floor = 2,
        Zone = 3,
        Room = 4,
        InnerRoom = 5
    }
    public class UserMessage
    {
        public static string RecordSavedMessage { get => "Record saved successfully"; }
        public static string RecordUpdatedMessage { get => "Record updated successfully"; }
        public static string RecordDeletedMessage { get => "Record deleted successfully"; }
        public static string RecordNotFoundMessage { get => "Record not found"; }
        public static string BranchdetailNotFoundMessage { get => "Branch details not found"; }
        public static string RecordAlreadyExistsMessage { get => "Record already exists..!!"; }
        public static string Success { get => "Query successfuly executed..!!"; }
        public static string Failure { get => "Something went wrong..!!"; }
        public static string InvalidData { get => "Data is not valid..!!"; }
        public static string UserNotExists { get => "UserName does not exists"; }
        public static string UserExists { get => "UserName already exists"; }
        public static string EMAIL_LeaveApplication_SUBJECT { get => " Leave Application"; }
        public static string ContentLocation { get => "https://nextgenapi.alpha-ict.in/HRMSContent/"; }
        public static string BaseUrl { get => "https://nextgenapi.alpha-ict.in/HRMSContent/"; }
        public static string LeaveAppliedSuccess { get => "Leave applied successfully but manager not assigned yet, hence mail not sent"; }
        public static string LeaveApprovedSuccess { get => "Leave approved successfully but employee not assigned yet, hence mail not sent"; }
        public static string EmployeeNotExists { get => "Employee does not exists"; }
        public static string EmployeeExists { get => "Employee already exists"; }
        public static string RecordNotDeletedMessage { get => "Record not deleted."; }
        public static string LeaveDeletedSuccess { get => "Leave deleted successfully but manager not assigned yet, hence mail not sent"; }
        public static string NewsEventSavedMessage { get => "News/Event saved successfully"; }
        public static string NewsEventUpdatedMessage { get => "News/Event updated successfully"; }
        public static string NewsEventDeletedMessage { get => "News/Event deleted successfully"; }
        public static string BranchDetailsRequireMessage { get => "Branch detail required"; }
        public static string UserCodeRequireMessage { get => "User code is required"; }
        public static string UserdetailNotFoundMessage { get => "User details not found"; }
        public static string ReloginUser { get => "Change Branch and Try again!"; }
        public static string UserdoesNotExistsMessage { get => "User does not exists"; }

        public static string EncoderExistMessage { get => "Encoder is already exists"; }

        public static string ConfigurationCardExistMessage { get => "Configuration Card is already exists"; }
        public static string LoginSuccessMessage { get => "Login successfull"; }
        public static string BlankUserNamePasswordMessage { get => "Blank UserName or Password not allowed"; }
        public static string UnauthorizedUserMessage { get => "Unauthorized user"; }
        public static string ConfirmPasswordRequireMessage { get => "Confirm Password required"; }
        public static string PasswordRequireMessage { get => "Password is required"; }
        public static string OldPasswordNotMatchMessage { get => "Old Password does not match"; }
        public static string PasswordConfirmPasswordNotMatchMessage { get => "Password and confirm password doesn't match"; }
        public static string PasswordFormatChangeMessage { get => "Required atleast one lowercase, one uppercase letter, one special character, one digit and minimum length should 8 characters "; }
        public static string PasswordChangeSuccessMessage { get => "Password changed successfully"; }
        public static string PasswordChangeFailureMessage { get => "Password not changed"; }
        public static string BranchdoesNotExistsMessage { get => "Branch does not exists"; }
        public static string ForgotPasswordEmailSuccessMessage { get => "Email sent to registered email id."; }
        public static string ForgotPasswordSetFailureMessage { get => "Error occured to set temporary password."; }
        public static string ForgotPasswordEmailFailureMessage { get => "Error occured while sending email"; }
        public static string UserAddSuccessMessage { get => "User created successfully. and Password has been sent on registered email Id."; }
        public static string UserEditSuccessMessage { get => "User updated successfully."; }
        public static string UserDeletedMessage { get => "User deleted successfully"; }
        public static string UserMailSendFailMessage { get => "User create successfull but Email not send."; }

        public static string CompanyAddSuccessMessage { get => "Company created successfully."; }
        public static string CompanyEditSuccessMessage { get => "Company updated successfully."; }
        public static string CompanyAddFailureMessage { get => "Error occured while adding company details. try again.!"; }
        public static string CompanyEditFailureMessage { get => "Error occured while updating company details. try again.!"; }
        public static string CompanyDeletedMessage { get => "Company deleted successfully"; }
        public static string CompanyDeleteFailureMessage { get => "Error occured while deleting company details"; }
        public static string CompanyAlreadyExistsMessage { get => "Company name already exists."; }
        public static string BranchExists { get => "BranchName already exists"; }
        public static string BranchAddSuccessMessage { get => "Branch created successfully."; }
        public static string BranchEditSuccessMessage { get => "Branch updated successfully."; }
        public static string BranchAddFailureMessage { get => "Error occured while adding branch details. try again.!"; }
        public static string BranchEditFailureMessage { get => "Error occured while updating branch details. try again.!"; }
        public static string BranchDeletedMessage { get => "Branch deleted successfully"; }
        public static string BranchDeleteFailureMessage { get => "Error occured while deleting branch details"; }

        public static string Building26LimitOver { get => "You can not create more than 26 building."; }
        public static string BuildingExists { get => "Building name already exists"; }
        public static string BuildingAddSuccessMessage { get => "Building created successfully."; }
        public static string BuildingEditSuccessMessage { get => "Building updated successfully."; }
        public static string BuildingAddFailureMessage { get => "Error occured while adding building details. try again.!"; }
        public static string BuildingEditFailureMessage { get => "Error occured while updating building details. try again.!"; }
        public static string BuildingDeletedMessage { get => "Building deleted successfully"; }
        public static string BuildingDeleteFailureMessage { get => "Error occured while deleting Building details"; }

        public static string Floor99LimitOver { get => "You can not create more than 99 floor."; }
        public static string FloorExists { get => "Floor name already exists"; }
        public static string FloorAddSuccessMessage { get => "Floor created successfully."; }
        public static string FloorEditSuccessMessage { get => "Floor updated successfully."; }
        public static string FloorAddFailureMessage { get => "Error occured while adding floor details. try again.!"; }
        public static string FloorEditFailureMessage { get => "Error occured while updating floor details. try again.!"; }
        public static string FloorDeletedMessage { get => "Floor deleted successfully"; }
        public static string FloorDeleteFailureMessage { get => "Error occured while deleting floor details"; }

        public static string provideValidUserID { get => "Please provide a valid user id"; }
        public static string provideValidFloorID { get => "Please provide a valid floor id"; }
        public static string provideValidBranchID { get => "Please provide a valid branch id"; }

        public static string provideValidEncoderID { get => "Please provide a valid encoder id"; }

        public static string provideValidConfigurationCardID { get => "Please provide a valid ConfigurationCard id"; }
        public static string provideValidBuildingID { get => "Please provide a valid building id"; }
        public static string provideValidZoneID { get => "Please provide a valid zone id"; }
        public static string provideValidDoorID { get => "Please provide a valid door id"; }

        public static string Zone9LimitOver { get => "You can not create more than 9 zone."; }
        public static string ZoneExists { get => "Zone name already exists"; }
        public static string ZoneAddSuccessMessage { get => "Zone created successfully."; }
        public static string ZoneEditSuccessMessage { get => "Zone updated successfully."; }
        public static string ZoneAddFailureMessage { get => "Error occured while adding zone details. try again.!"; }
        public static string ZoneEditFailureMessage { get => "Error occured while updating zone details. try again.!"; }
        public static string ZoneDeletedMessage { get => "Zone deleted successfully"; }
        public static string ZoneDeleteFailureMessage { get => "Error occured while deleting zone details"; }

        public static string Room99LimitOver { get => "You can not create more than 99 rooms."; }
        public static string RoomTypeExists { get => "Room type name already exists"; }
        public static string RoomTypeAddSuccessMessage { get => "Room type created successfully."; }
        public static string EncoderConfigAddSuccessMessage { get => "Encoder created successfully."; }
        public static string ConfigcarUpdateSuccessMessage { get => "Configuration Card Updated successfully."; }
        public static string ConfigcardSuccessMessage { get => "Configuration Card created successfully."; }

        public static string EncoderConfigEditSuccessMessage { get => "Encoder Updated successfully."; }
        public static string RoomTypeEditSuccessMessage { get => "Room type updated successfully."; }
        public static string RoomTypeAddFailureMessage { get => "Error occured while adding room type details. try again.!"; }
        public static string RoomTypeEditFailureMessage { get => "Error occured while updating room type details. try again.!"; }

        public static string EncoderConfigFailureMessage { get => "Error occured while updating Encoder details. try again.!"; }
        public static string ConfigcardUpdateFailureMessage { get => "Error occured while updating Configuration card details. try again.!"; }
        public static string ConfigcardFailureMessage { get => "Error occured while updating Configuration card details. try again.!"; }
        public static string EncoderConfigEditFailureMessage { get => "Error occured while updating Encoder details. try again.!"; }
        public static string RoomTypeDeletedMessage { get => "Room type deleted successfully"; }

        public static string EncoderDeletedMessage { get => "Encoder deleted successfully"; }
        public static string RoomTypeDeleteFailureMessage { get => "Error occured while deleting room type details"; }


        public static string RoomAddSuccessMessage { get => "Rooms created successfully."; }
        public static string RoomEditSuccessMessage { get => "Rooms updated successfully."; }
        public static string RoomAddFailureMessage { get => "Error occured while adding rooms details. try again.!"; }
        public static string RoomEditFailureMessage { get => "Error occured while updating rooms details. try again.!"; }
        public static string RoomDeletedMessage { get => "Rooms deleted successfully"; }
        public static string RoomDeleteFailureMessage { get => "Error occured while deleting rooms details"; }


        //public static string BranchExists { get => "BranchName already exists"; }
        public static string GuestInformationAddSuccessMessage { get => "Guest information added successfully."; }
        public static string GuestInformationEditSuccessMessage { get => "Guest information updated successfully."; }
        public static string GuestInformationAddFailureMessage { get => "Error occured while adding guest information. try again.!"; }
        public static string GuestInformationEditFailureMessage { get => "Error occured while updating guest information. try again.!"; }
        //public static string BranchDeletedMessage { get => "Branch deleted successfully"; }
        //public static string BranchDeleteFailureMessage { get => "Error occured while deleting branch details"; }

        public static string RoomNameExists { get => "Room name details already exists"; }
        public static string MSG_ADDROOMSTATUS { get => "Only when the room status in (Clean vacant, Non Clean vacant , Forbidden) room can delete."; }
        public static string LBL_DELETEMAINDOOR { get => "You can not delete door, it has inner door. So delete first all inner door."; }
        public static string LBL_DELETEINNERDOOR { get => "You can delete inner door in sequence only. Delete room no first."; }
        public static string MSG_DELETEMASTERELEMENT { get => "You can not delete, you need to delete the dependent records."; }

        public static string provideValidReservationID { get => "Please provide a valid reservation id"; }
        public static string provideValidArrivalDate { get => "Please provide a valid arrival date"; }
        public static string provideValidDepartureDate { get => "Please provide a valid departure date"; }
        public static string provideValidBookingDate { get => "Please provide a valid booking date"; }
        public static string LBL_DEPARTUREDATENOTLESSARRIVALDATE { get => "Departure date can not be less than arrival date."; }
        public static string LBL_ARRIVALDATENOTLESSBOOKINGDATE { get => "Arrival date can not be less than booking date."; }
        public static string LBL_BOOKINGDATELESSCURRENTDATE { get => "Booking date can not be less than current date."; }
        public static string MSG_PLEASEENTERCUSTOMERNAME { get => "Please enter customer name."; }
        public static string MSG_ENTERMOBILENO { get => "Please enter mobile number."; }
        public static string MSG_ENTER10DigitMOBILENO { get => "Mobile Number cannot be greater than 10 digits"; }
        public static string MSG_PLEASEENTERNOMEMBERS { get => "Please enter number of guest."; }
        public static string MSG_PLEASESELECTDOOR { get => "Please first select room."; }
        public static string LBL_ROOMRESERVED { get => "Room is already reserved, please select another room."; }

        public static string ReservationAddSuccessMessage { get => "Rooms reservation added successfully."; }
        public static string ReservationEditSuccessMessage { get => "Rooms reservation updated successfully."; }
        public static string ReservationAddFailureMessage { get => "Error occured while adding rooms reservation details. try again.!"; }
        public static string ReservationEditFailureMessage { get => "Error occured while updating rooms reservation details. try again.!"; }
        public static string ReservationDeletedMessage { get => "Rooms reservation deleted successfully"; }
        public static string ReservationDeleteFailureMessage { get => "Error occured while deleting rooms reservation details"; }

        //encoder related user messages
        public static string MSG_USBCOMMUNICATIONERROR_CARD { get => "USB communication error. Card writing failed, Please re-issue the card."; }
        public static string LBL_PARAMETERNOTCONFIGURED_CARD { get => "Parameter not configured. Please do not use this card,card is invalid."; }
        public static string LBL_SYSTEMPASSWORDMISMATCH_CARD { get => "System password mismatch. Please do not use this card,card is invalid."; }
        public static string LBL_WRONGDATA_CARD { get => "Wrong Data. Please do not use this card,card is invalid."; }
        public static string LBL_WRONGFRAMETYPA_CARD { get => "Wrong Frame Type. Please do not use this card,card is invalid."; }
        public static string LBL_CARDNOTPRESENT_CARD { get => "Card not present. Please do not use this card,card is invalid."; }
        public static string LBL_WRONGCRC_CARD { get => "Wrong CRC.Please do not use this card,card is invalid."; }
        public static string LBL_WRONGCOMMANDCODE_CARD { get => "Wrong command code. Please do not use this card,card is invalid."; }
        public static string LBL_NOSYSTEMPASSWORDSET_CARD { get => "No system password set. Please do not use this card,card is invalid."; }
        public static string MSG_PORTCONNECTIONFAILURE_CARD { get => "Device connection failure. Please do not use this card,card is invalid."; }
        public static string MSG_CARDWRITEFAIL_CARD { get => "Card writing failed.Please do not use this card,card is invalid."; }
        public static string MSG_DUPLICATECARDNO { get => "Card No. is duplicate, Please Re-issue card."; }
        public static string MSG_ACCESSPORTDENIED { get => "Access to the port is denied."; }
        public static string MSG_CARDCOMMONERRORMESSAGE_CARD { get => "Please do not use this card,card is invalid."; }
        public static string MSG_CARDREADFAILED { get => "Card read failed."; }
  
        public static string MSG_CARDWRITEFAILED { get => "Card write failed."; }
        public static string LBL_STAFFCARD { get => "Staff Card"; }

        public static string LBL_CONFIGURATIONCARD { get => "Configuration Card"; }
        public static string LBL_GUEST_CARD { get => "Guest Card"; }
        public static string LBL_PASSAGECARD { get => "Passage card"; }
        public static string LBL_EMERGENCYCARD { get => "Emergency Card"; }
        public static string LBL_EMERGENCYCARDHOLDER { get => "Emergency Card Holder"; }
        public static string LBL_EMERGENCYCARDSETTING { get => "Emergency Card Setting"; }
        public static string LBL_VISTORCARD { get => "Visitor Card"; }
        public static string LBL_LIFTENABLECARD { get => "Lift enable card"; }
        public static string LBL_LIFTENABLECARDSETTINGS { get => "Lift enable card settings"; }
        public static string LBL_SYSTEM_ID_CARD { get => "System ID Card"; }
        public static string LBL_CARDTYPE { get => "Card Type"; }
        public static string LBL_CARDNO { get => "Card No."; }
        public static string LBL_CARDNOTPRESENT { get => "Card Not Present"; }
        public static string LBL_CARDNO_FIX { get => "Card No"; }
        public static string LBL_STARTTIME { get => "Start Time"; }
        public static string LBL_STARTTIME_FIX { get => "Start Time"; }
        public static string LBL_TERMINATINGTIME { get => "Terminating Time"; }
        public static string LBL_TERMINATINGTIME_FIX { get => "Terminating Time"; }
        public static string LBL_VISITORCODE { get => "Visitor Code"; }
        public static string LBL_VISITORNAME { get => "Visitor Name"; }
        public static string LBL_DOORNAME { get => "Door Name"; }
        public static string LBL_DOORNAME_FIX { get => "Door Name"; }
        public static string LBL_ARRIVALDATE { get => "Arrival Date"; }
        public static string LBL_DEPARTUREDATE { get => "Departure Date"; }
        public static string MSG_CARDNOTEXIST { get => "Card not exist."; }
        public static string LBL_MEMBERCODE { get => "Member Code"; }
        public static string LBL_MEMBERNAME { get => "Member Name"; }
        public static string LBL_WEEKDAYSACCESS { get => "Weekdays access"; }
        public static string LBL_GUESTID { get => "Guest ID"; }
        public static string LBL_GUESTNAME { get => "Guest Name"; }
        public static string LBL_DATEFROM { get => "Date From"; }
        public static string LBL_DATETO { get => "Date To"; }
        public static string LBL_DATEOFBIRTH { get => "Date of Birth"; }
        public static string LBL_PUBLICDOOR { get => "Public Door"; }
        public static string LBL_LIFTS { get => "Lifts"; }
        public static string LBL_ISSUERNAME { get => "Issuer Name"; }
        public static string ShiftAddSuccessMessage { get => "Shift created successfully."; }
        public static string ShiftEditSuccessMessage { get => "Shift updated successfully."; }
        public static string ShiftAddFailureMessage { get => "Error occured while adding Shift details. try again.!"; }
        public static string ShiftEditFailureMessage { get => "Error occured while updating Shift details. try again.!"; }
        public static string ShiftDeletedMessage { get => "Shift deleted successfully"; }
        public static string ShiftDeleteFailureMessage { get => "Error occured while deleting Shift details"; }


        public static string MobileUserAddSuccessMessage { get => "Mobile User created successfully."; }
        public static string MobileUserEditSuccessMessage { get => "Mobile User updated successfully."; }
        public static string MobileUserAddFailureMessage { get => "Error occured while adding mobile user details. try again.!"; }
        public static string MobileUserEditFailureMessage { get => "Error occured while updating mobile user details. try again.!"; }
        public static string MobileUserDeletedMessage { get => "Mobile user deleted successfully"; }
        public static string MobileUserDeleteFailureMessage { get => "Error occured while deleting mobile user details"; }

    




        public static string LBL_MONDAY { get => "Monday"; }
        public static string LBL_TUESDAY { get => "Tuesday"; }
        public static string LBL_WEDNESDAY { get => "Wednesday"; }
        public static string LBL_THURSDAY { get => "Thursday"; }
        public static string LBL_FRIDAY { get => "Friday"; }
        public static string LBL_SATURDAY { get => "Saturday"; }
        public static string LBL_SUNDAY { get => "Sunday"; }


        public static string MSG_SELECTLESSTHAN100DOORS { get => "You can not configure more than 100 door at time."; }
        public static string MSG_CANNOTSELECTMORETHAN50CARD { get => "You can not select more than 50 staff card."; }

        public static string MSG_USBCOMMUNICATIONERROR { get => "USB communication error."; }
        public static string MSG_PORTCONNECTIONFAILURE { get => "Device connection failure, Please check.."; }
        public static string MSG_MEMORYFULL { get => "Memory is Full."; }
        public static string MSG_THEPORTISCLOSED { get => "The port is closed. Please try again."; }
        public static string LBL_PARAMETERNOTCONFIGURED { get => "The port is closed. Please try again."; }
        public static string LBL_SYSTEMPASSWORDMISMATCH { get => "System Password Mismatch"; }
        public static string LBL_WRONGDATA { get => "Wrong Data"; }
        public static string LBL_WRONGFRAMETYPA { get => "Wrong Frame Type"; }
        public static string LBL_WRONGCRC { get => "Wrong CRC"; }
        public static string LBL_NOSYSTEMPASSWORDSET { get => "No system password set"; }
        public static string MSG_DATASENDSUCCESSFULLY { get => "Data send successfully"; }
        public static string MSG_DATANOTSENDSUCCESSFULLY { get => "Data not send"; }
        public static string LBL_WRONGCOMMANDCODE { get => "Wrong command code"; }
        public static string LBL_UPDATEROOMSTATUS { get => "Only when the room status is (Clean vacant, Non Clean vacant , Forbidden) can update."; }
        public static string RoomStatusUpdateMessage { get => "Rooms status updated successfully"; }
        public static string RoomStatusUpdateFailureMessage { get => "Error occured while updating rooms status details"; }

        public static string SetConfigurationMessage { get => "Configuration set successfully."; }
        public static string SetConfigurationFailureMessage { get => "Configuration set failed."; }

        public static string SetLockConfigurationSuccessMessage { get => "Lock Configuration saved Successfully."; }

        public static string SetLockConfigurationFailureMessage { get => "Lock Configuration data failed"; }

        public static string MSG_CANNOTISSUETWOCARD { get => "Member has one active card, you can not issue another card."; }
        //PMS
        public static string RepquestProcessingFailureMessage { get => "Error occured while processing request"; }

        //Lucid keys
        public static string GuestTransferSuccessMessage { get => "Guest room transfered successfully."; }      
        public static string GuestTransferFailureMessage { get => "Error occured while transfering guest room. try again.!"; }
        public static string RoomTransferSuccessMessage { get => "Room transfered successfully."; }
        public static string RoomTransferFailureMessage { get => "Error occured while transfering room. try again.!"; }
        public static string ExtensionOfStaySuccessMessage { get => "Extension of guest stay added successfully."; }
        public static string ExtensionOfStayFailureMessage { get => "Error occured while adding extension of guest stay. try again.!"; }
        public static string ExtensionOfStayAllSuccessMessage { get => "Extension of room stay added successfully."; }
        public static string ExtensionOfStayAllFailureMessage { get => "Error occured while adding stay extension of room. try again.!"; }
        public static string provideValidUserRoleID { get => "Please provide a valid user role id"; }
        public static string UserLogsAddSuccessMessage { get => "User log added successfully."; }
        public static string UserLogsAddFailureMessage { get => "Error occured while adding user log. try again.!"; }
        public static string FirmwareAddSuccessMessage { get => "Firmware details added successfully."; }
        public static string FirmwareUpdateSuccessMessage { get => "Firmware details updated successfully."; }
        public static string FirmwareAddFailureMessage { get => "Error occured while adding firmware details. try again.!"; }
        public static string FirmwareUpdateFailureMessage { get => "Error occured while updating firmware details. try again.!"; }
        public static string BookingTypedetailNotFoundMessage { get => "Booking type details not found"; }
        public static string BookingTypeExists { get => "Booking type already exists"; }
        public static string BookingTypeDeletedMessage { get => "Booking type deleted successfully"; }
        public static string AuditTrailsAddSuccessMessage { get => "Audit trails added successfully."; }
        public static string AuditTrailsAddFailureMessage { get => "Error occured while adding audit trails. try again.!"; }

        public static string RoomConfigStatusUpdateSuccessMessage { get => "Room configuration status updated successfully."; }
        public static string RoomConfigStatusFailureMessage { get => "Error occured while updating room configuration status. try again.!"; }
    }
}
