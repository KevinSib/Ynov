using System.Threading.Tasks;
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

        private IUserService _userService;
        private IUserRepository _userRepository;

        #endregion

        public AccountController(IUserService userService, IUserRepository userRepository)
        {
            this._userService = userService;
            this._userRepository = userRepository;
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

        // GET: Users/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = this._userRepository.GetById((int) id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
    }
}