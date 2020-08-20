/*
 * Brian Chaves
 * April 8,2014
 * Validater Test
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BC_Functions;

namespace BC_FunctionsTest
{
    [TestFixture]
    public class ValidatorTest
    {
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_positive()
        {
            Assert.IsTrue(Validator.IsValidEmailAddress("brian@yahoo.ca"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_missing_first_part()
        {
            Assert.IsFalse(Validator.IsValidEmailAddress("@yahoo.ca"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_missing_at_symble()
        {
            Assert.IsFalse(Validator.IsValidEmailAddress("brianyahoo.ca"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_missing_middle()
        {
            Assert.IsFalse(Validator.IsValidEmailAddress("brian@.ca"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_missing_dot()
        {
            Assert.IsFalse(Validator.IsValidEmailAddress("brian@yahooca"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_missing_last_part()
        {
            Assert.IsFalse(Validator.IsValidEmailAddress("brian@yahoo."));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_allow_nulls()
        {
            Assert.IsTrue(Validator.IsValidEmailAddress("",true));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void email_test_forbid_nulls()
        {
            Assert.IsFalse(Validator.IsValidEmailAddress("", false));
            Assert.IsFalse(Validator.IsValidEmailAddress(""));
        }

        //***********************************************************PHONE TEST*************************************************************************

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_standard()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("123-4567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_with_space()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("123 4567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_with_no_seperator()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("1234567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_with_area_code()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("(519) 123-4567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_with_area_code_no_brakets()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("519 123-4567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_with_area_code_all_dash()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("519-123-4567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_with_area_code_no_seperator()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("5191234567"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_short_number()
        {
            Assert.IsFalse(Validator.IsValidPhoneNumber("123-456"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_short_number_no_space()
        {
            Assert.IsFalse(Validator.IsValidPhoneNumber("123456"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_long_number()
        {
            Assert.IsFalse(Validator.IsValidPhoneNumber("1234-7568"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_long_number_no_space()
        {
            Assert.IsFalse(Validator.IsValidPhoneNumber("12347568"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_invalid_characters()
        {
            Assert.IsFalse(Validator.IsValidPhoneNumber("L2E4SG7"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_allow_nulls()
        {
            Assert.IsTrue(Validator.IsValidPhoneNumber("",true));
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void phone_test_forbid_nulls()
        {
            Assert.IsFalse(Validator.IsValidPhoneNumber("",false));
            Assert.IsFalse(Validator.IsValidPhoneNumber(""));
        }

        //***********************************************POSTAL CODE TEST************************************************************
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void postal_code_test_positive()
        {
            Assert.IsTrue(Validator.IsValidPostalCode("n1r7v4"));
            Assert.IsTrue(Validator.IsValidPostalCode("N1R7V4"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void postal_code_test_negitive()
        {
            Assert.IsFalse(Validator.IsValidPostalCode("1nr7v4"));
            Assert.IsFalse(Validator.IsValidPostalCode("1NR7V4"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void postal_code_test_with_space()
        {
            Assert.IsTrue(Validator.IsValidPostalCode("n1r 7v4"));
            Assert.IsTrue(Validator.IsValidPostalCode("N1R 7V4"));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void postal_code_test_allow_nulls()
        {
            Assert.IsTrue(Validator.IsValidPostalCode("",true));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void postal_code_test_forbid_nulls()
        {
            Assert.IsFalse(Validator.IsValidPostalCode("", false));
            Assert.IsFalse(Validator.IsValidPostalCode(""));
        }

        public void postal_code_test_change_to_uppercase()
        {
            string postalCode = "n1r7v4";
            Assert.IsTrue(Validator.IsValidPostalCode(ref postalCode));
            Assert.AreEqual("N1R7V4",postalCode);
        }

        public void postal_code_test_dont_change_to_uppercase()
        {
            string postalCode = "1nr7v4";
            Assert.IsFalse(Validator.IsValidPostalCode(ref postalCode));
            Assert.AreEqual("1nr7v4",postalCode);
        }
    }
}
