using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.User.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<List<GetAllUserDto>>
    {

    }
}
