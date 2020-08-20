using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public class InvalidDataException:Exception
    {
        public override string Message
        {
            get
            {
                if (base.Message == "" || base.Message == null)
                {
                    return "Invalid data";
                }
                else
                {
                    return base.Message;
                }
            }
        }
    }
}
