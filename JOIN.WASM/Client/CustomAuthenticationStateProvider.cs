using JOIN.WASM.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace JOIN.WASM.Client
{
    /// <summary>
    /// 11.4-Habilitando la Autenticacion
    /// Clase que permite estructurar la seguridad e implementar la clase abstracta  AuthenticationStateProvider
    /// </summary>
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            User currentUser = await _httpClient.GetFromJsonAsync<User>($"api/user/getcurrentuser");

            if (currentUser != null && currentUser.EmailAddress != null)
            {
                //create a claim
                var claim = new Claim(ClaimTypes.Name, currentUser.EmailAddress);
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

    }
}
