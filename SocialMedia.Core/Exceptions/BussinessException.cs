using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException()
        {

        }

        public BussinessException(string message) : base(message)
        {

        }
    }
}
