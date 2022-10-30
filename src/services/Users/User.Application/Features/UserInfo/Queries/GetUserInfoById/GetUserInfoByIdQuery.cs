using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace User.Application.Features.UserInfo.Queries.GetUserInfoById
{
   public class GetUserInfoByIdQuery:IRequest<GetUserInfoByIdDto>
    {
        public int Id { get; set; }

        public GetUserInfoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
