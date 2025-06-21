using FINAAPI.Models;
using System.Threading.Tasks;

namespace FINAAPI.Services.intefaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(string login, string password);
    }
} 