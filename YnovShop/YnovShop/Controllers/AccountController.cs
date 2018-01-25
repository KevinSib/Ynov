﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Business;
using YnovShop.Data;
using YnovShop.Models;

namespace YnovShop.Controllers
{
    public class AccountController : Controller
    {
        #region Variables

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructors

        public AccountController(IUserService userService, IUserRepository userRepository)
        {
            this._userService = userService;
            this._userRepository = userRepository;
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
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                LoginResult loginResult = this._userService.LoginUser(model.Email, model.Password);
                if (loginResult == LoginResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Email)
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync();

            return View();
        }

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = this._userRepository.GetById((int)id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        #endregion
    }
}