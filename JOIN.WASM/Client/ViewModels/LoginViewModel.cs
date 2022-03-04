using JOIN.WASM.Shared.Models;
using System.Net.Http.Json;

namespace JOIN.WASM.Client.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        private HttpClient _httpClient;
        public LoginViewModel()
        {

        }
        public LoginViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        /// <summary>
        /// Method to get the user when registering
        /// </summary>
        /// <returns></returns>
        public async Task LoginUser()
        {
            await _httpClient.PostAsJsonAsync<User>($"api/user/loginuser", this);
        }

        public static implicit operator LoginViewModel(User user)
        {
            return new LoginViewModel
            {
                EmailAddress = user.EmailAddress,
                Password = user.Password
            };
        }

        public static implicit operator User(LoginViewModel loginViewModel)
        {
            return new User
            {
                EmailAddress = loginViewModel.EmailAddress,
                Password = loginViewModel.Password
            };
        }
    }
}
