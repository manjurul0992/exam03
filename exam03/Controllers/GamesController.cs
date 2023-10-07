using exam03.Models;
using exam03.Models.GameVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exam03.Controllers
{
    public class GamesController : Controller
    {
        private exam03Entities db=new exam03Entities();
        // GET: Games
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.categories = new SelectList(db.Categories, "CId", "CName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameVM gvm)
        {
            if(ModelState.IsValid)
            {
                if(gvm.Picture != null)
                {
                    string filePath=Path.Combine("~/Images",Guid.NewGuid().ToString()+Path.GetExtension(gvm.Picture.FileName));
                    gvm.Picture.SaveAs(Server.MapPath(filePath));
                    Game games = new Game
                    {
                        GameName=gvm.GameName,
                        CId=gvm.CId,
                        Prize=gvm.Prize,
                        PlayDate=gvm.PlayDate,
                        Result=gvm.Result,
                        PicturePath=filePath
                    };
                    db.Games.Add(games);
                    db.SaveChanges();
                    return PartialView("_success");
                }
            }
            ViewBag.categories = new SelectList(db.Categories, "CId", "CName");
            return PartialView("_error");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            GameVM gvm = new GameVM
            {
                Id = game.Id,
                GameName = game.GameName,
                CId = game.CId,
                Prize = game.Prize,
                PlayDate = game.PlayDate,
                Result = game.Result,
                PicturePath = game.PicturePath
            };
            ViewBag.categories = new SelectList(db.Categories, "CId", "CName");
            return View(gvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameVM gvm)
        {
            if (ModelState.IsValid)
            {
                string filePath = gvm.PicturePath;
                if (gvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(gvm.Picture.FileName));
                    gvm.Picture.SaveAs(Server.MapPath(filePath));
                    Game games = new Game
                    {
                        Id = gvm.Id,
                        GameName = gvm.GameName,
                        CId = gvm.CId,
                        Prize = gvm.Prize,
                        PlayDate = gvm.PlayDate,
                        Result = gvm.Result,
                        PicturePath = filePath
                    };
                    db.Entry(games).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();



                    return RedirectToAction("Index");
                }
                else
                {
                    Game games = new Game
                    {
                        Id = gvm.Id,
                        GameName = gvm.GameName,
                        CId = gvm.CId,
                        Prize = gvm.Prize,
                        PlayDate = gvm.PlayDate,
                        Result = gvm.Result,
                        PicturePath = filePath
                    };
                    db.Entry(games).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();



                    return RedirectToAction("Index");
                }
            }
            ViewBag.categories = new SelectList(db.Categories, "CId", "CName");
            return View(gvm);
        }
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Game games = db.Games.Find(id);
            if (games == null)
            {
                return HttpNotFound();
            }
            return View(games);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            Game games =db.Games.Find(id);
            string file_name = games.PicturePath;
            string path=Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if(file.Exists)
            {
                file.Delete();
            }
            db.Games.Remove(games); db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}