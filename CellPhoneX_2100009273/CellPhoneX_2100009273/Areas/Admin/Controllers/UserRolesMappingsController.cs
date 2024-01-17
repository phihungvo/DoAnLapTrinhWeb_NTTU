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
    public class UserRolesMappingsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/UserRolesMappings
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userRolesMappings = db.UserRolesMappings.Include(u => u.RoleMaster).Include(u => u.User);
            return View(userRolesMappings.ToList());
        }

        // GET: Admin/UserRolesMappings/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRolesMapping userRolesMapping = db.UserRolesMappings.Find(id);
            if (userRolesMapping == null)
            {
                return HttpNotFound();
            }
            return View(userRolesMapping);
        }

        // GET: Admin/UserRolesMappings/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.RoleMasters, "ID", "RollName");
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: Admin/UserRolesMappings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,RoleID")] UserRolesMapping userRolesMapping)
        {
            if (ModelState.IsValid)
            {
                db.UserRolesMappings.Add(userRolesMapping);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.RoleMasters, "ID", "RollName", userRolesMapping.RoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", userRolesMapping.UserID);
            return View(userRolesMapping);
        }

        // GET: Admin/UserRolesMappings/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRolesMapping userRolesMapping = db.UserRolesMappings.Find(id);
            if (userRolesMapping == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.RoleMasters, "ID", "RollName", userRolesMapping.RoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", userRolesMapping.UserID);
            return View(userRolesMapping);
        }

        // POST: Admin/UserRolesMappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,RoleID")] UserRolesMapping userRolesMapping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRolesMapping).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.RoleMasters, "ID", "RollName", userRolesMapping.RoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", userRolesMapping.UserID);
            return View(userRolesMapping);
        }

        // GET: Admin/UserRolesMappings/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRolesMapping userRolesMapping = db.UserRolesMappings.Find(id);
            if (userRolesMapping == null)
            {
                return HttpNotFound();
            }
            return View(userRolesMapping);
        }

        // POST: Admin/UserRolesMappings/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRolesMapping userRolesMapping = db.UserRolesMappings.Find(id);
            db.UserRolesMappings.Remove(userRolesMapping);
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
