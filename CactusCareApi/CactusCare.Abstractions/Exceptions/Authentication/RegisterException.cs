using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CactusCare.Abstractions.Exceptions.Authentication
{
    [Serializable]
    public class RegisterException : AuthenticationException
    {
        public RegisterException():base("Registration failed") { }
        public RegisterException(string message) : base(message) { }
        public RegisterException(string message, Exception inner) : base(message, inner) { }

        protected RegisterException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
