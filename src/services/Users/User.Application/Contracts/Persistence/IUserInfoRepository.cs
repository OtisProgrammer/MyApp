using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Contracts.Persistence
{
    public interface IUserInfoRepository : IAsyncRepository<Domain.Entities.UserInfo>
    {
        Task<IEnumerable<Domain.Entities.UserInfo>> GetAllByUserId(int userId);
    }
}
