using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMB_Delivery_Management.Helpers
{
    public static class MD5Helper
    {
        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Convert the input string to a byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the MD5 hash
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" means lowercase hexadecimal
                }

                return sb.ToString();
            }
        }
    }
}
