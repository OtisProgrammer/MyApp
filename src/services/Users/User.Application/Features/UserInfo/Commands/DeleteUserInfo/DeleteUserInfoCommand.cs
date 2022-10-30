using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace User.Application.Features.UserInfo.Commands.DeleteUserInfo
{
    public class DeleteUserInfoCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
