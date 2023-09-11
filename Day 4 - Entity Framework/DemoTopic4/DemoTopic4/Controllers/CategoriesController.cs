using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoTopic4.Models;

namespace DemoTopic4.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            CodeDBContext db = new CodeDBContext();
            List<Category> categories = db.categories.ToList();
            return View(categories);
        }
    }
}