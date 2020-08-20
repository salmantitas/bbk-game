using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public static class TimeFunction
    {
        private const int SECONDS_IN_A_MINUTE = 60;

        public static string SecondsToString(int seconds)
        {
            return SecondsToString((decimal)seconds);
        }
        public static string SecondsToString(decimal seconds, int roundDigit=0)
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

            return minutes.ToString() + ":" +addZero +seconds.ToString();
        }
    }
}
