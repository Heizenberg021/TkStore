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
        InMemoryRepository<productCategory> context;
        public CategoryController()
        {
            context = new InMemoryRepository<productCategory>();
        }
        // GET: Category
        public ActionResult Index()
        {
            List<productCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult Create()
        {
            productCategory ProductCategory = new productCategory();
            return View(ProductCategory);
        }
        [HttpPost]
        public ActionResult Create(productCategory ProductCategory)
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
            productCategory productCategory = context.Find(ID);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        public ActionResult Edit(productCategory productCategory, string ID)
        {
            productCategory ProductCategory = context.Find(ID);
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
            productCategory categoryToDelete = context.Find(ID);
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
            productCategory categoryToDelete = context.Find(ID);
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
