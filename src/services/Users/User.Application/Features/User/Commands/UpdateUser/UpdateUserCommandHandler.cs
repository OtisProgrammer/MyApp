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

namespace User.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            request.PassWord = PasswordHelper.EncodePasswordSha256(request.PassWord);
            var userForUpdate = await _userRepository.GetByIdAsync(request.Id);
            
            if (userForUpdate == null)
                return false;

            _mapper.Map(request, userForUpdate, typeof(UpdateUserCommand), typeof(Domain.Entities.User));
          
            return await _userRepository.UpdateAsync(userForUpdate);
        }
    }
}
