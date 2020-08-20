/*
 * Brian Chaves
 * April 14,2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BC_Functions
{
    public static class Password
    {
        /// <summary>
        /// Creates the hash
        /// </summary>
        /// <param name="unHashed">unhashed string</param>
        /// <returns></returns>
        public static string CreateHash(string unHashed)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(unHashed);
            data = x.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }

        /// <summary>
        /// Checks the hash of the string
        /// </summary>
        /// <param name="HashData">Data</param>
        /// <param name="HashUser">Value being inputed</param>
        /// <returns></returns>
        public static bool MatchHash(string HashData, string HashUser)
        {
            HashUser = CreateHash(HashUser);
            if (HashUser == HashData)
                return true;
            else
                return false;

        }
		
        /// <summary>
        /// Creates salt with random characters
        /// </summary>
        /// <param name="length">Length of characters</param>
        /// <returns>salt</returns>
        public static string GenerateSalt(int length)
        {
            string chars =
				"ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789" +
                "`~!@#$%^&*()_+-=[]\\;',./{}|:\"<>? " ;//+
                //"¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿÷ƖƗʷˣ˟˖˗ʰʱˀˁ؞" +
                //"ᴀᴁᴂᴃᴥᵜᵫᵹᵺ‖‴‼†‡‰℗⅍⅓⅔⅛⅜⅝⅞ↄ←↑→↓⌂∞☺☻☼♀♂♠♣♥♦♪♫♯ᴓᴕ" +
                //"жѺѻѸѹ҈҉ᴤᴈ„…•‴₡₧₨₩₪₮₱₳₲₯⅔⅍№₴℅░▒▓"+
                //"▬▲►▼◄◊○◌●◘◙◦";
            char[] stringChars = new char[length];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);
            return finalString;
        }

        /// <summary>
        /// Creates salt with random characters
        /// </summary>
        /// <param name="minLength">Minimum length</param>
        /// <param name="maxLength">Maximum length</param>
        /// <returns>salt</returns>
        public static string GenerateSalt(int minLength, int maxLength)
        {
            Random random=new Random();
            int length = random.Next(minLength, maxLength + 1);
            return GenerateSalt(length);
        }
    }
}