using System;
using System.Collections.Generic;

namespace Dal.Models {
    public class Conversation
    {
        public Guid Id { get; private set; }
        public string Subject { get; set; }
        public List<User> Members { get; set; }
        public bool IsArchive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
