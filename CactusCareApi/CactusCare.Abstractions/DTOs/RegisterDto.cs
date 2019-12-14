using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.DTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
