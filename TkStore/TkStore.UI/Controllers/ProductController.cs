using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TkStore.Core.Models;
using TkStore.DataAccess.InMemory;

namespace TkStore.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository context;
        public ProductController()
        {
            context = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
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
    }
}