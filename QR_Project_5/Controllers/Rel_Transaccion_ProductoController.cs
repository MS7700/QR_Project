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
    public class Rel_Transaccion_ProductoController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Rel_Transaccion_Producto
        public ActionResult Index()
        {
            var rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Include(r => r.Producto).Include(r => r.Transaccion);
            return View(rel_Transaccion_Producto.ToList());
        }

        // GET: Rel_Transaccion_Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            if (rel_Transaccion_Producto == null)
            {
                return HttpNotFound();
            }
            return View(rel_Transaccion_Producto);
        }

        // GET: Rel_Transaccion_Producto/Create
        public ActionResult Create()
        {
            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre");
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion");
            return View();
        }

        // POST: Rel_Transaccion_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Transaccion,ID_Producto,Cantidad_Producto")] Rel_Transaccion_Producto rel_Transaccion_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Rel_Transaccion_Producto.Add(rel_Transaccion_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre", rel_Transaccion_Producto.ID_Producto);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion", rel_Transaccion_Producto.ID_Transaccion);
            return View(rel_Transaccion_Producto);
        }

        // GET: Rel_Transaccion_Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            if (rel_Transaccion_Producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre", rel_Transaccion_Producto.ID_Producto);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion", rel_Transaccion_Producto.ID_Transaccion);
            return View(rel_Transaccion_Producto);
        }

        // POST: Rel_Transaccion_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Transaccion,ID_Producto,Cantidad_Producto")] Rel_Transaccion_Producto rel_Transaccion_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rel_Transaccion_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Producto = new SelectList(db.Producto, "ID_Producto", "Nombre", rel_Transaccion_Producto.ID_Producto);
            ViewBag.ID_Transaccion = new SelectList(db.Transaccion, "ID_Transaccion", "ID_Transaccion", rel_Transaccion_Producto.ID_Transaccion);
            return View(rel_Transaccion_Producto);
        }

        // GET: Rel_Transaccion_Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            if (rel_Transaccion_Producto == null)
            {
                return HttpNotFound();
            }
            return View(rel_Transaccion_Producto);
        }

        // POST: Rel_Transaccion_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rel_Transaccion_Producto rel_Transaccion_Producto = db.Rel_Transaccion_Producto.Find(id);
            db.Rel_Transaccion_Producto.Remove(rel_Transaccion_Producto);
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
