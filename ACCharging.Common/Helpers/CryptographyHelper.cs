using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACCharging.Common
{
    public static class CryptographyHelper
    {
        public static string Encrypt(string input)
        {

            byte[] inputBytes = Encoding.Default.GetBytes(input);

            SHA1 sha = new SHA1CryptoServiceProvider();

            byte[] result = sha.ComputeHash(inputBytes);

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                sBuilder.Append(result[i].ToString("x2"));
            }

            return sBuilder.ToString();

        }

        public static bool Verify(string input, string hash)
        {
            string hashOfInput = Encrypt(input);


            return hashOfInput == hash;

        }
    }
}
