using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using User.Application.Features.User.Commands.AddUser;
using User.Application.Features.User.Commands.UpdateUser;
using User.Application.Features.User.Queries.GetAllUser;
using User.Application.Features.User.Queries.GetUserById;
using User.Application.Features.UserInfo.Commands.AddUserInfo;
using User.Application.Features.UserInfo.Commands.UpdateUserInfo;
using User.Application.Features.UserInfo.Queries.GetAllUserInfoByUserId;
using User.Application.Features.UserInfo.Queries.GetUserInfoById;

namespace User.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<Domain.Entities.User, GetAllUserDto>().ReverseMap();
            CreateMap<Domain.Entities.User, GetUserByIdDto>().ReverseMap();
            CreateMap<Domain.Entities.User, AddUserCommand>().ReverseMap();
            CreateMap<Domain.Entities.User, UpdateUserCommand>().ReverseMap();
            #endregion

            #region Product
            CreateMap<Domain.Entities.UserInfo, GetAllUserInfoByUserIdDto>().ReverseMap();
            CreateMap<Domain.Entities.UserInfo, GetUserInfoByIdDto>().ReverseMap();
            CreateMap<Domain.Entities.UserInfo, AddUserInfoCommand>().ReverseMap();
            CreateMap<Domain.Entities.UserInfo, UpdateUserInfoCommand>().ReverseMap();
#endregion
        }
    }
}
