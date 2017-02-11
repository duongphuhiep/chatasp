using System;

namespace Dal.Models {
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

        public static Message New()
        {
            return new Message {
                Id = Guid.NewGuid(),
                SentAt = DateTime.UtcNow
            };
        }
    }
}
