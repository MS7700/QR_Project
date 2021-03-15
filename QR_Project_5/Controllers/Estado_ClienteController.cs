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
    public class Estado_ClienteController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Estado_Cliente
        public ActionResult Index()
        {
            return View(db.Estado_Cliente.ToList());
        }

        // GET: Estado_Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Cliente estado_Cliente = db.Estado_Cliente.Find(id);
            if (estado_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(estado_Cliente);
        }

        // GET: Estado_Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado_Cliente,Descripcion")] Estado_Cliente estado_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Cliente.Add(estado_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Cliente);
        }

        // GET: Estado_Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Cliente estado_Cliente = db.Estado_Cliente.Find(id);
            if (estado_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(estado_Cliente);
        }

        // POST: Estado_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado_Cliente,Descripcion")] Estado_Cliente estado_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Cliente);
        }

        // GET: Estado_Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Cliente estado_Cliente = db.Estado_Cliente.Find(id);
            if (estado_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(estado_Cliente);
        }

        // POST: Estado_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Cliente estado_Cliente = db.Estado_Cliente.Find(id);
            db.Estado_Cliente.Remove(estado_Cliente);
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
