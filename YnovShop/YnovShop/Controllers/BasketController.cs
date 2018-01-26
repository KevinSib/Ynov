using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Data;
using YnovShop.Business;
using YnovShop.Models;
using YnovShop.Data.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YnovShop.Controllers
{
    public class BasketController : BaseController
    {
        #region Variables

        private readonly IBasketRepository _basketRepository;
        private readonly IBasketService _basketService;
        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public BasketController(IBasketRepository basketRepository, 
                                IBasketService basketService, 
                                IUserRepository userRepo,
                                IProductRepository productRepo) : base(userRepo)
        {
            this._basketRepository = basketRepository;
            this._basketService = basketService;
            this._productRepository = productRepo;
        }

        #endregion

        #region Routes / Methods

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            var baskets = this._basketRepository.GetActiveBasketForUser(GetCurrentUser());

            return View(baskets);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddToBasket(int? id)
        {
            if (id != null)
            {
                YProduct product = this._productRepository.GetById((int)id);
                if (product != null)
                {
                    this._basketService.AddProductToBasket(GetCurrentUser(), product);
                }
            }
            return Redirect("/Basket/Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult ValideBasket()
        {
            this._basketService.ValideBasket(GetCurrentUser());

            return Redirect("/Basket/Index");
        }

        #endregion
    }
}
