using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopEcommerceDemo.core.Models;
using MyShopEcommerceDemo.DataAccess.Inmemory;

namespace MyShopEcommerceDemo.UI.Controllers
{
    
    public class ProductManagementController : Controller
    {
        ProductRepository context;
        public ProductManagementController()
        {
            context = new ProductRepository();
        }
        
        // GET: ProductManagement
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult create(Product p)
        {
            if(!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                context.insert(p);
                context.commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Product p = context.find(id);
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
        public ActionResult Edit(Product p,string id)
        {
            Product pe = context.find(id);
            if(!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {
                pe.category = p.category;
                pe.description = p.description;
                pe.name = p.name;
                pe.price = p.price;
                pe.image = p.image;

                context.commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            Product p = context.find(id);
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
            Product p = context.find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.delete(id);
                context.commit();
                return RedirectToAction("Index");
            }
        }

    }
}