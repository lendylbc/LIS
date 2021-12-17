using AutoMapper;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Communication;


namespace Lis.Monitoring.Api.Mapper {
	public class AutoMapperProfileConfiguration : Profile {
		public AutoMapperProfileConfiguration() : this("BaseProfile") { }

		public AutoMapperProfileConfiguration(string profileName) : base(profileName) {
			CreateMap<Member, MemberDto>()
				.ForMember(dest => dest.ZasilatNotifikace, opt => opt.Ignore());
			CreateMap<Device, DeviceDto>();
		}
	}
}