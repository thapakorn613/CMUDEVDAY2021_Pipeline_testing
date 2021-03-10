using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMUDevday2021.Model.entity
{
    public class User
    {
        public User()
        { 
        }
        public int UserId { get; set; }
        public String UserName { get; set; }
        public String Account { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
