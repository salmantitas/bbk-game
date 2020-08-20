using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using NUnit.Framework;

namespace BC_FunctionsTest
{
    [TestFixture]
    class StringFunctionTest
    {
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void true_trim()
        {
            string word = "                can't                  touch                      this                       ";
            word = StringFunction.TrueTrim(word);
            Assert.AreEqual("can't touch this", word);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void true_trim_ref()
        {
            string word = "  Brian     is     great     ";
            StringFunction.TrueTrim(ref word);
            Assert.AreEqual("Brian is great", word);
        }



        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_positive()
        {
            string word = "You bastard";
            string subString = "bastard";
            Assert.IsTrue(StringFunction.EndsWith(word, subString));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_negitive()
        {
            string word = "You bastard";
            string subString = "jerk";
            Assert.IsFalse(StringFunction.EndsWith(word, subString));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_case_sensitive_positive()
        {
            string word = "testing wHaT";
            string subString = "wHaT";
            Assert.IsTrue(StringFunction.EndsWith(word, subString, true));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_case_sensitive_negitive()
        {
            string word = "testing wHaT";
            string subString = "whaT";
            Assert.IsFalse(StringFunction.EndsWith(word, subString, true));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_not_case_sensitive()
        {
            string word = "testing wHaT";
            string subString = "whaT";
            Assert.IsTrue(StringFunction.EndsWith(word, subString, false));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_substring_too_big()
        {
            string word = "pac";
            string subString = "pacman";
            Assert.IsFalse(StringFunction.EndsWith(word, subString, true));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_same_word()
        {
            string word = "word";
            string subString = "word";
            Assert.IsTrue(StringFunction.EndsWith(word, subString));
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_list_positive()
        {
            string[] word = {"this.jpg", "this.bmp" };
            string[] list = { ".jpg",".bmp" };

            Assert.IsTrue(StringFunction.EndsWith(word[0], list));
            Assert.IsTrue(StringFunction.EndsWith(word[1], list));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_ends_list_negitive()
        {
            string[] word = { "this.jpeg", "this.bmpp" };
            string[] list = { ".jpg", ".bmp" };

            Assert.IsFalse(StringFunction.EndsWith(word[0], list));
            Assert.IsFalse(StringFunction.EndsWith(word[1], list));
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void string_end_list_case_sensitive()
        {
            string word ="this.jpg" ;

            string[] list = { ".JPG", ".bmp" };

            Assert.IsTrue(StringFunction.EndsWith(word, list, false),"false negitive");
            Assert.IsFalse(StringFunction.EndsWith(word, list, true),"false positive");
        }



        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_with_positive()
        {
            string word = "You bastard";
            string subString = "You";
            Assert.IsTrue(StringFunction.BeginsWith(word, subString));
        }
        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_negitive()
        {
            string word = "You bastard";
            string subString = "me";
            Assert.IsFalse(StringFunction.BeginsWith(word, subString));
        }
        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_case_sensitive_positive()
        {
            string word = "Testing what";
            string subString = "Testing";
            Assert.IsTrue(StringFunction.BeginsWith(word, subString, true));
        }
        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_case_sensitive_negitive()
        {
            string word = "testing what";
            string subString = "Testing";
            Assert.IsFalse(StringFunction.BeginsWith(word, subString, true));
        }
        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_not_case_sensitive()
        {
            string word = "testing what";
            string subString = "Testing";
            Assert.IsTrue(StringFunction.BeginsWith(word, subString, false));
        }
        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_substring_too_big()
        {
            string word = "pac";
            string subString = "pacman";
            Assert.IsFalse(StringFunction.BeginsWith(word, subString, true));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_same_word()
        {
            string word = "word";
            string subString = "word";
            Assert.IsTrue(StringFunction.BeginsWith(word, subString));
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_list_positive()
        {
            string[] word = {"this.jpg", "that.jpg" };
            string[] list = { "this","that" };

            Assert.IsTrue(StringFunction.BeginsWith(word[0], list));
            Assert.IsTrue(StringFunction.BeginsWith(word[1], list));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_list_negitive()
        {
            string[] word = { "this.jpg", "that.jpg" };
            string[] list = { "no", "nah" };

            Assert.IsFalse(StringFunction.BeginsWith(word[0], list));
            Assert.IsFalse(StringFunction.BeginsWith(word[1], list));
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void string_begins_list_case_sensitive()
        {
            string word ="this.jpg" ;

            string[] list = { "THIS", "THAT" };

            Assert.IsTrue(StringFunction.BeginsWith(word, list, false),"false negitive");
            Assert.IsFalse(StringFunction.BeginsWith(word, list, true),"false positive");
        }
        
    }
}
