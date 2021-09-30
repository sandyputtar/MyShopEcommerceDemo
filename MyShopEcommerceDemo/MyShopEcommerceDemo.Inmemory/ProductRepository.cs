using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShopEcommerceDemo.core.Models;

namespace MyShopEcommerceDemo.DataAccess.Inmemory
{
   public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }

        }

        public void commit()
        {
            cache["products"] = products;
        }

        public void insert(Product p)
        {
            products.Add(p);
        }

        public void update(Product product)
        {
            Product c = products.Find(p => p.id == product.id);
            if (c != null)
            {
                c = product;
            }
            else
            {
                throw new Exception("Product not found");
            }

        }

        public Product find(string id)
        {
            Product c = products.Find(p => p.id == id);
            if (c != null)
            {
                return c;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
         {
            return products.AsQueryable();
         }

        public void delete(string id)
        {
            Product c = products.Find(p => p.id == id);
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
