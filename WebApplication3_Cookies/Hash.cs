using System.Security.Cryptography;
using System.Text;

namespace WebApplication3_Cookies
{
    public class Hash
    {
        internal static string HashPass(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            MD5 mD5 = MD5.Create();
            byte[] hash = mD5.ComputeHash(bytes);
            return Encoding.UTF8.GetString(hash);
        }
    }
}
