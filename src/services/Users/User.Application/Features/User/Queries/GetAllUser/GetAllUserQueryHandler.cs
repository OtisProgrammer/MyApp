using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.User.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<GetAllUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllUserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<GetAllUserDto>>(userList);
        }
    }
}
