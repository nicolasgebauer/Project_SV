﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MultypropertiesController : Controller
    {
        private BienesRaicesDBEntities db = new BienesRaicesDBEntities();

        // GET: Multyproperties
        public ActionResult Index(string commune, string block, string site, int? startyear, int? endyear)
        {
            IQueryable<Multyproperty> properties = db.Multyproperties;

            // Verificar si los filtros han sido ingresados y si es así, utilizarlos en la consulta SQL
            if (!string.IsNullOrEmpty(commune) && !string.IsNullOrEmpty(block) && !string.IsNullOrEmpty(site))
            {
                
                properties = properties.Where(p => p.Comunne == commune && p.Block == block && p.Site == site);
            }

            if (startyear.HasValue)
            {
                properties = properties.Where(p => p.StartCurrencyYear >= startyear.Value);
            }

            if (endyear.HasValue)
            {
                properties = properties.Where(p => p.EndCurrencyYear <= endyear.Value);
            }

            return View(properties.ToList());
        }

        // GET: Multyproperties/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multyproperty multyproperty = db.Multyproperties.Find(id);
            if (multyproperty == null)
            {
                return HttpNotFound();
            }
            return View(multyproperty);
        }

        // GET: Multyproperties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Multyproperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Comunne,Block,Site,Rut,Percentage,Page,InscriptionNumber,InscriptionYear,InscriptionDate,StartCurrencyYear,EndCurrencyYear")] Multyproperty multyproperty)
        {
            if (ModelState.IsValid)
            {
                db.Multyproperties.Add(multyproperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(multyproperty);
        }

        // GET: Multyproperties/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multyproperty multyproperty = db.Multyproperties.Find(id);
            if (multyproperty == null)
            {
                return HttpNotFound();
            }
            return View(multyproperty);
        }

        // POST: Multyproperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Comunne,Block,Site,Rut,Percentage,Page,InscriptionNumber,InscriptionYear,InscriptionDate,StartCurrencyYear,EndCurrencyYear")] Multyproperty multyproperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multyproperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(multyproperty);
        }

        // GET: Multyproperties/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multyproperty multyproperty = db.Multyproperties.Find(id);
            if (multyproperty == null)
            {
                return HttpNotFound();
            }
            return View(multyproperty);
        }

        // POST: Multyproperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Multyproperty multyproperty = db.Multyproperties.Find(id);
            db.Multyproperties.Remove(multyproperty);
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
