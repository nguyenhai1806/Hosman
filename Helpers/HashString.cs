using System.Security.Cryptography;
using System.Text;

namespace hosman_api.Helpers
{
    public static class HashString
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
        public static string CreateRefeshToken(){
            return CreateMD5(Guid.NewGuid().ToString());
        }
        public static string HashPassword(string password)
        {
            string newPass = password;
            return CreateMD5(newPass);
        }
    }
}
