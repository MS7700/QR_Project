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
    public class TransaccionsController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Transaccions
        public ActionResult Index()
        {
            var transaccion = db.Transaccion.Include(t => t.Cliente).Include(t => t.Empleado).Include(t => t.Estado_Transaccion);
            return View(transaccion.ToList());
        }

        // GET: Transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        public ActionResult Create()
        {
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion");
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion");
            return View();
        }

        // POST: Transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Transaccion,ID_Cliente,Fecha,ID_Estado_Transaccion,Monto,Id_Empleado")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", transaccion.ID_Cliente);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", transaccion.Id_Empleado);
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion", transaccion.ID_Estado_Transaccion);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", transaccion.ID_Cliente);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", transaccion.Id_Empleado);
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion", transaccion.ID_Estado_Transaccion);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Transaccion,ID_Cliente,Fecha,ID_Estado_Transaccion,Monto,Id_Empleado")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", transaccion.ID_Cliente);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", transaccion.Id_Empleado);
            ViewBag.ID_Estado_Transaccion = new SelectList(db.Estado_Transaccion, "ID_Estado_Transaccion", "Descripcion", transaccion.ID_Estado_Transaccion);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
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
