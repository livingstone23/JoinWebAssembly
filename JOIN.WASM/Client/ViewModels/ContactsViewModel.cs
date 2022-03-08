using JOIN.WASM.Shared.Models;
using System.Net.Http.Json;

namespace JOIN.WASM.Client.ViewModels
{
    public class ContactsViewModel : IContactsViewModel
    {
        //properties
        public List<Contact> Contacts { get; set; }
        private HttpClient _httpClient;

        //methods
        public ContactsViewModel(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }
        public async Task GetContacts()
        {
            List<User> users = await _httpClient.GetFromJsonAsync<List<User>>($"api/user/getcontacts");

            LoadCurrentObject(users);
        }

        private void LoadCurrentObject(List<User> users)
        {
            this.Contacts = new List<Contact>();
            foreach (User user in users)
            {
                this.Contacts.Add(user);
            }
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            List<User> users = await _httpClient.GetFromJsonAsync<List<User>>("api/user/getallcontacts");
            LoadCurrentObject(users);
            return Contacts;
        }

        public async Task<List<Contact>> GetOnlyVisibleContacts(int startIndex, int count)
        {
            List<User> users = await _httpClient.GetFromJsonAsync<List<User>>($"api/user/getonlyvisiblecontacts?startIndex={startIndex}&count={count}");

            LoadCurrentObject(users);
            return Contacts;
        }

        public async Task<int> GetContactsCount()
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/user/getcontactscount");
        }

        public async Task<List<Contact>> GetVisibleContacts(int startIndex, int count)
        {
            List<User> users = await _httpClient.GetFromJsonAsync<List<User>>($"api/user/getvisiblecontacts?startIndex={startIndex}&count={count}");

            LoadCurrentObject(users);
            return Contacts;
        }

        
    }
}
