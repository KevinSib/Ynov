using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Data;
using YnovShop.Data.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YnovShop.Controllers
{
    public class BaseController : Controller
    {
        #region Variables

        protected readonly IUserRepository _userRepository;

        #endregion

        #region Constructors

        public BaseController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion

        #region Methods

        protected YUser GetCurrentUser()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this._userRepository.GetById(Int32.Parse(userId));

            return user;
        }

        #endregion
    }
}
