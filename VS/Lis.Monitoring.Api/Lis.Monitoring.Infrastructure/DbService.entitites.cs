using System;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Lis.Monitoring.Infrastructure 
{
	public partial class DbService
	{
		public const string DEFAULT_SCHEMA = "dbo";

		public DbSet<Member> Member { get; set; }
      public DbSet<Device> Device { get; set; }
      public DbSet<DeviceParameter> DeviceParameter { get; set; }
      public DbSet<DeviceParameterData> DeviceParameterData { get; set; }
      public DbSet<MemberType> MemberType { get; set; }
      public DbSet<ActiveDeviceLastData> ActiveDeviceLastData { get; set; }      

      private void ApplyEntityConfigurations(ModelBuilder modelBuilder) 
		{
			modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
         modelBuilder.ApplyConfiguration(new DeviceEntityTypeConfiguration());

      }

        private void DataSeed(ModelBuilder modelbuilder) {

            //DateTimeOffset createdDateTimeOffset = new DateTimeOffset(new DateTime(2018,1,1));
            //string uzivatelVytvoreni = "Data Seed";

           

            #region Uzivatel

            modelbuilder.Entity<Member>().HasData(
                new Member { 
                    //Email = "lendr@visionq.cz",
                    //EmailVerifikovan = true,
                    //Jmeno = "Admin",
                    //Prijmeni = "Admin",
                    //HesloHash = "2aeQYhwwVuFvrRUk/O+aO704x+jWByOXs55rSvcv56E=", // heslo: 123456
                    //HesloSul = "UMGctFR1IDIqEHV5nxd+Cw==",
                    //DatumVytvoreni = createdDateTimeOffset,
                    //UzivatelVytvoreni = uzivatelVytvoreni
                }
            );

            #endregion

        }
	}
}