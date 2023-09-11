using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDBFirst.Models;

namespace DemoDBFirst.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            // test Transaction
            //using (var context = new EFDBFristEntities())
            //{
            //    context.Database.Log = Console.Write;
            //    using (DbContextTransaction transaction = context.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            var category = context.Categories.Add(new Category() { categoryName = "Name3" });

            //            context.Products.Add(new Product()
            //            {
            //                productName = "Name2",
            //                categoryID = category.categoryID
            //            });
            //            context.SaveChanges();
            //            transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            transaction.Rollback();
            //            Console.WriteLine("Error occurred.");
            //        }
            //    }
            //}
            EFDBFristEntities db = new EFDBFristEntities();
            List<Category> categories =db.Categories.ToList();
            return View(categories);
        }

        //view code Transaction
        public ActionResult TestAdd()
        {
            using (var context = new EFDBFristEntities())
            {
                context.Database.Log = Console.Write;
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var category = context.Categories.Add(new Category() { categoryName = "Name3" });

                        context.Products.Add(new Product()
                        {
                            productName = "Name2",
                            categoryID = category.categoryID
                        });
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
            return View();
        }

        //view code Concurrency
        public ActionResult Update()
        {
            Product product = null;
            using (var context = new EFDBFristEntities())
            {
                product = context.Products.First();
            }
            using (var context = new EFDBFristEntities())
            {
                try
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();

                    return RedirectToAction("Index", "Categories");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Concurrency Exception Occurred.");
                }
            }
            return View();
        }
    }
}