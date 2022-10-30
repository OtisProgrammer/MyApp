using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserInfo.Queries.GetUserInfoById
{
    public class GetUserInfoByIdQueryHandler : IRequestHandler<GetUserInfoByIdQuery, GetUserInfoByIdDto>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public GetUserInfoByIdQueryHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }
        public async Task<GetUserInfoByIdDto> Handle(GetUserInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var userInfo = await _userInfoRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetUserInfoByIdDto>(userInfo);
        }
    }
}
