﻿

namespace JOIN.WASM.Client.ViewModels
{
    public interface IContactsViewModel
    {
        public List<Contact> Contacts { get; set; }
        public Task GetContacts();

    }
}
