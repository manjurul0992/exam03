using exam03.Models;
using exam03.Models.GameVM;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exam03.Controllers
{
    public class CategoriesController : Controller
    {
        private exam03Entities db = new exam03Entities();
        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "CId", "CName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category cate)
        {
            if (ModelState.IsValid)
            {
                
                    Category category = new Category
                    {
                       CName=cate.CName
                    };
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return PartialView("_success");
                
            }
            ViewBag.categories = new SelectList(db.Categories, "CId", "CName");
            return PartialView("_error");
        }
        
    }
}