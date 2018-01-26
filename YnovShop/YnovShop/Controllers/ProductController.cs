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
    public class ProductController : Controller
    {
        #region Variables

        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        #endregion

        #region Constructors

        public ProductController(IProductRepository productRepository, IProductService productService)
        {
            this._productRepository = productRepository;
            this._productService = productService;
        }

        #endregion

        #region Routes / Methods

        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            var products = this._productRepository.GetAvailableProducts();

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

        //  GET: /Products/CreateProduct
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: Products/CreateProduct
        [Authorize]
        [HttpPost]
        public ActionResult CreateProduct(CreateProductModel model){
            try
            {
                this._productService.CreateProduct(model.Name, model.Descritption, model.Stock, model.Price);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        #endregion
    }
}
