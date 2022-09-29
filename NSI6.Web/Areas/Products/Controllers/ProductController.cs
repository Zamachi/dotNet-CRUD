using Microsoft.AspNetCore.Mvc;
using NSI6.Service;
using NSI6.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSI6.Web.Areas.Products.Controllers
{
    [Area("Products")]
    [Route("Products/[controller]/[action]/{id?}")]
    public class ProductController : BaseController
    {
        private IProductsService ProductsService;

        public ProductController(IProductsService productsService)
        {
            ProductsService = productsService;
        }

        [HttpGet]
        public IActionResult readAllProducts()
        {
            var games = ProductsService.readAll(CultureInfo.CurrentCulture.Name);
            return View(games);
        }
        [HttpGet]
        public IActionResult getOneProduct(int id)
        {
            var one_game = ProductsService.GetOne(id, CultureInfo.CurrentCulture.Name);

            return View(one_game);
        }
    }
}
