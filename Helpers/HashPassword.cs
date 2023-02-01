using System.Security.Cryptography;
using System.Text;

namespace hosman_api.Helpers
{
    public static class HashPassword
    {
        private static string CreateMD5(string input)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
            return Convert.ToHexString(hash);
        }
        public static string Hash(string password)
        {
            string newPass = password;
            return CreateMD5(newPass);
        }
    }
}
