using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks.Exceptions
{
    public class BelowMinimumException : Exception
    {
        private int minimum;
        public int Minimum
        {
            get
            {
                return minimum;
            }
            protected set
            {
                minimum = value;
            }
        }

        private int currentValue;

        public int CurrentValue
        {
            get { return currentValue; }
            protected set { currentValue = value; }
        }

        public BelowMinimumException(int minimum,int currentValue)
        {
            this.minimum = minimum;
            this.currentValue = currentValue;
        }

        protected BelowMinimumException()
        {
            minimum = 0;
            currentValue = 0;
        }


        public override string Message
        {
            get
            {
                return "Minimum value is " + minimum.ToString() + "\r\n" +
                        "Curent value is " + currentValue.ToString();
            }
        }
    }
}
