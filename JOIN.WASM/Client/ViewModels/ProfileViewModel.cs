using System.Net.Http;
using System.Net.Http.Json;
using JOIN.WASM.Shared.Models;

namespace JOIN.WASM.Client.ViewModels
{
    /// <summary>
    /// Clase para implementar Patron MVVM
    /// </summary>
    public class ProfileViewModel: IProfileViewModel
    {

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }
        public string AboutMe { get; set; }

        private HttpClient _httpClient;


        //public void UpdateProfile()
        //{
        //    //User user = _profileViewModel;
        //    //await HttpClient.PutAsJsonAsync("user/updateprofile/10", user);
        //    this.Message = this.FirstName + "'s Profile updated successfully";
        //}

        //public void GetProfile()
        //{
        //    //User user = await HttpClient.GetFromJsonAsync<User>("user/getprofile/10");
        //    //_profileViewModel = user;
        //    this.FirstName = "John";
        //    this.Message = this.FirstName + "'s Profile loaded successfully";
        //}

        public ProfileViewModel()
        {

        }

        public ProfileViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task UpdateProfile()
        {
            User user = this;
            await _httpClient.PutAsJsonAsync($"api/user/getprofile/10", user);
            this.Message = "Profile updated successfully";
        }

        public async Task GetProfile()
        {
            User user = await _httpClient.GetFromJsonAsync<User>($"api/user/getprofile/10");
            LoadCurrentObject(user);
            this.Message = "Profile loaded successfully";
        }
        private void LoadCurrentObject(ProfileViewModel profileViewModel)
        {
            this.FirstName = profileViewModel.FirstName;
            this.LastName = profileViewModel.LastName;
            this.EmailAddress = profileViewModel.EmailAddress;
            this.AboutMe = profileViewModel.AboutMe;
            //add more fields
        }


        public static implicit operator ProfileViewModel(User user)
        {
            return new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId,
                AboutMe = user.AboutMe
            };
        }

        public static implicit operator User(ProfileViewModel profileViewModel)
        {
            return new User
            {
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress,
                UserId = profileViewModel.UserId,
                AboutMe = profileViewModel.AboutMe
            };
        }

    }
}
