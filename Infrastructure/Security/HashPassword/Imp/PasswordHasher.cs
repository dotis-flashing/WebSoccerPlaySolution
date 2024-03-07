using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Infrastructure.Security.HashPassword.Imp
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int key = 12;

        public string HashPassword(string password)
        {
            var salt = BCryptNet.GenerateSalt(key);
            var hash = BCryptNet.HashPassword(password, salt);
            return hash;
        }

        public bool VerifyPasswordB(string password, string hashedPassword)
        {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}
