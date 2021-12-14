using Lis.Monitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lis.Monitoring.Infrastructure.EntityConfigurations
{
	public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
	{
		public void Configure(EntityTypeBuilder<Member> userConfiguration) {

			userConfiguration.ToTable("Member", DbService.DEFAULT_SCHEMA);

			userConfiguration.HasKey(r => r.Id);

			userConfiguration.HasIndex(r => r.Email).IsUnique();

		 //   userConfiguration.Property(u => u.KvotaAdministrator).HasDefaultValue(1);
		}
	}
}