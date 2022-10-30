using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Helpers.Utility.Security;

namespace User.Application.Features.User.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            request.PassWord = PasswordHelper.EncodePasswordSha256(request.PassWord);
            var userEntity = _mapper.Map<Domain.Entities.User>(request);
            var newUser = await _userRepository.AddAsync(userEntity);
            return newUser.Id;
        }
    }
}
