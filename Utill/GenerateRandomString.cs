using System;
using System.Text;

namespace SpectralWave.Utill
{
    public class GenerateRandomStringManager
    {
        private static readonly char[] CharArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private static readonly Random Random = new Random();

        public static string GenerateRandomString(int length)
        {
            var stringBuilder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                stringBuilder.Append(CharArray[Random.Next(CharArray.Length)]);
            return stringBuilder.ToString();
        }
    }
}
