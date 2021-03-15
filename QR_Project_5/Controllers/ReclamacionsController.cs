using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QR_Project_5.Models;

namespace QR_Project_5.Controllers
{
    [Authorize]
    public class ReclamacionsController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        const string Empleado = "Empleado";
        const string Cliente = "Cliente";
        const string Admin = "Admin";
        // GET: Reclamacions
        public ActionResult Index()
        {
            List<Reclamacion> reclamacions = new List<Reclamacion>();
            if (User.IsInRole(Admin))
            {

                var reclamacion = db.Reclamacion.Include(q => q.AspNetUsers).Include(q => q.Cliente).Include(q => q.Departamento).Include(q => q.Empleado).Include(q => q.Estado_QR).Include(q => q.Tipo_Reclamacion).Include(q => q.Sucursal);
                reclamacions.AddRange(reclamacion.ToList<Reclamacion>());
            }
            else if (User.IsInRole(Empleado))
            {
                //TODO: Ordenar por estado y prioridad
                string id = User.Identity.GetUserId();
                var Empleado = db.Empleado.Where(e => e.Id_UserName == id).First<Empleado>();
                var Departamento_Representante = db.Departamento.Where(d => d.Id_Empleado_Representante == Empleado.ID_Empleado);
                var reclamacion = db.Reclamacion.Where(
                    q => q.Id_Empleado == Empleado.ID_Empleado
                    || (q.Empleado == null && q.ID_Departamento == Empleado.ID_Departamento && q.ID_Sucursal == Empleado.Id_Sucursal)
                    || (q.Empleado == null && q.ID_Departamento == null && q.ID_Sucursal == Empleado.Id_Sucursal)
                    || (q.Empleado == null && q.ID_Departamento == null && q.ID_Sucursal == null)
                    || (q.Empleado == null && q.ID_Departamento == Empleado.ID_Departamento && q.ID_Sucursal == null)
                    || q.Id_UserName == Empleado.Id_UserName
                    || Departamento_Representante.Contains(q.Departamento));
                reclamacions.AddRange(reclamacion.ToList<Reclamacion>());
            }
            else if (User.IsInRole(Cliente))
            {
                string id = User.Identity.GetUserId();
                var Cliente = db.Cliente.Where(c => c.Id_UserName == id).First<Cliente>();
                var reclamacion = db.Reclamacion.Where(q => q.ID_Cliente == Cliente.ID_Cliente);
                reclamacions.AddRange(reclamacion.ToList<Reclamacion>());
            }
            return View(reclamacions);
        }

        // GET: Reclamacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamacion reclamacion = db.Reclamacion.Find(id);
            if (reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(reclamacion);
        }

        // GET: Reclamacions/Create
        public ActionResult Create()
        {
            if (User.IsInRole(Admin))
            {
                ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email");
                ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion");
                ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
                ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
                ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
                ViewBag.ID_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "ID_Tipo_Reclamacion", "Descripcion");
                ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            }
            else if (User.IsInRole(Empleado))
            {
                string id = User.Identity.GetUserId();
                ViewBag.Id_UserName = id;
                ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion");
                ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
                ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
                ViewBag.ID_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "ID_Tipo_Reclamacion", "Descripcion");
                ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            }
            else if (User.IsInRole(Cliente))
            {
                string id = User.Identity.GetUserId();
                int id_cliente = db.Cliente.Where(c => c.Id_UserName == id).FirstOrDefault<Cliente>().ID_Cliente;
                ViewBag.Id_UserName = id;
                ViewBag.ID_Cliente = id_cliente;
                ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
                ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
                ViewBag.ID_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "ID_Tipo_Reclamacion", "Descripcion");
                ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            }
            return View();
        }

        // POST: Reclamacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Reclamacion,ID_Cliente,Id_UserName,Id_Empleado,ID_Departamento,ID_Tipo_Reclamacion,Fecha,Hora,ID_Estado_QR,Comentario,ID_Sucursal")] Reclamacion reclamacion)
        {
            if (ModelState.IsValid)
            {
                reclamacion.ID_Estado_QR = Estado_QR.GetEstadoByDescripcion(Estado_QR.ABIERTO).ID_Estado_QR;
                reclamacion.Fecha = DateTime.Today;
                reclamacion.Hora = DateTime.Now.TimeOfDay;
                db.Reclamacion.Add(reclamacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", reclamacion.Id_UserName);
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", reclamacion.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", reclamacion.ID_Departamento);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", reclamacion.Id_Empleado);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", reclamacion.ID_Estado_QR);
            ViewBag.ID_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "ID_Tipo_Reclamacion", "Descripcion", reclamacion.ID_Tipo_Reclamacion);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", reclamacion.ID_Sucursal);
            return View(reclamacion);
        }

        // GET: Reclamacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamacion reclamacion = db.Reclamacion.Find(id);
            if (reclamacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", reclamacion.Id_UserName);
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", reclamacion.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", reclamacion.ID_Departamento);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", reclamacion.Id_Empleado);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", reclamacion.ID_Estado_QR);
            ViewBag.ID_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "ID_Tipo_Reclamacion", "Descripcion", reclamacion.ID_Tipo_Reclamacion);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", reclamacion.ID_Sucursal);
            return View(reclamacion);
        }

        // POST: Reclamacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Reclamacion,ID_Cliente,Id_UserName,Id_Empleado,ID_Departamento,ID_Tipo_Reclamacion,Fecha,Hora,ID_Estado_QR,Comentario,ID_Sucursal")] Reclamacion reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", reclamacion.Id_UserName);
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", reclamacion.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", reclamacion.ID_Departamento);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", reclamacion.Id_Empleado);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", reclamacion.ID_Estado_QR);
            ViewBag.ID_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "ID_Tipo_Reclamacion", "Descripcion", reclamacion.ID_Tipo_Reclamacion);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", reclamacion.ID_Sucursal);
            return View(reclamacion);
        }

        // GET: Reclamacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamacion reclamacion = db.Reclamacion.Find(id);
            if (reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(reclamacion);
        }

        // POST: Reclamacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamacion reclamacion = db.Reclamacion.Find(id);
            db.Reclamacion.Remove(reclamacion);
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
