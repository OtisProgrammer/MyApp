using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserInfo.Commands.DeleteUserInfo
{
    public class DeleteUserInfoCommandHandler : IRequestHandler<DeleteUserInfoCommand, bool>
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public DeleteUserInfoCommandHandler(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }
        public async Task<bool> Handle(DeleteUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoForDelete = await _userInfoRepository.GetByIdAsync(request.Id);
            
            if (userInfoForDelete == null)
                return false;

            return await _userInfoRepository.DeleteAsync(userInfoForDelete);
        }
    }
}
