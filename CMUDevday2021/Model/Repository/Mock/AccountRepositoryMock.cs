using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMUDevday2021.Model.Repository.Mock
{
    public class AccountRepositoryMock : IAccountRepository
    {
        private UserContext _userContext;
        public AccountRepositoryMock(UserContext userContext)
        {
            if (userContext == null)
            {
                throw new System.ArgumentNullException(nameof(userContext));
            }
            _userContext = userContext;
        }
        public async Task<User> getUser(string token)
        {
            User user = null;
            //  ส่ง Token ไป Oauth introspec  

            if (token == "zxcmbndfkglj")
            {
                user = new User();
                user.UserId = 1;
                user.UserName = "User1";
                user.Account = "User1@cmu.ac.th";
                user.Menus = _userContext.Menu.OrderBy(o => o.MenuId).ToList();
            }

            return user;
        }
    }
}
