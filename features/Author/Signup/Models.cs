using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Author.Signup
{
    public class NewAuthorRequest
    {
        [FromForm]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class NewAuthResponse
    {
        public int StatsCode { get; set; } = 200;

        public string Status { get; set; } = "Success";

        public string Message { get; set; } = string.Empty;
    }
}