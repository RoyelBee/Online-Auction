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
    public class BidController : Controller
    {
        private auctionEntities db = new auctionEntities();

        // GET: Bid
        public ActionResult Index()
        {
            var tbl_Bid = db.tbl_Bid.Include(t => t.tbl_Property);
            return View(tbl_Bid.ToList());
        }

        // GET: Bid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Bid tbl_Bid = db.tbl_Bid.Find(id);
            if (tbl_Bid == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Bid);
        }

        // GET: Bid/Create
        public ActionResult Create()
        {
            ViewBag.PropertyID = new SelectList(db.tbl_Property, "P_ID", "Type");
            return View();
        }

        // POST: Bid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "B_ID,Price,Time,PropertyID")] tbl_Bid tbl_Bid)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Bid.Add(tbl_Bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyID = new SelectList(db.tbl_Property, "P_ID", "Type", tbl_Bid.PropertyID);
            return View(tbl_Bid);
        }

        // GET: Bid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Bid tbl_Bid = db.tbl_Bid.Find(id);
            if (tbl_Bid == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyID = new SelectList(db.tbl_Property, "P_ID", "Type", tbl_Bid.PropertyID);
            return View(tbl_Bid);
        }

        // POST: Bid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "B_ID,Price,Time,PropertyID")] tbl_Bid tbl_Bid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Bid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyID = new SelectList(db.tbl_Property, "P_ID", "Type", tbl_Bid.PropertyID);
            return View(tbl_Bid);
        }

        // GET: Bid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Bid tbl_Bid = db.tbl_Bid.Find(id);
            if (tbl_Bid == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Bid);
        }

        // POST: Bid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Bid tbl_Bid = db.tbl_Bid.Find(id);
            db.tbl_Bid.Remove(tbl_Bid);
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
