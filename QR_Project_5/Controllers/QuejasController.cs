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
    public class QuejasController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        const string Empleado = "Empleado";
        const string Cliente = "Cliente";
        const string Admin = "Admin";
        // GET: Quejas

        [Authorize]
        public ActionResult Index()
        {
            List<Queja> quejas = new List<Queja>();
            if (User.IsInRole(Admin))
            {

                var queja = db.Queja.Include(q => q.AspNetUsers).Include(q => q.Cliente).Include(q => q.Departamento).Include(q => q.Empleado).Include(q => q.Estado_QR).Include(q => q.Tipo_Queja).Include(q => q.Sucursal);
                quejas.AddRange(queja.ToList<Queja>());
            }
            else if (User.IsInRole(Empleado))
            {
                //TODO: Ordenar por estado y prioridad
                string id = User.Identity.GetUserId();
                var Empleado = db.Empleado.Where(e => e.Id_UserName == id).First<Empleado>();
                var Departamento_Representante = db.Departamento.Where(d => d.Id_Empleado_Representante == Empleado.ID_Empleado);
                var queja = db.Queja.Where(
                    q => q.Id_Empleado == Empleado.ID_Empleado
                    || (q.Empleado == null && q.ID_Departamento == Empleado.ID_Departamento && q.ID_Sucursal == Empleado.Id_Sucursal)
                    || (q.Empleado == null && q.ID_Departamento == null && q.ID_Sucursal == Empleado.Id_Sucursal)
                    || (q.Empleado == null && q.ID_Departamento == null && q.ID_Sucursal == null)
                    || (q.Empleado == null && q.ID_Departamento == Empleado.ID_Departamento && q.ID_Sucursal == null)
                    || q.Id_UserName == Empleado.Id_UserName
                    || Departamento_Representante.Contains(q.Departamento));
                quejas.AddRange(queja.ToList<Queja>());
            }
            else if (User.IsInRole(Cliente))
            {
                string id = User.Identity.GetUserId();
                var Cliente = db.Cliente.Where(c => c.Id_UserName == id).First<Cliente>();
                var queja = db.Queja.Where(q => q.ID_Cliente == Cliente.ID_Cliente);
                quejas.AddRange(queja.ToList<Queja>());
            }
            return View(quejas);
        }



        // GET: Quejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queja queja = db.Queja.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // GET: Quejas/Create
        public ActionResult Create()
        {
            if (User.IsInRole(Admin))
            {
                ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email");
                ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion");
                ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
                ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
                ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
                ViewBag.ID_Tipo_Queja = new SelectList(db.Tipo_Queja, "ID_Tipo_Queja", "Descripcion");
                ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            }else if (User.IsInRole(Empleado))
            {
                string id = User.Identity.GetUserId();
                ViewBag.Id_UserName = id;
                ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion");
                ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
                ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
                ViewBag.ID_Tipo_Queja = new SelectList(db.Tipo_Queja, "ID_Tipo_Queja", "Descripcion");
                ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            }else if (User.IsInRole(Cliente))
            {
                string id = User.Identity.GetUserId();
                int id_cliente = db.Cliente.Where(c => c.Id_UserName == id).FirstOrDefault<Cliente>().ID_Cliente;
                ViewBag.Id_UserName = id;
                ViewBag.ID_Cliente = id_cliente;
                ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
                ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
                ViewBag.ID_Tipo_Queja = new SelectList(db.Tipo_Queja, "ID_Tipo_Queja", "Descripcion");
                ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            }
            
            return View();
        }

        // POST: Quejas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Queja,ID_Cliente,Id_UserName,Id_Empleado,ID_Departamento,ID_Sucursal,ID_Tipo_Queja,Fecha,Hora,ID_Estado_QR,Comentario")] Queja queja)
        {
            if (ModelState.IsValid)
            {
                queja.ID_Estado_QR = Estado_QR.GetEstadoByDescripcion(Estado_QR.ABIERTO).ID_Estado_QR;
                queja.Fecha = DateTime.Today;
                queja.Hora = DateTime.Now.TimeOfDay;
                db.Queja.Add(queja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", queja.Id_UserName);
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", queja.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", queja.ID_Departamento);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", queja.Id_Empleado);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", queja.ID_Estado_QR);
            ViewBag.ID_Tipo_Queja = new SelectList(db.Tipo_Queja, "ID_Tipo_Queja", "Descripcion", queja.ID_Tipo_Queja);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", queja.ID_Sucursal);
            return View(queja);
        }

        // GET: Quejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queja queja = db.Queja.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", queja.Id_UserName);
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", queja.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", queja.ID_Departamento);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", queja.Id_Empleado);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", queja.ID_Estado_QR);
            ViewBag.ID_Tipo_Queja = new SelectList(db.Tipo_Queja, "ID_Tipo_Queja", "Descripcion", queja.ID_Tipo_Queja);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", queja.ID_Sucursal);
            return View(queja);
        }

        // POST: Quejas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Queja,ID_Cliente,Id_UserName,Id_Empleado,ID_Departamento,ID_Tipo_Queja,Fecha,Hora,ID_Estado_QR,Comentario,ID_Sucursal")] Queja queja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", queja.Id_UserName);
            ViewBag.ID_Cliente = new SelectList(db.Cliente, "ID_Cliente", "Identificacion", queja.ID_Cliente);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", queja.ID_Departamento);
            ViewBag.Id_Empleado = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", queja.Id_Empleado);
            ViewBag.ID_Estado_QR = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", queja.ID_Estado_QR);
            ViewBag.ID_Tipo_Queja = new SelectList(db.Tipo_Queja, "ID_Tipo_Queja", "Descripcion", queja.ID_Tipo_Queja);
            ViewBag.ID_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", queja.ID_Sucursal);
            return View(queja);
        }

        // GET: Quejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queja queja = db.Queja.Find(id);
            if (queja == null)
            {
                return HttpNotFound();
            }
            return View(queja);
        }

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Queja queja = db.Queja.Find(id);
            db.Queja.Remove(queja);
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
