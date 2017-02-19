using System;

namespace Dal.Models
{
	public abstract class UserConversation
	{
		public Guid Id { get; private set; }

		/// <summary>
		/// User Id = email
		/// </summary>
		public string User { get; set; }

		/// <summary>
		/// ConversationId
		/// </summary>
		public Guid Conversation { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
