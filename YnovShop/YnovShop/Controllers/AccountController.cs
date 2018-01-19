using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Business;
using YnovShop.Models;

namespace YnovShop.Controllers
{
    public class AccountController : Controller
    {
        #region Variables

        private IUserService _userService;

        #endregion

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            try
            {
                this._userService.CreateUser(model.Firstname, model.Lastname, model.Email, model.Password);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}