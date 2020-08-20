using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks.Exceptions
{
    public class FailToLoadException : Exception
    {
        //private Exception subException;

        //public Exception SubException
        //{
        //    get { return subException; }
        //    set { subException = value; }
        //}
        public FailToLoadException()
        {
            //subException = null;
        }

        //public FailToLoadException(Exception subException)
        //{
        //    this.subException = subException;
        //}

        public FailToLoadException(Exception innerException)
            :base("",innerException)
        {

        }

        public override string Message
        {
            get
            {
                string message;
                message = "Fail to load file.";
                if (InnerException != null)
                {
                    message += "\r\n" + InnerException.Message;
                }
                return message;
            }
        }

    }
}
