using System;

namespace Dal.Model {
    public class Message
    {
        public Guid Id { get; private set; }
        public Guid ConversationId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        /// <summary>
        /// Time that server received the Message
        /// </summary>
        public DateTime PostAt { get; set; }
    }
}