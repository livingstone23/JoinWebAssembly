﻿using JOIN.WASM.Shared.Models;

namespace JOIN.WASM.Client.ViewModels
{
    /// <summary>
    /// Clase para implementar Patron MVVM
    /// </summary>
    public class ProfileViewModel: IProfileViewModel
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
            this.Message = this.FirstName + "'s Profile updated successfully";
        }

        public void GetProfile()
        {
            //User user = await HttpClient.GetFromJsonAsync<User>("user/getprofile/10");
            //_profileViewModel = user;
            this.FirstName = "John";
            this.Message = this.FirstName + "'s Profile loaded successfully";
        }

        public static implicit operator ProfileViewModel(User user)
        {
            return new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId
            };
        }

        public static implicit operator User(ProfileViewModel profileViewModel)
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
