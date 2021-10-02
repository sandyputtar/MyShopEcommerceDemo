using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShopEcommerceDemo.core.Models;

namespace MyShopEcommerceDemo.DataAccess.Inmemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> products;
        public ProductCategoryRepository()
        {
            products = cache["products"] as List<ProductCategory>;
            if (products == null)
            {
                products = new List<ProductCategory>();
            }

        }

        public void commit()
        {
            cache["products"] = products;
        }

        public void insert(ProductCategory p)
        {
            products.Add(p);
        }

        public void update(ProductCategory product)
        {
            ProductCategory c = products.Find(p => p.id == product.id);
            if (c != null)
            {
                c = product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public ProductCategory find(string id)
        {
            ProductCategory c = products.Find(p => p.id == id);
            if (c != null)
            {
                return c;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return products.AsQueryable();
        }

        public void delete(string id)
        {
            ProductCategory c = products.Find(p => p.id == id);
            if (c != null)
            {
                products.Remove(c);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
