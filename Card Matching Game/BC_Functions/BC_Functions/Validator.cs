/*
 * Brian Chaves
 * April 21, 2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BC_Functions
{
    public static class Validator
    {
        /// <summary>
        /// Checks to see if the string is a valid email
        /// </summary>
        /// <param name="email">email string</param>
        /// <param name="allowNulls">allow or forbid nulls</param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(string email, bool allowNulls = false)
        {
            if (email == "" || email == null)
            {
                return allowNulls;
            }
            else
            {
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                return regex.IsMatch(email) && !email.EndsWith(".");
            }
        }

        /// <summary>
        /// Checks to see if the input string is a valid phone number
        /// </summary>
        /// <param name="phoneNumber">Phonenumber string</param>
        /// <param name="allowNulls">allow or forbid nulls</param>
        /// <returns></returns>
        public static bool IsValidPhoneNumber(string phoneNumber, bool allowNulls = false)
        {
            if (phoneNumber == "" || phoneNumber == null)
            {
                return allowNulls;
            }
            else
            {
                if (Regex.IsMatch(phoneNumber, @"^[(]?[0-9]{3}[)]?[ -]?[0-9]{3}[ -]?[0-9]{4}$"))
                {
                    return true;
                }
                else if (Regex.IsMatch(phoneNumber, @"^[0-9]{3}[ -]?[0-9]{4}$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsValidPostalCode(string postalCode, bool allowNulls = false)
        {
            if (postalCode == "" || postalCode == null)
            {
                return allowNulls;
            }
            return Regex.IsMatch(postalCode,@"[a-zA-Z][0-9][a-zA-Z][ ]?[0-9][a-zA-Z][0-9]");
        }

        public static bool IsValidPostalCode(ref string postalCode, bool allowNulls = false)
        {


            if (IsValidPostalCode(postalCode, allowNulls))
            {
                postalCode = postalCode.ToUpper();
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
