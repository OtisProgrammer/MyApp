using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User.Infrastructure.Persistence.Context;

namespace User.Infrastructure.Persistence.ContextSeed
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(UserContext userContext, ILogger<UserContextSeed> logger)
        {
            try
            {
                //cheek for ny user
                if (!await userContext.Users.AnyAsync())
                {
                    //add single user
                    var user = GetPreconfiguredUser();
                    await userContext.Users.AddAsync(user);
                    await userContext.SaveChangesAsync();

                    //add single info for user
                    var userInfo = GetPreconfiguredUserInfo(user.Id);
                    await userContext.UserInfos.AddAsync(userInfo);
                    await userContext.SaveChangesAsync();

                    //log for seed
                    logger.LogInformation("data seed section configured");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("data seed section not configured");
            }


        }

        public static Domain.Entities.User GetPreconfiguredUser()
        {
            return new Domain.Entities.User
            {
                FirstName = "ali",
                LastName = "asgari",
                Mobile = "09368545338",
                UserName = "ali.asgari",
                PassWord = "123455678"
            };
        }
        public static Domain.Entities.UserInfo GetPreconfiguredUserInfo(int userId)
        {
            return new Domain.Entities.UserInfo()
            {
                UserId = userId,
                PostalCode = "1111111111",
                Address = "کرج-شهرک جهان نما"
            };
        }
    }
}
