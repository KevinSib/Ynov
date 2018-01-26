﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YnovShop.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YnovShop.Controllers
{
    public class ProductController : Controller
    {
        #region Variables

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #endregion

        #region Routes / Methods

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            var products = this._productRepository.Get();
            UserRepository userRepository = new UserRepository(null);
            var user = userRepository.GetById(1);
            return View(products);
        }

        // GET: Products/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = this._productRepository.GetById((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        #endregion
    }
}
