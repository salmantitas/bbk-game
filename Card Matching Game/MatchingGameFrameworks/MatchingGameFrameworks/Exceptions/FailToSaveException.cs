using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchingGameFrameworks.Exceptions
{
    public class FailToSaveException : Exception
    {
        //private Exception subException;

        //public Exception SubException1
        //{
        //    get { return subException; }
        //    set { subException = value; }
        //}
        public FailToSaveException()
        {
            //subException=null;
        }
        public FailToSaveException(Exception innerException)
            :base("",innerException)
        {

        }

        public override string Message
        {
            get
            {
                string message;
                message = "Fail to save";
                if (InnerException != null)
                {
                    message += "\r\n" + InnerException.Message;
                }
                return message;
            }
        }
    }
}
