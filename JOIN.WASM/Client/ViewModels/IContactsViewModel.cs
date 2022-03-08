

namespace JOIN.WASM.Client.ViewModels
{
    public interface IContactsViewModel
    {

        public List<Contact> Contacts { get; set; }
        public Task GetContacts();

        public Task<List<Contact>> GetAllContacts();
        public Task<List<Contact>> GetOnlyVisibleContacts(int startIndex, int numberOfUsers);
        public Task<int> GetContactsCount();
        public Task<List<Contact>> GetVisibleContacts(int startIndex, int numberOfUsers);

    }
}
