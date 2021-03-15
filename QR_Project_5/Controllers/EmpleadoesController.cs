using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QR_Project_5.Models;

namespace QR_Project_5.Controllers
{
    [Authorize]
    public class EmpleadoesController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.AspNetUsers).Include(e => e.Departamento1).Include(e => e.Direccion).Include(e => e.Estado_Cliente).Include(e => e.Sucursal).Include(e => e.Tipo_Identificacion);
            return View(empleado.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion");
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion");
            ViewBag.Id_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion");
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Empleado,Id_Tipo_Identificacion,Identificacion,Nombre,Apellido,Id_Estado_Cliente,Id_Direccion,Fecha_Ingreso,Telefono,Id_UserName,Id_Sucursal,ID_Departamento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", empleado.Id_UserName);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", empleado.ID_Departamento);
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion", empleado.Id_Direccion);
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion", empleado.Id_Estado_Cliente);
            ViewBag.Id_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", empleado.Id_Sucursal);
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion", empleado.Id_Tipo_Identificacion);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", empleado.Id_UserName);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", empleado.ID_Departamento);
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion", empleado.Id_Direccion);
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion", empleado.Id_Estado_Cliente);
            ViewBag.Id_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", empleado.Id_Sucursal);
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion", empleado.Id_Tipo_Identificacion);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Empleado,Id_Tipo_Identificacion,Identificacion,Nombre,Apellido,Id_Estado_Cliente,Id_Direccion,Fecha_Ingreso,Telefono,Id_UserName,Id_Sucursal,ID_Departamento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", empleado.Id_UserName);
            ViewBag.ID_Departamento = new SelectList(db.Departamento, "ID_Departamento", "Nombre", empleado.ID_Departamento);
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion", empleado.Id_Direccion);
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion", empleado.Id_Estado_Cliente);
            ViewBag.Id_Sucursal = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", empleado.Id_Sucursal);
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion", empleado.Id_Tipo_Identificacion);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

             Empleado empleado = db.Empleado.Find(id);

            var user = await UserManager.FindByEmailAsync(empleado.Id_UserName);
            var roles = await UserManager.GetRolesAsync(user.Id);
            foreach(var role in roles.ToList())
            {
                var r = await UserManager.RemoveFromRoleAsync(user.Id, role);
            }
            var rc = await UserManager.DeleteAsync(user);
            db.Empleado.Remove(empleado);
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
