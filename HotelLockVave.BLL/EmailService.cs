﻿using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelLockVave.BusinessObjects.Models.Utility;



namespace HotelLockVave.BLL
{
    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = emailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.TextBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }

        public bool SendUserPasswordEmail(UserAccessRights userData, string mailsubject)
        {
            SmtpClient emailClient = new SmtpClient();
            _emailSettings.EmailId = "hotel.admin@alpha-ict.in";
            try
            {
                if (userData == null)
                {
                    throw new ArgumentNullException(nameof(userData));
                }
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(userData.UserName, userData.EmailID);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = mailsubject;  // // //  "Forgot password";

                string FilePath = "";

                if (mailsubject == "HotelLock APP registration")
                { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\RegistrationEmail.html"; }
                else
                { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\ForgotPasswordEmail.html"; }

                string EmailTemplateText = File.ReadAllText(FilePath);

                EmailTemplateText = string.Format(EmailTemplateText, userData.UserName, DateTime.Now.Date.ToShortDateString());

                #region Replace the value of templete by dynamic value
                // Get a substring between two strings
                string usersName = userData.UserName;
                //int EndStringPosition = usersName.IndexOf("@");
                //string stringUserNM = usersName.Substring(0, EndStringPosition);

                EmailTemplateText = EmailTemplateText.Replace("@url", "#");
                EmailTemplateText = EmailTemplateText.Replace("@UserName", usersName);
                EmailTemplateText = EmailTemplateText.Replace("@TempPassword", userData.Password);

                #endregion Replace the value of templete by dynamic value

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();


                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                ErrorLogs.ErrorLogAndNotification("exception occurred message :" + ex.Message);
                emailClient.Dispose();

                return false;
            }
        }


        //public bool SendGuestPasswordEmail(GuestLoginInformationViewModel guestdata, string mailsubject)
        //{
        //    SmtpClient emailClient = new SmtpClient();
        //    _emailSettings.EmailId = "hotel.admin@alpha-ict.in";
        //    try
        //    {
        //        if (guestdata == null)
        //        {
        //            throw new ArgumentNullException(nameof(guestdata));
        //        }
        //        MimeMessage emailMessage = new MimeMessage();

        //        MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
        //        emailMessage.From.Add(emailFrom);

        //        MailboxAddress emailTo = new MailboxAddress(guestdata.GuestName,guestdata.EmailID);
        //        emailMessage.To.Add(emailTo);

        //        emailMessage.Subject = mailsubject; 

        //        string FilePath = "";

        //        if (mailsubject == "HotelLock App guest registration")
        //        { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\RegistrationEmail.html"; }
        //        //else
        //        //{ FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\ForgotPasswordEmail.html"; }

        //        string EmailTemplateText = File.ReadAllText(FilePath);

        //        EmailTemplateText = string.Format(EmailTemplateText, guestdata.GuestName, DateTime.Now.Date.ToShortDateString());

        //        #region Replace the value of templete by dynamic value
        //        // Get a substring between two strings
        //        string guestName = guestdata.GuestName;
        //        //int EndStringPosition = usersName.IndexOf("@");
        //        //string stringUserNM = usersName.Substring(0, EndStringPosition);

        //        EmailTemplateText = EmailTemplateText.Replace("@url", "#");
        //        EmailTemplateText = EmailTemplateText.Replace("@UserName", guestName);
        //        EmailTemplateText = EmailTemplateText.Replace("@TempPassword", guestdata.OTP);

        //        #endregion Replace the value of templete by dynamic value

        //        BodyBuilder emailBodyBuilder = new BodyBuilder();
        //        emailBodyBuilder.HtmlBody = EmailTemplateText;
        //        emailMessage.Body = emailBodyBuilder.ToMessageBody();


        //        emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
        //        emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
        //        emailClient.Send(emailMessage);
        //        emailClient.Disconnect(true);
        //        emailClient.Dispose();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log Exception Details
        //        ErrorLogs.ErrorLogAndNotification("exception occurred message :" + ex.Message);
        //        emailClient.Dispose();

        //        return false;
        //    }
        //}

        //// public bool SendOTPToStaffEmail(string StaffName, string StaffEmailId, string OTP, string mailsubject)
        //public bool SendOTPToStaffEmail(StaffLoginResponseViewtModel objstaff, string mailsubject)
        //{
        //    SmtpClient emailClient = new SmtpClient();
        //    // _emailSettings.EmailId = "hotel.admin@alpha-ict.in";
        //    _emailSettings.EmailId = "bhagyashri.patil@alpha-ict.in";
        //    try
        //    {
        //        //if (objStaffLoginData == null)
        //        //{
        //        //    throw new ArgumentNullException(nameof(objStaffLoginData));
        //        //}
        //        MimeMessage emailMessage = new MimeMessage();

        //        MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
        //       // MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, "anil.patil@alpha-ict.in");
        //        emailMessage.From.Add(emailFrom);

        //        MailboxAddress emailTo = new MailboxAddress(objstaff.UserName, objstaff.EmailID);
        //        emailMessage.To.Add(emailTo);

        //        emailMessage.Subject = mailsubject;

        //        string FilePath = "";

        //        if (mailsubject == "HotelLock Staff Login OTP")
        //        { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\RegistrationEmail.html"; }
        //        //else
        //        //{ FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\ForgotPasswordEmail.html"; }

        //        string EmailTemplateText = File.ReadAllText(FilePath);

        //        EmailTemplateText = string.Format(EmailTemplateText, objstaff.UserName, DateTime.Now.Date.ToShortDateString());

        //        #region Replace the value of templete by dynamic value
        //        // Get a substring between two strings
        //        string guestName = objstaff.UserName;
        //        //int EndStringPosition = usersName.IndexOf("@");
        //        //string stringUserNM = usersName.Substring(0, EndStringPosition);

        //        EmailTemplateText = EmailTemplateText.Replace("@url", "#");
        //        EmailTemplateText = EmailTemplateText.Replace("@UserName", guestName);
        //        EmailTemplateText = EmailTemplateText.Replace("@TempPassword", objstaff.OTP);

        //        #endregion Replace the value of templete by dynamic value

        //        BodyBuilder emailBodyBuilder = new BodyBuilder();
        //        emailBodyBuilder.HtmlBody = EmailTemplateText;
        //        emailMessage.Body = emailBodyBuilder.ToMessageBody();


        //        emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
        //        emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
        //        emailClient.Send(emailMessage);
        //        emailClient.Disconnect(true);
        //        emailClient.Dispose();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log Exception Details
        //        ErrorLogs.ErrorLogAndNotification("exception occurred message :" + ex.Message);
        //        emailClient.Dispose();

        //        return false;
        //    }
        //}

        //public bool SendOTPToGuestEmail(GuestLoginResponseViewModel objGuest, string mailsubject)
        //{
        //    SmtpClient emailClient = new SmtpClient();
        //    // _emailSettings.EmailId = "hotel.admin@alpha-ict.in";
        //    _emailSettings.EmailId = "bhagyashri.patil@alpha-ict.in";
        //    try
        //    {
        //        //if (objStaffLoginData == null)
        //        //{
        //        //    throw new ArgumentNullException(nameof(objStaffLoginData));
        //        //}
        //        MimeMessage emailMessage = new MimeMessage();

        //        MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
        //        // MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, "anil.patil@alpha-ict.in");
        //        emailMessage.From.Add(emailFrom);

        //        MailboxAddress emailTo = new MailboxAddress(objGuest.GuestName, objGuest.EmailID);
        //        emailMessage.To.Add(emailTo);

        //        emailMessage.Subject = mailsubject;

        //        string FilePath = "";

        //        if (mailsubject == "HotelLock Staff Login OTP")
        //        { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\RegistrationEmail.html"; }
        //        //else
        //        //{ FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\ForgotPasswordEmail.html"; }

        //        string EmailTemplateText = File.ReadAllText(FilePath);

        //        EmailTemplateText = string.Format(EmailTemplateText, objGuest.GuestName, DateTime.Now.Date.ToShortDateString());

        //        #region Replace the value of templete by dynamic value
        //        // Get a substring between two strings
        //        string guestName = objGuest.GuestName;
        //        //int EndStringPosition = usersName.IndexOf("@");
        //        //string stringUserNM = usersName.Substring(0, EndStringPosition);

        //        EmailTemplateText = EmailTemplateText.Replace("@url", "#");
        //        EmailTemplateText = EmailTemplateText.Replace("@UserName", guestName);
        //        EmailTemplateText = EmailTemplateText.Replace("@TempPassword", objGuest.OTP);

        //        #endregion Replace the value of templete by dynamic value

        //        BodyBuilder emailBodyBuilder = new BodyBuilder();
        //        emailBodyBuilder.HtmlBody = EmailTemplateText;
        //        emailMessage.Body = emailBodyBuilder.ToMessageBody();


        //        emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
        //        emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
        //        emailClient.Send(emailMessage);
        //        emailClient.Disconnect(true);
        //        emailClient.Dispose();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log Exception Details
        //        ErrorLogs.ErrorLogAndNotification("exception occurred message :" + ex.Message);
        //        emailClient.Dispose();

        //        return false;
        //    }
        //}

        public bool SendForgotPasswordEmail(UserLoginResponseViewModel userData, string mailsubject)
        {
            SmtpClient emailClient = new SmtpClient();

            try
            {
                if (userData == null)
                {
                    throw new ArgumentNullException(nameof(userData));
                }
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                MailboxAddress emailTo = new MailboxAddress(userData.UserName, userData.EmailID);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = mailsubject;  // // //  "Forgot password";

                string FilePath = "";

                if (mailsubject == "HotelLock APP registration")
                { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\RegistrationEmail.html"; }
                else
                { FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplates\\ForgotPasswordEmail.html"; }

                string EmailTemplateText = File.ReadAllText(FilePath);

                EmailTemplateText = string.Format(EmailTemplateText, userData.UserName, DateTime.Now.Date.ToShortDateString());

                #region Replace the value of templete by dynamic value
                // Get a substring between two strings
                string usersName = userData.UserName;
                //int EndStringPosition = usersName.IndexOf("@");
                //string stringUserNM = usersName.Substring(0, EndStringPosition);

                EmailTemplateText = EmailTemplateText.Replace("@url", "#");
                EmailTemplateText = EmailTemplateText.Replace("@UserName", usersName);
                EmailTemplateText = EmailTemplateText.Replace("@TempPassword", userData.Password);

                #endregion Replace the value of templete by dynamic value

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();


                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                ErrorLogs.ErrorLogAndNotification("exception occurred message :" + ex.Message);
                emailClient.Dispose();

                return false;
            }
        }

        public Boolean Email(EmailSendData emailData)
        {
            SmtpClient emailClient = new SmtpClient();
            try
            {
                if (emailData == null)
                {
                    throw new ArgumentNullException(nameof(emailData));
                }
                MimeMessage emailMessage = new MimeMessage();

                MailboxAddress emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
                emailMessage.From.Add(emailFrom);

                foreach (var mailto in emailData.EmailTo)
                { emailMessage.To.Add(new MailboxAddress(mailto.UserName, mailto.MailAddress)); }

                foreach (var mailCc in emailData.EmailCc)
                { emailMessage.Cc.Add(new MailboxAddress(mailCc.UserName, mailCc.MailAddress)); }

                //foreach (var mailBcc in emailData.EmailBcc)
                //{ emailMessage.Cc.Add(new MailboxAddress(mailBcc.UserName, mailBcc.MailAddress)); }

                emailMessage.Subject = emailData.EmailSubject;

                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                emailClient.Connect(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
                emailClient.Authenticate(_emailSettings.EmailId, _emailSettings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                ErrorLogs.ErrorLogAndNotification("exception occurred message :" + ex.Message);
                emailClient.Dispose();

                return false;
            }
            finally
            {
                emailClient.Dispose();
            }

        }
    }
}
