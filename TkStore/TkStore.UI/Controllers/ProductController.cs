using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TkStore.Core.Models;
using TkStore.Core.VIewModel;
using TkStore.DataAccess.InMemory;

namespace TkStore.UI.Controllers
{
    public class ProductController : Controller
    {
        InMemoryRepository<Product> context;
        InMemoryRepository<productCategory> productCategories;
        public ProductController()
        {
            context = new InMemoryRepository<Product>();
            productCategories = new InMemoryRepository<productCategory>();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductVM viewModel = new ProductVM();
            viewModel.Product = new Product();
            viewModel.ProductCategories = productCategories.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if( ModelState.IsValid )
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        } 
        public ActionResult Edit(string ID)
        {
            Product product = context.Find(ID);
            if( product == null )
            {
                return HttpNotFound();
            }
            else
            {
                ProductVM viewModel = new ProductVM();
                viewModel.Product = product;
                viewModel.ProductCategories = productCategories.Collection();  
                return View(viewModel);
            }
        }
        public ActionResult Edit(Product product, string ID)
        {
            Product prod = context.Find(ID);
            if( prod == null )
            {
                return HttpNotFound();  
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                prod.Description = product.Description;
                prod.Name = product.Name;
                prod.Category = product.Category;
                prod.Price = product.Price;
                prod.Image = product.Image;
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string ID)
        {
            Product productToDelete = context.Find(ID);
            if(productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            Product productToDelete = context.Find(ID); 
            if(productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(ID);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}