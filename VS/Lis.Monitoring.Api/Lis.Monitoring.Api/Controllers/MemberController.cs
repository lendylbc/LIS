using System.Collections.Generic;
using Lis.Monitoring.Api.Authentication;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Authentication;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lis.Monitoring.Dto.Communication;
using AutoMapper;
using Serilog;
using System.Threading.Tasks;

namespace Lis.Monitoring.Api.Controllers {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MemberController : BaseController<Member, long, IMemberService, MemberDto, MemberDto, MemberDto, MemberQuery> {//BaseController<Member, long, IMemberService, MemberDto, MemberDto, MemberDto, MemberQuery> {
		private static readonly ILogger log = Serilog.Log.ForContext<MemberController>();

		private readonly IAuthJwt _authJwt;

		private readonly List<MemberDto> lstMember = new List<MemberDto>()
		{
				new MemberDto() {Id=1, Name="Lendy" },
				new MemberDto() {Id=2, Name="Halba" },
				new MemberDto() {Id=3, Name="Jirka"},
				new MemberDto() {Id=3, Name="Irča"}
		  };

		public MemberController(IMemberService memberService, IMapper mapper, IAuthJwt authJwt) : base(memberService, mapper) {// : base(TEntityService entityService, mapper) {		//IMemberService entityService, IMapper mapper, 
			_authJwt = authJwt;
		}

		//[HttpGet]
		//public IEnumerable<MemberDto> AllMembers() {
		//	return lstMember;
		//}

		[AllowAnonymous]
		// POST api/<MembersController>
		[HttpPost("authentication")]
		public IActionResult Authentication([FromBody] MemberCredentialDto userCredential) {//Task<MemberDto>																														
			Member member = EntityService.GetByCredentials(userCredential.UserName, userCredential.Password);
			var token = _authJwt.Authenticate(member);
			if(token == null)
				return Unauthorized();
			//log.Debug($"Token: {token}");
			return Ok(token);
		}


	}
}
