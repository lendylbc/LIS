using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lis.Monitoring.Abstractions.Common;
using Lis.Monitoring.Abstractions.Entities;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Lis.Monitoring.Api.Controllers {
	[Authorize]
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public abstract class BaseController<TEntity, TId, TEntityService, TInputDto, TDto, TUpdateDto, TQuery> : ControllerBase
		where TEntity : class, IEntity<TId>
		where TId : struct
		where TInputDto : IDto<TId?>, new()
		where TDto : IDto<TId?>, new()
		where TQuery : class, IPagedQuery
		where TEntityService : IBaseEntityService<TEntity, TId, TQuery, TUpdateDto> {

		protected readonly TEntityService EntityService;
		protected readonly IMapper Mapper;

		protected BaseController(TEntityService entityService, IMapper mapper) {  //	TEntityService entityService, IMapper mapper
			EntityService = entityService;
			Mapper = mapper;
		}

		/// <summary>
		/// Detail záznamu
		/// </summary>
		/// <param name="id">Identifikátor záznamu</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<TDto> GetById(TId id) {
			TEntity entity = await EntityService.GetByIdAsync(id);
			var dto = Mapper.Map<TDto>(entity);
			return dto;
		}

		/// <summary>
		/// Dotaz na stránkovaný seznam záznamů
		/// </summary>
		/// <param name="query">Stránkovaný dotaz s filtrem</param>
		/// <returns>Stránkovaný seznam záznamů</returns>
		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public async Task<IPagedResponse<TDto>> Get([FromQuery] TQuery query) {
			ICollection<TEntity> items = await EntityService.GetListAsync(query);

			var response = new PagedResponse<TDto> {
				Page = query.Page,
				Size = query.Size,
				Total = 10,
				Data = Mapper.Map<List<TDto>>(items)
			};

			return response;
		}

		[HttpPost]
		[ProducesResponseType(201)]
		[ProducesResponseType(400)]
		[ProducesResponseType(401)]
		public virtual async Task<ActionResult<TDto>> Save([FromBody] TInputDto dto) {
			try {
				TEntity res = await EntityService.SaveAsync(Mapper.Map<TEntity>(dto));
				return CreatedAtAction(nameof(GetById), new { res.Id }, Mapper.Map<TInputDto>(res));
			} catch(Exception e) {
				return BadRequest(new { message = HandleException(e) });
			}			
		}

		[HttpPut("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(409)]
		public virtual async Task<IActionResult> Put(TId id, TUpdateDto data) {
			try {
				TEntity entity = await EntityService.UpdateAsync(id, data);
				return Ok();
			} catch(Exception e) {
				return BadRequest(new { message = HandleException(e) });
			}						
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(409)]
		public async Task<IActionResult> Delete(TId id) {
			try {
				var device = await EntityService.DeleteAsync(id);

				if(device == null) {
					return NotFound($"Id = {id} nenalezeno!");
				}

				return Ok();
			} catch(Exception e) {
				return BadRequest(new { message = HandleException(e) });
			}			
		}

		private string HandleException(Exception exception) {
			if(exception is DbUpdateConcurrencyException concurrencyEx) {
				return "Concurrency exception";
			} else if(exception is DbUpdateException dbUpdateEx) {
				if(dbUpdateEx.InnerException != null) {
					if(dbUpdateEx.InnerException is SqlException sqlException) {
						switch(sqlException.Number) {
							case 2627:  // Unique constraint error
							case 547:   // Constraint check violation
							case 2601:  // Duplicated key row error
											// Constraint violation exception

								return "Unique key exception";
							default:
								return "Database access exception: " +
								dbUpdateEx.Message + Environment.NewLine + dbUpdateEx.InnerException;
						}
					}

					return "Database access exception: " +
								dbUpdateEx.Message + Environment.NewLine + dbUpdateEx.InnerException;
				} else {
					return exception.Message;
				}
			} else {
				return exception.Message;
			}
		}
	}
}