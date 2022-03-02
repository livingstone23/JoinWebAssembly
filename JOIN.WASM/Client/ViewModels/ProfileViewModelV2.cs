using JOIN.WASM.Shared.Models;

namespace JOIN.WASM.Client.ViewModels
{
    /// <summary>
    /// Clase para implementar Patron MVVM
    /// </summary>
    public class ProfileViewModelV2 : IProfileViewModel
    {

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }

        public void UpdateProfile()
        {
            //User user = _profileViewModel;
            //await HttpClient.PutAsJsonAsync("user/updateprofile/10", user);
            this.Message = this.FirstName + "'s Profile updated successfully --faster";
        }

        public void GetProfile()
        {
            //User user = await HttpClient.GetFromJsonAsync<User>("user/getprofile/10");
            //_profileViewModel = user;
            this.FirstName = "John";
            this.Message = this.FirstName + "'s Profile loaded successfully --faster";
        }


        public static implicit operator ProfileViewModelV2(User user)
        {
            return new ProfileViewModelV2
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId
            };
        }

        public static implicit operator User(ProfileViewModelV2 profileViewModel)
        {
            return new User
            {
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress,
                UserId = profileViewModel.UserId
            };
        }

    }
}
