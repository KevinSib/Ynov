using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Business;
using YnovShop.Data;
using YnovShop.Models;

namespace YnovShop.Controllers
{
    public class AccountController : BaseController
    {
        #region Variables

        private readonly IUserService _userService;

        #endregion

        #region Constructors

        public AccountController(IUserService userService, IUserRepository userRepository) : base(userRepository)
        {
            this._userService = userService;
        }

        #endregion

        #region Routes / Actions

        // GET: Account
        public ActionResult Index()
        {
            var users = this._userRepository.Get();
            return View(users);
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: Account/Register
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            try
            {
                this._userService.CreateUser(model.Firstname, model.Lastname, model.Email, model.Password);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                LoginViewModel result = this._userService.LoginUser(model.Email, model.Password);
                if (result.Result == LoginResult.Success && result.User != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Email),
                        new Claim(ClaimTypes.NameIdentifier, result.User.Id.ToString())
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return Redirect("/");
                }
                else
                {
                    ViewData["ERROR"] = "Can't connect user !!!";
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

        // GET: Users/Details
        [Authorize]
        public IActionResult Details()
        {
            var user = GetCurrentUser();
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        #endregion
    }
}