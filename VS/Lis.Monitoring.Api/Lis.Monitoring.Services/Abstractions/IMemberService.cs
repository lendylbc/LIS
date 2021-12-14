using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IMemberService : IBaseEntityService<Member, long, MemberQuery, MemberDto> {
	}
}
