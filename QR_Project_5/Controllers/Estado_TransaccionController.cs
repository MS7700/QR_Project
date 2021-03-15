﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QR_Project_5.Models;

namespace QR_Project_5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Estado_TransaccionController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Estado_Transaccion
        public ActionResult Index()
        {
            return View(db.Estado_Transaccion.ToList());
        }

        // GET: Estado_Transaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Transaccion estado_Transaccion = db.Estado_Transaccion.Find(id);
            if (estado_Transaccion == null)
            {
                return HttpNotFound();
            }
            return View(estado_Transaccion);
        }

        // GET: Estado_Transaccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado_Transaccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Estado_Transaccion,Descripcion")] Estado_Transaccion estado_Transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Transaccion.Add(estado_Transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Transaccion);
        }

        // GET: Estado_Transaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Transaccion estado_Transaccion = db.Estado_Transaccion.Find(id);
            if (estado_Transaccion == null)
            {
                return HttpNotFound();
            }
            return View(estado_Transaccion);
        }

        // POST: Estado_Transaccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Estado_Transaccion,Descripcion")] Estado_Transaccion estado_Transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Transaccion);
        }

        // GET: Estado_Transaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Transaccion estado_Transaccion = db.Estado_Transaccion.Find(id);
            if (estado_Transaccion == null)
            {
                return HttpNotFound();
            }
            return View(estado_Transaccion);
        }

        // POST: Estado_Transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Transaccion estado_Transaccion = db.Estado_Transaccion.Find(id);
            db.Estado_Transaccion.Remove(estado_Transaccion);
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
