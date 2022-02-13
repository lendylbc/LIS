using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Domain.Entities {
	public class Member : Entity, INotifikaceOdberSource, IChangeTrackingMember {

		public string Login { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string? Phone { get; set; }
		public bool Active { get; set; }
		public int MemberType { get; set; }
		public DateTime Inserted { get; set; }
		public bool SendNotifications { get; set; }		

		[NotMapped]
		public string UserName => Email;
	}
}
