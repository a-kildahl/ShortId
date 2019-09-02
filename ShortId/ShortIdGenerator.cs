using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ShortId
{
    public class ShortIdGenerator
    {
        public string AllowedCharacters { get; private set; }
        public int Length { get; private set; }

        public ShortIdGenerator()
            : this ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._~", 10)
        {

        }

        public ShortIdGenerator(string allowedCharacters, int length)
        {
            AllowedCharacters = allowedCharacters;
            Length = length;
        }

        public string Generate()
        {
            Random rng = new Random(GetSeed());
            char[] result = new char[Length];
            
            for (int i = 0; i < Length; i++)
            {
                result[i] = AllowedCharacters[rng.Next(AllowedCharacters.Length)];
            }

            return new string(result);
        }

        private int GetSeed()
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];
            crypto.GetBytes(buffer);
            return BitConverter.ToInt32(buffer, 0);
        }

    }
}
