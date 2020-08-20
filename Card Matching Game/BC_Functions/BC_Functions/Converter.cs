/*
 * Brian Chaves
 * April 21,2014
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC_Functions
{
    public static class Converter
    {
        /// <summary>
        /// Converts boolean to int(0 or 1)
        /// </summary>
        /// <param name="value">bool value</param>
        /// <returns>0 or 1</returns>
        public static int BoolToInt(bool value)
        {
            if (value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Converts 0 or 1 to ture or false
        /// </summary>
        /// <param name="value">0 or 1</param>
        /// <returns>boolean</returns>
        public static bool IntToBool(int value)
        {
            return (value >= 1);
        }

        /// <summary>
        /// Converts string value to boolean
        /// </summary>
        /// <param name="value">String value</param>
        /// <returns>true or false</returns>
        public static bool StringToBool(string value)
        {
            if (value == "0")
            {
                return false;
            }
            else if (value == "1")
            {
                return true;
            }
            else if (value.ToUpper() == "TRUE")
            {
                return true;
            }
            else if (value.ToUpper() == "FALSE")
            {
                return false;
            }
            else if (value.ToUpper()=="T")
            {
                return true;
            }
            else if (value.ToUpper()=="F")
            {
                return false;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// Converts 24 Hour Time to 12 Hour time with AM or PM
        /// </summary>
        /// <param name="hour">hour</param>
        /// <returns>time in 12 hour format</returns>
        public static string Time24To12(int hour)
        {
            if (hour == 0)
            {
                return "12AM";
            }
            else if (hour < 12)
            {
                return hour + "AM";
            }
            else if (hour == 12)
            {
                return "12PM";
            }
            else if (hour < 24)
            {
                return ((hour - 12) + "PM");
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
