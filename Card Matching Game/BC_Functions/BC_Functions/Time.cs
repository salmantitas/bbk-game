using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public static class Time
    {

        private static List<Month> GetMonth()
        {
            List<Month> month;
            month = new List<Month>();
            month.Add(new Month(1,"January",31));
            month.Add(new Month(2, "February", 28, 1));
            month.Add(new Month(3, "March", 31));
            month.Add(new Month(4, "April", 30));
            month.Add(new Month(5, "May", 31));
            month.Add(new Month(6, "June", 30));
            month.Add(new Month(7, "July", 31));
            month.Add(new Month(8, "August", 31));
            month.Add(new Month(9, "September", 30));
            month.Add(new Month(10, "October", 31));
            month.Add(new Month(11, "November", 30));
            month.Add(new Month(12, "December", 31));

            return month;
        }

        private const int SECONDS_IN_A_MINUTE = 60;

        public static string SecondsToString(int seconds)
        {
            return SecondsToString((decimal)seconds);
        }
        public static string SecondsToString(decimal seconds, int roundDigit = 0)
        {
            seconds = Math.Round(seconds, roundDigit);
            int minutes = (int)Math.Floor(seconds / SECONDS_IN_A_MINUTE);
            seconds = seconds % SECONDS_IN_A_MINUTE;

            string addZero;
            if (seconds < 10)
            {
                addZero = "0";
            }
            else
            {
                addZero = "";
            }

            return minutes.ToString() + ":" + addZero + seconds.ToString();
        }

        public static bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }

            if (year % 100 == 0)
            {
                return false;
            }
            return year % 4 ==0;
        }

        public static string MonthName(int monthID)
        {

            List<Month> month=GetMonth();
            foreach (Month item in month)
            {
                if (item.ID == monthID)
                {
                    return item.Name;
                }

            }
            throw new IndexOutOfRangeException();
        }

        public static int MonthDayCount(int monthID, bool leapYear = false)
        {
            List<Month> month = GetMonth();
            foreach (Month item in month)
            {
                if (item.ID == monthID)
                {
                    int dayCount = item.DayCount;
                    if (leapYear)
                    {
                        dayCount += item.LeapYearDayCountChange;
                    }
                    return dayCount;
                }

            }
            throw new IndexOutOfRangeException();
        }

        public static int MonthDayCount(int monthID, int year)
        {
            return MonthDayCount(monthID, IsLeapYear(year));
        }
    }
}
