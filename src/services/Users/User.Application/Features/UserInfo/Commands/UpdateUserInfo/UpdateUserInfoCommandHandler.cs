using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, bool>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UpdateUserInfoCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoForUpdate = await _userInfoRepository.GetByIdAsync(request.Id);
            
            if (userInfoForUpdate == null)
                return false;

            _mapper.Map(request, userInfoForUpdate, typeof(UpdateUserInfoCommand), typeof(Domain.Entities.UserInfo));
            return await _userInfoRepository.UpdateAsync(userInfoForUpdate);
        }
    }
}
