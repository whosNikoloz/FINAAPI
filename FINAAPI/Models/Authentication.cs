using System;

namespace FINAAPI.Models
{
    public class AuthenticationRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public string Ex { get; set; }
    }
} 