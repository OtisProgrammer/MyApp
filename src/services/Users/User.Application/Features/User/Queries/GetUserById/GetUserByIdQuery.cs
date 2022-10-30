using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace User.Application.Features.User.Queries.GetUserById
{
   public class GetUserByIdQuery : IRequest<GetUserByIdDto>
   {
       public int Id { get; set; }
       public GetUserByIdQuery(int id)
       {
           Id = id;
       }
   }
}
