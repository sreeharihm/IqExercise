using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.User.Queries.GetAllUser;
using Application.Features.User.Queries.GetAllUserById;
using Application.Constants;
using Application.Features.User.Commands.AddUser;
using Application.Features.User.Commands.UpdateUser;
using Application.Features.User.Commands.DeleteUser;
using Application.Extensions;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? filter, [FromQuery] int? skip, [FromQuery] int? take, [FromQuery] string? sortField, string? sortKey, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUserQuery
            {
                Filter = filter??string.Empty,
                Skip = skip,
                Take = take,
                SortField = sortField,
                SortKey = sortKey,  
            }, cancellationToken));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (id < 1)
            {
                return BadRequest(Messages.IdValidationError);
            }
            return Ok(await _mediator.Send(new GetAllUserByIdQuery
            {
                UserId = id,
            }, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command, CancellationToken cancellationToken)
        {
            if (command.IsNull())
            {
                return BadRequest(Messages.ModelValidationError);
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(403, Messages.ModelStateError);
            }
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if (id < 1)
            {
                return BadRequest(Messages.IdValidationError);
            }
            if (command.IsNull())
            {
                return BadRequest(Messages.ModelValidationError);
            }
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (id < 1)
            {
                return BadRequest(Messages.IdValidationError);
            }
            return Ok(await _mediator.Send(new DeleteUserCommand
            {
                UserId = id,
            }, cancellationToken));
        }
    }
}
