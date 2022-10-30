using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserInfo.Queries.GetAllUserInfoByUserId
{
    public class GetAllUserInfoByUserIdQueryHandler : IRequestHandler<GetAllUserInfoByUserIdQuery, List<GetAllUserInfoByUserIdDto>>
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public GetAllUserInfoByUserIdQueryHandler(IUserInfoRepository userInfoRepository, IMapper mapper)
        {
            _userInfoRepository = userInfoRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllUserInfoByUserIdDto>> Handle(GetAllUserInfoByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            var userInfoList = await _userInfoRepository.GetAllByUserId(request.UserId);
            return _mapper.Map<List<GetAllUserInfoByUserIdDto>>(userInfoList);
        }
    }
}
