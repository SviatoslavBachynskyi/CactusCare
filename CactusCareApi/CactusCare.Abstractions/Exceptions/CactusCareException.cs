using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CactusCare.Abstractions.Exceptions
{
    [Serializable]
    public class CactusCareException : ApplicationException
    {
        public CactusCareException() { }
        public CactusCareException(string message) : base(message) { }
        public CactusCareException(string message, Exception inner) : base(message, inner) { }

        protected CactusCareException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }   
}
