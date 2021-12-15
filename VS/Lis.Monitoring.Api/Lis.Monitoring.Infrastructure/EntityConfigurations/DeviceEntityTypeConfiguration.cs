using Lis.Monitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lis.Monitoring.Infrastructure.EntityConfigurations {
	public class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device> {
		public void Configure(EntityTypeBuilder<Device> userConfiguration) {

			userConfiguration.ToTable("Device", DbService.DEFAULT_SCHEMA);

			userConfiguration.HasKey(r => r.Id);

			userConfiguration.HasIndex(r => r.IpAddress).IsUnique();
		}
	}
}
