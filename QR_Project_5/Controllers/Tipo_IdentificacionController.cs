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
    public class Tipo_IdentificacionController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Tipo_Identificacion
        public ActionResult Index()
        {
            return View(db.Tipo_Identificacion.ToList());
        }

        // GET: Tipo_Identificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Identificacion tipo_Identificacion = db.Tipo_Identificacion.Find(id);
            if (tipo_Identificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Identificacion);
        }

        // GET: Tipo_Identificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Identificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tipo_Identificacion,Descripcion")] Tipo_Identificacion tipo_Identificacion)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Identificacion.Add(tipo_Identificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Identificacion);
        }

        // GET: Tipo_Identificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Identificacion tipo_Identificacion = db.Tipo_Identificacion.Find(id);
            if (tipo_Identificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Identificacion);
        }

        // POST: Tipo_Identificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tipo_Identificacion,Descripcion")] Tipo_Identificacion tipo_Identificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Identificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Identificacion);
        }

        // GET: Tipo_Identificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Identificacion tipo_Identificacion = db.Tipo_Identificacion.Find(id);
            if (tipo_Identificacion == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Identificacion);
        }

        // POST: Tipo_Identificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Identificacion tipo_Identificacion = db.Tipo_Identificacion.Find(id);
            db.Tipo_Identificacion.Remove(tipo_Identificacion);
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
