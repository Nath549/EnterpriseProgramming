using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EnterpriseApp.Utilities
{
    public class Hashing
    {
        public static string HashString(string data)
        {
            byte[] dataAsBytes = Encoding.UTF32.GetBytes(data);
            SHA512 myHashingAlg = SHA512.Create();

            byte[] digestAsBytes = myHashingAlg.ComputeHash(dataAsBytes);

            return Convert.ToBase64String(digestAsBytes);
        }
    }
}