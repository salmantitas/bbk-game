using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    internal class Month
    {
        private int id;

        internal int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        internal string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int dayCount;

        internal int DayCount
        {
            get { return dayCount; }
            set { dayCount = value; }
        }
        private int leapYearDayCountChange;

        internal int LeapYearDayCountChange
        {
            get { return leapYearDayCountChange; }
            set { leapYearDayCountChange = value; }
        }

        internal Month(
            int id,
            string name,
            int dayCount,
            int leapYearDayCountChange = 0)
        {
            this.id = id;
            this.name = name;
            this.dayCount = dayCount;
            this.leapYearDayCountChange = leapYearDayCountChange;
        }
    }
}
