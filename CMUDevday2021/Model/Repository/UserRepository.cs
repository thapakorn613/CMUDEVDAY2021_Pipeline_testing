using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMUDevday2021.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserContext _userContext;
        public UserRepository(UserContext userContext)
        {
            if (userContext == null)
            {
                throw new System.ArgumentNullException(nameof(userContext));
            }
            _userContext = userContext;
        }
        public async Task<List<Menu>> getMenu(string account)
        {
            List<Menu> menus = new List<Menu>();
            List<Menu> menulist = _userContext.Menu.ToList();
            User user = _userContext.User.Where(w => w.Account == account).FirstOrDefault();
            if (user == null)
            {
                return menus;
            }
            menus = user.Menus;
            return menus;
        }
    }
}
