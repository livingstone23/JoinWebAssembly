using System;
using System.Collections.Generic;

namespace JOIN.WASM.Server.Models
{
    public partial class ChatHistory
    {
        public long ChatHistoryId { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Message { get; set; } = null!;
        public byte[] CreatedDate { get; set; } = null!;

        public virtual User FromUser { get; set; } = null!;
        public virtual User ToUser { get; set; } = null!;
    }
}
