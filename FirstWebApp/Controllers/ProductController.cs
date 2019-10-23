﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductRepository repo = new ProductRepository();
            List<Product> products = repo.GetAllProducts();

            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            ProductRepository repo = new ProductRepository();
            Product product = repo.GetProduct(id);

            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            ProductRepository repo = new ProductRepository();
            Product prod = repo.GetProduct(id);

            repo.UpdateProduct(prod);

            if(prod == null)
            {
                return View("OroductNotFound");
            }

            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            ProductRepository repo = new ProductRepository();
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ID });
        }

        public IActionResult InsertProduct(Product product)
        {
            ProductRepository repo = new ProductRepository();
            repo
        }
    }
}