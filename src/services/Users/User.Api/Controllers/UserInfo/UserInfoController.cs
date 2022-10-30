using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using User.Application.Contracts.Infrastructure.Interfaces;
using User.Application.Features.UserInfo.Commands.AddUserInfo;
using User.Application.Features.UserInfo.Commands.DeleteUserInfo;
using User.Application.Features.UserInfo.Commands.UpdateUserInfo;
using User.Application.Features.UserInfo.Queries.GetAllUserInfoByUserId;
using User.Application.Features.UserInfo.Queries.GetUserInfoById;

namespace User.Api.Controllers.UserInfo
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        private readonly IPostService _postService;
        public UserInfoController(IMediator mediator, IPostService postService)
        {
            _mediator = mediator;
            _postService = postService;
        }
        #endregion
        #region GetAllUserInfos
        [HttpGet("GetAll/{userId:int}")]
        [ProducesResponseType(typeof(IEnumerable<GetAllUserInfoByUserIdDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GetAllUserInfoByUserIdDto>>> GetAllUserInfos(int userId)
        {
            var query = new GetAllUserInfoByUserIdQuery(userId);
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }
        #endregion
        #region GetUserInfoById
        [HttpGet("GetById/{id:int}")]
        [ProducesResponseType(typeof(GetUserInfoByIdDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetUserInfoByIdDto>> GetUserInfoById(int id)
        {
            var query = new GetUserInfoByIdQuery(id);
            var userInfo = await _mediator.Send(query);
            return Ok(userInfo);
        }
        #endregion
        #region AddUserInfo

        [HttpPost("Add")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddUserInfo([FromBody] AddUserInfoCommand command)
        {
            if (!await _postService.CheckPostalCodeLen(int.Parse(command.PostalCode)))
                return BadRequest();

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        #endregion
        #region UpdateUserInfo

        [HttpPut("Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> UpdateUserInfo([FromBody] UpdateUserInfoCommand command)
        {
            if (!await _postService.CheckPostalCodeLen(int.Parse(command.PostalCode)))
                return BadRequest();

            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }

        #endregion
        #region DeleteUserInfo

        [HttpDelete("Delete/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> DeleteUserInfo(int id)
        {
            var result = await _mediator.Send(new DeleteUserInfoCommand() { Id = id });

            if (result)
                return Ok();

            return BadRequest();
        }

        #endregion

    }
}
