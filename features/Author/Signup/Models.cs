using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Author.Signup
{
    public class NewAuthorRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class Response
    {
        public string Message { get; set; } = string.Empty;
    }
}