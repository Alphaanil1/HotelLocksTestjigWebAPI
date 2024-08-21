using HotelLockVave.BusinessObjects.Models;
using HotelLockVave.BusinessObjects.Models.Utility;
using HotelLockVave.DAL.Repositories;
using HotelLockVave.DAL.Repositories.InterfaceRepositories;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelLockVave.BLL
{
    public interface ITokenBlacklistService
    {
        void BlacklistToken(string token);
        bool IsTokenBlacklisted(string token);
    }

    public class TokenBlacklistService: ITokenBlacklistService
    {
        public TokenBlacklistService()
        {
           
        }
        private readonly HashSet<string> _blacklist = new HashSet<string>();

        public void BlacklistToken(string token)
        {
            _blacklist.Add(token);
        }

        public bool IsTokenBlacklisted(string token)
        {
            return _blacklist.Contains(token);
        }
    }
};