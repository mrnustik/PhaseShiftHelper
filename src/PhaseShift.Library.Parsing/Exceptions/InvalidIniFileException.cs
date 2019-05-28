using System;
using System.Collections.Generic;
using System.Text;

namespace PhaseShift.Library.Parsing.Exceptions
{

    [Serializable]
    public class InvalidIniFileException : Exception
    {
        public InvalidIniFileException() { }
        public InvalidIniFileException(string message) : base(message) { }
        public InvalidIniFileException(string message, Exception inner) : base(message, inner) { }
        protected InvalidIniFileException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
