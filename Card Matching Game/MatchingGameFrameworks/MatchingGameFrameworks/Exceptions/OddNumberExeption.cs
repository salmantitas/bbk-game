using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks.Exceptions
{
    public class OddNumberException : Exception
    {
        public override string Message
        {
            get
            {
                return "Odd number of cards will not work";
            }
        }
    }
}
