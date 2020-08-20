using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks.Exceptions
{
    public class NoHighScoreException : Exception
    {
        public override string Message
        {
            get
            {
                return "Did not make highScore";
            }
        }
    }
}
