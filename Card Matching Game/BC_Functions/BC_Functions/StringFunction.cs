using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public static class StringFunction
    {
        /// <summary>
        /// Trim will remove any extra spaces not only before or after the word
        /// but also any double spaces between words
        /// </summary>
        /// <param name="word">string to trim</param>
        /// <returns></returns>
        public static string TrueTrim(string word)
        {
            word = word.Trim();
            bool doubleSpaceFound = false;
            do
            {
                word = word.Replace("  ", " ");
                doubleSpaceFound = (word.IndexOf("  ") != -1);
            } while (doubleSpaceFound);
            return word;
        }

        /// <summary>
        /// Trim will remove any extra spaces not only before or after the word
        /// but also any double spaces between words
        /// </summary>
        /// <param name="word">string to trim</param>
        public static void TrueTrim(ref string word)
        {
            word = TrueTrim(word);
        }

        public static bool EndsWith(string word, string subString, bool caseSensitive = false)
        {
            if (subString.Length > word.Length)
            {
                return false;
            }
            if (!caseSensitive)
            {
                word = word.ToUpper();
                subString = subString.ToUpper();
            }

            if (word.Substring(word.Length - subString.Length) == subString)
            {
                return true;
            }
            return false;
        }

        public static bool EndsWith(string word, string[] subString, bool caseSensitive = false)
        {
            foreach(string item in subString)
            {
                if(EndsWith(word,item,caseSensitive))
                {
                    return true;
                }
            }
            return false;
            throw new NotImplementedException();
        }

        public static bool Contains(string word, string subString, bool caseSensitive = false)
        {
            throw new NotImplementedException();
        }
        public static bool Contains(string word, string[] subString, bool caseSensitive = false)
        {
            throw new NotImplementedException();
        }
        public static bool BeginsWith(string word, string subString, bool caseSensitive = false)
        {
            if (subString.Length > word.Length)
            {
                return false;
            }
            if (!caseSensitive)
            {
                word = word.ToUpper();
                subString = subString.ToUpper();
            }

            if (word.Substring(0,subString.Length)==subString)
            {
                return true;
            }
            return false;
        }
        public static bool BeginsWith(string word, string[] subString, bool caseSensitive = false)
        {
            foreach(string item in subString)
            {
                if(BeginsWith(word,item,caseSensitive))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
