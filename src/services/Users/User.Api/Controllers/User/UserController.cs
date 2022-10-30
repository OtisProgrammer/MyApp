using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using User.Application.Features.User.Commands.AddUser;
using User.Application.Features.User.Commands.DeleteUser;
using User.Application.Features.User.Commands.UpdateUser;
using User.Application.Features.User.Queries.GetAllUser;
using User.Application.Features.User.Queries.GetUserById;

namespace User.Api.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion
        #region GetAllUsers
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<GetAllUserDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllUserDto>>> GetAllUsers()
        {
            var query = new GetAllUserQuery();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }
        #endregion
        #region GetUserById
        [HttpGet("GetById/{id:int}")]
        [ProducesResponseType(typeof(GetUserByIdDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserByIdDto>> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var User = await _mediator.Send(query);
            return Ok(User);
        }
        #endregion
        #region AddUser

        [HttpPost("Add")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddUser([FromBody] AddUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        #endregion
        #region UpdateUser

        [HttpPut("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }

        #endregion
        #region DeleteUser

        [HttpDelete("Delete/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand() { Id = id });

            if (result)
                return Ok();

            return BadRequest();
        }

        #endregion

    }
}
