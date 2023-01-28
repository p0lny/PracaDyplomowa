using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Exceptions
{
    public class UsetNotActivatedException : Exception
    {
        public UsetNotActivatedException(string message) : base(message)
        {

        }

        public UsetNotActivatedException()
        {

        }
    }
}
