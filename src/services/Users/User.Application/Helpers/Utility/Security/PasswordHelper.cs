using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Helpers.Utility.Security
{
    public static class PasswordHelper
    {
        public static string EncodePasswordSha256(string randomString)
        {
            var crypt = new SHA256Managed();
            var hash = string.Empty;
            var crypto = crypt.ComputeHash(Encoding.Unicode.GetBytes(randomString));
            foreach (var theByte in crypto)
                hash += theByte.ToString("x2");

            return hash;
        }
    }
}
