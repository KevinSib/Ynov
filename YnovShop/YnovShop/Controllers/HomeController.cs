using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Business;
using YnovShop.Models;
using YnovShop.Provider;

namespace YnovShop.Controllers
{
    public class HomeController : Controller
    {
        #region Variables



        #endregion

        #region Constructor

        public HomeController()
        {
            
        }

        #endregion

        #region Routes / Actions

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var salt = new SaltProvider().GetSalt();
            var passwordHash = new PasswordProvider().PasswordHash("azerty", salt);
            ViewData["Salt"] = Convert.ToBase64String(salt);
            ViewData["PasswordHash"] = Convert.ToBase64String(passwordHash);
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
