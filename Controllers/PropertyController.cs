using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.Models;

namespace Auction.Controllers
{
    public class PropertyController : Controller
    {
        private auctionEntities db = new auctionEntities();

        // GET: Property
        public ActionResult Index()
        {
            return View(db.tbl_Property.ToList());
        }

        public ActionResult ProductList()
        {
            return View(db.tbl_Property.ToList());
        }

        // GET: Property/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Property tbl_Property = db.tbl_Property.Find(id);
            if (tbl_Property == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Property);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P_ID,Type,Name,MinPrice,Details")] tbl_Property tbl_Property)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Property.Add(tbl_Property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Property);
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Property tbl_Property = db.tbl_Property.Find(id);
            if (tbl_Property == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Property);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "P_ID,Type,Name,MinPrice,Details")] tbl_Property tbl_Property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Property);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Property tbl_Property = db.tbl_Property.Find(id);
            if (tbl_Property == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Property);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Property tbl_Property = db.tbl_Property.Find(id);
            db.tbl_Property.Remove(tbl_Property);
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
