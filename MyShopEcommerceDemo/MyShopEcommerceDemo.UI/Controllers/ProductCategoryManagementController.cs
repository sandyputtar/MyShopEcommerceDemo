using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopEcommerceDemo.core.Models;
using MyShopEcommerceDemo.DataAccess.Inmemory;

namespace MyShopEcommerceDemo.UI.Controllers
{
    public class ProductCategoryManagementController : Controller
    {
        InMemoryRepository<ProductCategory> context;
        public ProductCategoryManagementController()
        {
            context = new InMemoryRepository<ProductCategory>();
        }
        
        // GET: ProductManagement
        public ActionResult Index()
        {
            List<ProductCategory> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult create()
        {
            ProductCategory p = new ProductCategory();
            return View(p);
        }
        [HttpPost]
        public ActionResult create(ProductCategory p)
        {
            if(!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                context.Insert(p);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            ProductCategory p = context.Find(id);
            if(p==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(p);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory p,string id)
        {
            ProductCategory pe = context.Find(id);
            if(!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                pe.category = p.category;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            ProductCategory p = context.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(p);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            ProductCategory p = context.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");
            }
        } 
        
   

    }
}