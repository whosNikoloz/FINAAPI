using Microsoft.AspNetCore.Mvc;
using FINAAPI.Models;
using FINAAPI.Services;
using System.Threading.Tasks;
using FINAAPI.Services.intefaces;

namespace FINAAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly FinaApiClient _apiClient;

        public AuthenticationController(IAuthenticationService authService, FinaApiClient apiClient)
        {
            _authService = authService;
            _apiClient = apiClient;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            try
            {
                var response = await _authService.AuthenticateAsync(request.Login, request.Password);
                
                if (response.Ex != null)
                {
                    return Ok(new AuthenticationResponse { Token = null, Ex = response.Ex });
                }

                // Set the token for subsequent API calls
                _apiClient.SetAuthToken(response.Token);
                
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return Ok(new AuthenticationResponse { Token = null, Ex = ex.Message });
            }
        }
    }
} 