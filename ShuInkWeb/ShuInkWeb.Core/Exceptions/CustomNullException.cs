using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Core.Exceptions
{
    public class CustomNullException : ApplicationException
    {
        public CustomNullException()
        {

        }

        public CustomNullException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}
