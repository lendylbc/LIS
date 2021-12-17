using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lis.Monitoring.Infrastructure.EntityConfigurations {
	public class DeviceParameterEntityTypeConfiguration : IEntityTypeConfiguration<DeviceParameter> {
		public void Configure(EntityTypeBuilder<DeviceParameter> userConfiguration) {

			userConfiguration.ToTable("DeviceParameter", DbService.DEFAULT_SCHEMA);

			userConfiguration.HasKey(r => r.Id);

			//userConfiguration.HasOne<Device>();

		}
	}
}
