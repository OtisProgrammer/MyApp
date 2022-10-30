using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Infrastructure.Persistence.Context;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<Domain.Entities.User>, IUserRepository
    {
        public UserRepository(UserContext ctx) : base(ctx)
        {

        }

    }
}
