using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Exceptions
{
    public class BadCredentialsException : Exception
    {
        public BadCredentialsException(string message) : base(message)
        {

        }

        public BadCredentialsException()
        {

        }
    }
}
