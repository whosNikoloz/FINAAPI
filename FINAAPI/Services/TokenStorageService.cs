using System;

namespace FINAAPI.Services
{
    public class TokenStorageService
    {
        private static string _token;
        private static DateTime _tokenExpiration;

        public void SetToken(string token)
        {
            _token = token;
            // Set token expiration to 36 hours from now (as per FINA API spec)
            _tokenExpiration = DateTime.UtcNow.AddHours(36);
        }

        public string GetToken()
        {
            if (string.IsNullOrEmpty(_token) || DateTime.UtcNow >= _tokenExpiration)
            {
                return null;
            }
            return _token;
        }

        public bool IsTokenValid()
        {
            return !string.IsNullOrEmpty(_token) && DateTime.UtcNow < _tokenExpiration;
        }
    }
} 