using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursioApi
{
	public enum CoursioInvitationStatus
	{
		[CoursioInvitationStatusAttribute("Skapad")]
		New = 1,
		[CoursioInvitationStatusAttribute("Skickad")]
		Sent = 2,
		[CoursioInvitationStatusAttribute("Mottagen")]
		Read = 4,
		[CoursioInvitationStatusAttribute("Accepterad")]
		Accepted = 8,
		[CoursioInvitationStatusAttribute("Nekad")]
		Declined = 16,
		[CoursioInvitationStatusAttribute("Fel har uppstått")]
		Error = 32
	}
}
