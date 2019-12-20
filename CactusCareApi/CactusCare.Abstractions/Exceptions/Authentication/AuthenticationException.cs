using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Exceptions.Authentication
{

    [Serializable]
    public class AuthenticationException : StatusCodeException
    {
        public AuthenticationException():base("Authentication failed",401){ }
        public AuthenticationException(string message) : base(message,401) { }
        public AuthenticationException(string message, Exception inner) : base(message, inner, 401) { }
        protected AuthenticationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
