using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using TkStore.Core.Models;
using TkStore.DataAccess.InMemory;

namespace TkStore.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository context;
        public CategoryController()
        {
            context = new CategoryRepository();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult Create()
        {
            ProductCategory ProductCategory = new ProductCategory();
            return View(ProductCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory ProductCategory)
        {
            if (ModelState.IsValid)
            {
                return View(ProductCategory);
            }
            else
            {
                context.Insert(ProductCategory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string ID)
        {
            ProductCategory productCategory = context.Find(ID);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        public ActionResult Edit(ProductCategory productCategory, string ID)
        {
            ProductCategory ProductCategory = context.Find(ID);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCategory.Category = productCategory.Category;

                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string ID)
        {
            ProductCategory categoryToDelete = context.Find(ID);
            if (categoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string ID)
        {
            ProductCategory categoryToDelete = context.Find(ID);
            if (categoryToDelete == null)
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
