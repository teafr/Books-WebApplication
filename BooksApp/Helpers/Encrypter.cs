using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace booksAPI.Helpers
{
    public static class Encrypter
    {
        public static string Encrypt(string input)
        {
            byte[] data = Encoding.ASCII.GetBytes(input);
            data = SHA256.HashData(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}
