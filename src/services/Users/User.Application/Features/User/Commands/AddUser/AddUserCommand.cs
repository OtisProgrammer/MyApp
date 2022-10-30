using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace User.Application.Features.User.Commands.AddUser
{
    public class AddUserCommand:IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
