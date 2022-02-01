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
        List<ProductCategory> productCategories;
        public CategoryRepository()
        {
            productCategories = cache["categories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory categoryToUpdate = productCategories.Find(p => p.ID == productCategory.ID);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("category not found");
            }
        }
        public ProductCategory Find(string ID)
        {
            ProductCategory productCategory = productCategories.Find(p => p.ID == ID);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string ID)
        {
            ProductCategory categoryToDelete = productCategories.Find(p => p.ID == ID);
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
