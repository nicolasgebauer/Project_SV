﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AlienatorsController : Controller
    {
        private BienesRaicesDBEntities db = new BienesRaicesDBEntities();

        // GET: Alienators
        public ActionResult Index()
        {
            var alienators = db.Alienators.Include(a => a.Inscription).Include(a => a.Person);
            return View(alienators.ToList());
        }

        // GET: Alienators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alienator alienator = db.Alienators.Find(id);
            if (alienator == null)
            {
                return HttpNotFound();
            }
            return View(alienator);
        }

        // GET: Alienators/Create
        public ActionResult Create()
        {
            ViewBag.AtentionNumber = new SelectList(db.Inscriptions, "AtentionNumber", "CNE");
            ViewBag.Rut = new SelectList(db.People, "Rut", "Rut");
            return View();
        }

        // POST: Alienators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtentionNumber,Rut,Percentage")] Alienator alienator)
        {
            if (ModelState.IsValid)
            {
                db.Alienators.Add(alienator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtentionNumber = new SelectList(db.Inscriptions, "AtentionNumber", "CNE", alienator.AtentionNumber);
            ViewBag.Rut = new SelectList(db.People, "Rut", "Rut", alienator.Rut);
            return View(alienator);
        }

        // GET: Alienators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alienator alienator = db.Alienators.Find(id);
            if (alienator == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtentionNumber = new SelectList(db.Inscriptions, "AtentionNumber", "CNE", alienator.AtentionNumber);
            ViewBag.Rut = new SelectList(db.People, "Rut", "Rut", alienator.Rut);
            return View(alienator);
        }

        // POST: Alienators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtentionNumber,Rut,Percentage")] Alienator alienator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alienator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtentionNumber = new SelectList(db.Inscriptions, "AtentionNumber", "CNE", alienator.AtentionNumber);
            ViewBag.Rut = new SelectList(db.People, "Rut", "Rut", alienator.Rut);
            return View(alienator);
        }

        // GET: Alienators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alienator alienator = db.Alienators.Find(id);
            if (alienator == null)
            {
                return HttpNotFound();
            }
            return View(alienator);
        }

        // POST: Alienators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alienator alienator = db.Alienators.Find(id);
            db.Alienators.Remove(alienator);
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
