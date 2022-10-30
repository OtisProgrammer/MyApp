using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class UserInfo : EntityBase
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
