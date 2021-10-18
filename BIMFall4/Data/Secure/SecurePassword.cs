using BIMFall4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BIMFall4.Data.Secure
{
    public class SecurePassword
    {
        public string SaltGenerator(int size)
        {
            byte[] saltBytes = new byte[size];

            using(var x = new RNGCryptoServiceProvider())
            {
                x.GetNonZeroBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public string ComputePassword(User user)
        {
            var pw = $"{user.Salt}{user.Password}";

            using (SHA256 x = SHA256.Create())
            {
                byte[] bytes = x.ComputeHash(Encoding.UTF8.GetBytes(pw));
                
                StringBuilder z = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++)
                {
                    z.Append(bytes[i].ToString("x2"));
                }
                return z.ToString();
            }
        }

        public void SetPassword(User user)
        {
            user.Salt = SaltGenerator(10);
            user.Password = ComputePassword(user);
        }
    }
}