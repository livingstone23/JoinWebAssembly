﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOIN.WASM.Shared.Models
{
    public partial class User
    {

        //public User()
        //{
        //    ChatHistoryFromUsers = new HashSet<ChatHistory>();
        //    ChatHistoryToUsers = new HashSet<ChatHistory>();
        //}

        public long UserId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string ProfilePictureUrl { get; set; }
        //public byte[] DateOfBirth { get; set; }
        public string AboutMe { get; set; }
        public int Notifications { get; set; }
        public int DarkTheme { get; set; }
        //public byte[] CreatedDate { get; set; }

        //public virtual ICollection<ChatHistory> ChatHistoryFromUsers { get; set; }
        //public virtual ICollection<ChatHistory> ChatHistoryToUsers { get; set; }

    }
}
