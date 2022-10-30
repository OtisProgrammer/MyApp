using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserInfo.Commands.AddUserInfo
{
    public class AddUserInfoCommandHandler : IRequestHandler<AddUserInfoCommand, int>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public AddUserInfoCommandHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(AddUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfoEntity = _mapper.Map<Domain.Entities.UserInfo>(request);
            var newUserInfo = await _userInfoRepository.AddAsync(userInfoEntity);
            return newUserInfo.Id;
        }
    }
}
