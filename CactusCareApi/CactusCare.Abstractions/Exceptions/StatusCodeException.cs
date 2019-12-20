using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CactusCare.Abstractions.Exceptions
{
    [Serializable]
    public class StatusCodeException : CactusCareException
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        public StatusCodeException(int code, string contentType = "text/plain")
        {
            StatusCode = code;
            ContentType = contentType;
        }

        public StatusCodeException(string message, int code, string contentType = "text/plain") : base(message)
        {
            StatusCode = code;
            ContentType = contentType;
        }

        public StatusCodeException(string message, Exception inner, int code, string contentType = "text/plain") : base(message, inner)
        {
            StatusCode = code;
            ContentType = contentType;
        }

        protected StatusCodeException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
