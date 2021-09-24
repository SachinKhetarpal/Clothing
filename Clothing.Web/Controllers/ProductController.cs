using Clothing.Entity;
using Clothing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clothing.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsServices productsService = new ProductsServices();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
       {
            var products = productsService.GetProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }
        //--------------
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Product product = productsService.GetProduct(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {

            productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }
       

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Product product = productsService.GetProduct(ID);
            productsService.DeleteProduct(product);
            return RedirectToAction("ProductTable");
        }
    }
}