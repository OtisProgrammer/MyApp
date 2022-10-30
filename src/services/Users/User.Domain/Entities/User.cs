using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            UserInfos = new HashSet<UserInfo>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public ICollection<UserInfo> UserInfos { get; set; }
    }
}
