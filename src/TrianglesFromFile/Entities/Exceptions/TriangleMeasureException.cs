using System;
using System.Collections.Generic;
using System.Text;

namespace TrianglesFromFile.Entities.Exceptions
{
    class TriangleMeasureException : ApplicationException
    {
        public TriangleMeasureException(string message) : base(message)
        {

        }
    }
}
