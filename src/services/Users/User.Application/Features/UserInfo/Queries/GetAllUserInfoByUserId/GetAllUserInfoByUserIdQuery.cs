using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace User.Application.Features.UserInfo.Queries.GetAllUserInfoByUserId
{
    public class GetAllUserInfoByUserIdQuery : IRequest<List<GetAllUserInfoByUserIdDto>>
    {
        public int UserId { get; set; }
        public GetAllUserInfoByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
