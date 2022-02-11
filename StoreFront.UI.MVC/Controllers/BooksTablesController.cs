using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA.EF;

namespace StoreFront.UI.MVC.Controllers
{
    public class BooksTablesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: BooksTables
        public ActionResult Index()
        {
            var booksTables = db.BooksTables.Include(b => b.AuthorTable).Include(b => b.GenreIDTable).Include(b => b.Publisher1).Include(b => b.Stock);
            return View(booksTables.ToList());
        }

        // GET: BooksTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksTable booksTable = db.BooksTables.Find(id);
            if (booksTable == null)
            {
                return HttpNotFound();
            }
            return View(booksTable);
        }

        // GET: BooksTables/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.AuthorTables, "AuthorID", "FName");
            ViewBag.GenreID = new SelectList(db.GenreIDTables, "GenreID", "GenreType");
            ViewBag.Publisher = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockType");
            return View();
        }

        // POST: BooksTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,BooksTitle,GenreID,AuthorID,Price,UnitsSold,PublishDate,Publisher,StockID,CategoryID")] BooksTable booksTable)
        {
            if (ModelState.IsValid)
            {
                db.BooksTables.Add(booksTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.AuthorTables, "AuthorID", "FName", booksTable.AuthorID);
            ViewBag.GenreID = new SelectList(db.GenreIDTables, "GenreID", "GenreType", booksTable.GenreID);
            ViewBag.Publisher = new SelectList(db.Publishers, "PublisherID", "PublisherName", booksTable.Publisher);
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockType", booksTable.StockID);
            return View(booksTable);
        }

        // GET: BooksTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksTable booksTable = db.BooksTables.Find(id);
            if (booksTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.AuthorTables, "AuthorID", "FName", booksTable.AuthorID);
            ViewBag.GenreID = new SelectList(db.GenreIDTables, "GenreID", "GenreType", booksTable.GenreID);
            ViewBag.Publisher = new SelectList(db.Publishers, "PublisherID", "PublisherName", booksTable.Publisher);
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockType", booksTable.StockID);
            return View(booksTable);
        }

        // POST: BooksTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BooksTitle,GenreID,AuthorID,Price,UnitsSold,PublishDate,Publisher,StockID,CategoryID")] BooksTable booksTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booksTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.AuthorTables, "AuthorID", "FName", booksTable.AuthorID);
            ViewBag.GenreID = new SelectList(db.GenreIDTables, "GenreID", "GenreType", booksTable.GenreID);
            ViewBag.Publisher = new SelectList(db.Publishers, "PublisherID", "PublisherName", booksTable.Publisher);
            ViewBag.StockID = new SelectList(db.Stocks, "StockID", "StockType", booksTable.StockID);
            return View(booksTable);
        }

        // GET: BooksTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksTable booksTable = db.BooksTables.Find(id);
            if (booksTable == null)
            {
                return HttpNotFound();
            }
            return View(booksTable);
        }

        // POST: BooksTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BooksTable booksTable = db.BooksTables.Find(id);
            db.BooksTables.Remove(booksTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
