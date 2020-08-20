using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks.Exceptions
{
    public class CompareToSelfException : Exception
    {
        public override string Message
        {
            get
            {
                return "Can't compare to self";
            }
        }
    }
}
