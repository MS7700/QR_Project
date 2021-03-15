using System;
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
    public class Tipo_QuejaController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Tipo_Queja
        public ActionResult Index()
        {
            return View(db.Tipo_Queja.ToList());
        }

        // GET: Tipo_Queja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Queja tipo_Queja = db.Tipo_Queja.Find(id);
            if (tipo_Queja == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Queja);
        }

        // GET: Tipo_Queja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Queja/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Tipo_Queja,Descripcion")] Tipo_Queja tipo_Queja)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Queja.Add(tipo_Queja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Queja);
        }

        // GET: Tipo_Queja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Queja tipo_Queja = db.Tipo_Queja.Find(id);
            if (tipo_Queja == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Queja);
        }

        // POST: Tipo_Queja/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Tipo_Queja,Descripcion")] Tipo_Queja tipo_Queja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Queja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Queja);
        }

        // GET: Tipo_Queja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Queja tipo_Queja = db.Tipo_Queja.Find(id);
            if (tipo_Queja == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Queja);
        }

        // POST: Tipo_Queja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Queja tipo_Queja = db.Tipo_Queja.Find(id);
            db.Tipo_Queja.Remove(tipo_Queja);
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
