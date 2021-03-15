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
    public class ClientesController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Clientes
        [Authorize(Roles = "Admin,Empleado")]
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.AspNetUsers).Include(c => c.Direccion).Include(c => c.Estado_Cliente).Include(c => c.Tipo_Identificacion);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        [Authorize(Roles = "Admin,Empleado")]
        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion");
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion");
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Empleado")]
        public ActionResult Create([Bind(Include = "ID_Cliente,Id_Tipo_Identificacion,Identificacion,Nombre,Apellido,Id_Estado_Cliente,Id_Direccion,Fecha_Ingreso,Telefono,Id_UserName")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", cliente.Id_UserName);
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion", cliente.Id_Direccion);
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion", cliente.Id_Estado_Cliente);
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion", cliente.Id_Tipo_Identificacion);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize(Roles = "Admin,Empleado")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", cliente.Id_UserName);
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion", cliente.Id_Direccion);
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion", cliente.Id_Estado_Cliente);
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion", cliente.Id_Tipo_Identificacion);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Empleado")]
        public ActionResult Edit([Bind(Include = "ID_Cliente,Id_Tipo_Identificacion,Identificacion,Nombre,Apellido,Id_Estado_Cliente,Id_Direccion,Fecha_Ingreso,Telefono,Id_UserName")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_UserName = new SelectList(db.AspNetUsers, "Id", "Email", cliente.Id_UserName);
            ViewBag.Id_Direccion = new SelectList(db.Direccion, "Id_Direccion", "Id_Direccion", cliente.Id_Direccion);
            ViewBag.Id_Estado_Cliente = new SelectList(db.Estado_Cliente, "Id_Estado_Cliente", "Descripcion", cliente.Id_Estado_Cliente);
            ViewBag.Id_Tipo_Identificacion = new SelectList(db.Tipo_Identificacion, "Id_Tipo_Identificacion", "Descripcion", cliente.Id_Tipo_Identificacion);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize(Roles = "Admin,Empleado")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Empleado")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            

            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            Cliente cliente = db.Cliente.Find(id);

            var user = await UserManager.FindByEmailAsync(cliente.Id_UserName);
            var roles = await UserManager.GetRolesAsync(user.Id);
            foreach (var role in roles.ToList())
            {
                var r = await UserManager.RemoveFromRoleAsync(user.Id, role);
            }
            var rc = await UserManager.DeleteAsync(user);


            db.Cliente.Remove(cliente);
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
