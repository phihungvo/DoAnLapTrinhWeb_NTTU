using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CellPhoneX_2100009273.Models;

namespace CellPhoneX_2100009273.Areas.Admin.Controllers
{
    public class RoleMastersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/RoleMasters
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.RoleMasters.ToList());
        }

        // GET: Admin/RoleMasters/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleMaster roleMaster = db.RoleMasters.Find(id);
            if (roleMaster == null)
            {
                return HttpNotFound();
            }
            return View(roleMaster);
        }

        // GET: Admin/RoleMasters/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoleMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RollName")] RoleMaster roleMaster)
        {
            if (ModelState.IsValid)
            {
                db.RoleMasters.Add(roleMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleMaster);
        }

        // GET: Admin/RoleMasters/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleMaster roleMaster = db.RoleMasters.Find(id);
            if (roleMaster == null)
            {
                return HttpNotFound();
            }
            return View(roleMaster);
        }

        // POST: Admin/RoleMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RollName")] RoleMaster roleMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleMaster);
        }

        // GET: Admin/RoleMasters/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleMaster roleMaster = db.RoleMasters.Find(id);
            if (roleMaster == null)
            {
                return HttpNotFound();
            }
            return View(roleMaster);
        }

        // POST: Admin/RoleMasters/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleMaster roleMaster = db.RoleMasters.Find(id);
            db.RoleMasters.Remove(roleMaster);
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
