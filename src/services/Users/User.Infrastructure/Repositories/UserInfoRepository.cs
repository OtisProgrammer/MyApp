using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using User.Infrastructure.Persistence.Context;

namespace User.Infrastructure.Repositories
{
    public class UserInfoRepository : RepositoryBase<Domain.Entities.UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(UserContext ctx) : base(ctx)
        {

        }

        public async Task<IEnumerable<UserInfo>> GetAllByUserId(int userId) 
            => await _ctx.UserInfos
                .Where(u => u.UserId == userId)
                .ToListAsync();
    }
}
