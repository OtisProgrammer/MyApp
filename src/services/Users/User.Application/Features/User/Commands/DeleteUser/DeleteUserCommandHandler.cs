using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userForDelete = await _userRepository.GetByIdAsync(request.Id); 
            
            if (userForDelete == null)
                return false;

            return await _userRepository.DeleteAsync(userForDelete);
        }
    }
}
