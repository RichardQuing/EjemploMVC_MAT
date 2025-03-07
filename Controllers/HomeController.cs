using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EjemploMVC_MAT.Models;
using EjemploMVC_MAT.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EjemploMVC_MAT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int limit = 5;
            var products = await _productService.GetProductsAsync(limit, page);
            ViewBag.CurrentPage = page;
            return View(products);
        }

        public async Task<IActionResult> Details(string driverId)
        {
            if (string.IsNullOrEmpty(driverId))
            {
                return NotFound();
            }

            var product = await _productService.GetProductAsync(driverId);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}