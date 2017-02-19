using System;

namespace Dal.Models
{
	public enum InvitationStatus {Pending, Accepted, Rejected};
	
	public class Invitation: UserConversation
	{
		/// <summary>
		/// User Id (= email) the person created this invitation 
		/// </summary>
		public string Sender { get; set; }
		
		public InvitationStatus Status { get; set; }
	}
}
