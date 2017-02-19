using System;
using System.Collections.Generic;

namespace Dal.Models
{
	public class Conversation
	{
		public Guid Id { get; private set; }
		public string Subject { get; set; }
		
		/// <summary>
		/// Participation Id
		/// </summary>
		public List<Guid> Members { get; set; }
		
		/// <summary>
		/// Invitation Id
		/// </summary>
		public List<Guid> Invitations { get; set; }
		public List<Message> Messages { get; set; }
		public bool IsArchived { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
