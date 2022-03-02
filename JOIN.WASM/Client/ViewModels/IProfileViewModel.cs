namespace JOIN.WASM.Client.ViewModels
{
    public interface IProfileViewModel
    {

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }

        public void UpdateProfile();
        public void GetProfile();

    }
}
