using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLockWebAPI.APIAuthentication
{
    public static class TokenData
    {
        public static List<string> BlacklistdTokens { get; set; }
        //public static string CurrentToken { get; set; }
        static TokenData()
        {
            BlacklistdTokens = new List<string>();
        }
    }
}
