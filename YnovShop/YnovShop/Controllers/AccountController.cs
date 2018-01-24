using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly ISignManager _signManager;

        #endregion

        #region Constructors

        public AccountController(IUserService userService, IUserRepository userRepository, ISignManager signManager)
        {
            this._userService = userService;
            this._userRepository = userRepository;
            this._signManager = signManager;
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

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await this._signManager.SignInAsync(model.Email, model.Password);
                /*if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }*/
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOut
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await Task.Run(() => {});
            //await _signInManager.SignOutAsync();
            return View();
            //return RedirectToAction(nameof(HomeController.Index), "Home");
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