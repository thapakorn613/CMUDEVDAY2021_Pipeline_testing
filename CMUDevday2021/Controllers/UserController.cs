
using CMUDevday2021.Model.entity;
using CMUDevday2021.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMUDevday2021.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IAccountRepository _accountRepository;
        public UserController(IConfiguration configuration, IUserRepository UserRepository, IAccountRepository AccountRepository)
        {
            _userRepository = UserRepository;
            _accountRepository = AccountRepository;
        }

        [HttpGet("v1/Menu")]
        public async Task<IActionResult> getMenu()
        {
            String token = Request.Headers["Authorization"];
            token = token.Split(' ')[1];
            User user = await _accountRepository.getUser(token);
            if (user == null)
            {
                return Unauthorized();
            }
            List<Menu> menus = await _userRepository.getMenu(user.Account);
            return Ok(menus);
        }
    }
}
