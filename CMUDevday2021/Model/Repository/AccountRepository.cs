using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMUDevday2021.Model.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private UserContext _userContext;
        public AccountRepository(UserContext userContext)
        {
            if (userContext == null)
            {
                throw new System.ArgumentNullException(nameof(userContext));
            }
            _userContext = userContext;
        }

        public async Task<User> getUser(string token)
        {
            User user = new User();
            //  ส่ง Token ไป Oauth introspec  

            return user;
        }
    }
}
