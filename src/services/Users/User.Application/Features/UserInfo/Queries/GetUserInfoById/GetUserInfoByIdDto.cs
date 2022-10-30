using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.UserInfo.Queries.GetUserInfoById
{
    public class GetUserInfoByIdDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
