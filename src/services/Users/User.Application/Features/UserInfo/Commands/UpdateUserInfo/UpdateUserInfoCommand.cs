﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace User.Application.Features.UserInfo.Commands.UpdateUserInfo
{
    public class UpdateUserInfoCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
    }
}
