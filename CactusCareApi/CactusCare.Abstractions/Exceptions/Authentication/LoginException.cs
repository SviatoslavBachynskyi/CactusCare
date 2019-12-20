using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CactusCare.Abstractions.Exceptions.Authentication
{
    [Serializable]
    public class LoginException : AuthenticationException
    {
        public LoginException():base("Login failed") { }
        public LoginException(string message) : base(message) { }
        public LoginException(string message, Exception inner) : base(message, inner) { }

        protected LoginException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
