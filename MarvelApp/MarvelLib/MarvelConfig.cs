using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarvelLib
{
    public class MarvelConfig
    {
        public static string PublicKey { get; } = "d43e9b375ae3a7e558969998737075cb";
        private static string PrivateKey { get; } = "98b8a2f33afe42e1cdb13005e9d0b50608f47b72";
        public static string BaseUrl { get; } = "http://gateway.marvel.com/v1/public/";
        public static long TimeStamp => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public static string MD5Hash()
        {
            string stringToHash = $"{TimeStamp}{PrivateKey}{PublicKey}";
            var cryptor = MD5.Create();
            byte[] bytes = cryptor.ComputeHash(Encoding.Default.GetBytes(stringToHash));
            return BitConverter.ToString(bytes).ToLower().Replace("-",string.Empty);
        }
    }
}
