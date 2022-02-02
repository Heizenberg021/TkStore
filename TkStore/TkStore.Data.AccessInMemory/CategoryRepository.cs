using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using TkStore.Core.Models;

namespace TkStore.DataAccess.InMemory
{
    public class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<productCategory> productCategories;
        public CategoryRepository()
        {
            productCategories = cache["categories"] as List<productCategory>;
            if (productCategories == null)
            {
                productCategories = new List<productCategory>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(productCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(productCategory productCategory)
        {
            productCategory categoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("category not found");
            }
        }
        public productCategory Find(string ID)
        {
            productCategory productCategory = productCategories.Find(p => p.Id == ID);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
        public IQueryable<productCategory> Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string ID)
        {
            productCategory categoryToDelete = productCategories.Find(p => p.Id == ID);
            if (categoryToDelete != null)
            {
                productCategories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
    }
}
