using System;
using System.Collections.Generic;
using System.Text;

namespace TrianglesFromFile.Entities.Exceptions
{
    class FactorZeroException : ApplicationException
    {
        public FactorZeroException(string message) : base(message)
        {

        }
    }
}
