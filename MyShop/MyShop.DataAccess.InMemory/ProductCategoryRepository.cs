using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategoris;


        public ProductCategoryRepository()
        {
            productCategoris = cache["productCategoris"] as List<ProductCategory>;
            if (productCategoris == null)
            {
                productCategoris = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategoris"] = productCategoris;

        }

        public void Insert(ProductCategory pc)
        {
            productCategoris.Add(pc);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategoris.Find(pc => pc.Id == productCategory.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategoris.Find(pc => pc.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategoris.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategoris.Find(pc => pc.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategoris.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }
    }
}

