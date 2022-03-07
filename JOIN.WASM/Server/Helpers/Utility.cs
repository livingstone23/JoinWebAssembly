using System.Security.Cryptography;
using System.Text;

namespace JOIN.WASM.Server.Helpers
{


    /// <summary>
    /// Clase utilitaria para desencriptar el navegador
    /// </summary>
    public class Utility
    {
        public static string Encrypt(string password)
        {
            var provider = MD5.Create();
            string salt = "S0m3R@nd0mSalt";
            byte[] bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(salt + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }

}
