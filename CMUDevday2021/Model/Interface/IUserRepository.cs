using CMUDevday2021.Model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMUDevday2021.Model.Interface
{
    public interface IUserRepository
    {
        Task<List<Menu>> getMenu(String account);
    }
}
