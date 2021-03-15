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
    public class Respuesta_ClienteController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Respuesta_Cliente
        public ActionResult Index()
        {
            var respuesta_Cliente = db.Respuesta_Cliente.Include(r => r.Estado_QR).Include(r => r.Estado_QR1).Include(r => r.Queja).Include(r => r.Reclamacion);
            return View(respuesta_Cliente.ToList());
        }

        // GET: Respuesta_Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Cliente respuesta_Cliente = db.Respuesta_Cliente.Find(id);
            if (respuesta_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Cliente);
        }

        // GET: Respuesta_Cliente/Create
        public ActionResult Create()
        {
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja");
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion");
            return View();
        }

        // POST: Respuesta_Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Respuesta_Cliente,Id_Queja,Id_Reclamacion,ID_Estado_Origen,ID_Estado_Destino,Valoracion,Fecha,Detalle,Hora")] Respuesta_Cliente respuesta_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Respuesta_Cliente.Add(respuesta_Cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Cliente.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Cliente.Id_Reclamacion);
            return View(respuesta_Cliente);
        }




        // GET: Respuesta_Empleado/Create
        public ActionResult CreateFromQueja(int? id)
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
            RespuestaClienteQuejaViewModel viewmodel = new RespuestaClienteQuejaViewModel()
            {
                QuejaViewModel = new QuejaViewModel { Queja = queja, Respuestas = new List<IRespuesta>() },
                Respuesta_Cliente = new Respuesta_Cliente
                {
                    Id_Queja = queja.ID_Queja,
                    ID_Estado_Origen = queja.ID_Estado_QR
                }
            };
            int id_queja = queja.ID_Queja;
            List<Respuesta_Empleado> respuesta_Empleados = db.Respuesta_Empleado.Where(e => e.Id_Queja == id_queja).ToList();
            List<Respuesta_Cliente> respuesta_Clientes = db.Respuesta_Cliente.Where(e => e.Id_Queja == id_queja).ToList();
            viewmodel.QuejaViewModel.Respuestas.AddRange(respuesta_Clientes);
            viewmodel.QuejaViewModel.Respuestas.AddRange(respuesta_Empleados);
            viewmodel.QuejaViewModel.Respuestas.Sort(ModelsHelpers.CompareRespuestas);
            Respuesta_Cliente respuesta_Cliente = viewmodel.Respuesta_Cliente;
            

            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);

            return View(viewmodel);
        }

        private int? CheckNull(int? destino, int? origen)
        {
            return destino == null ? origen : destino;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromQueja(RespuestaClienteQuejaViewModel viewModel)
        {
            
            Respuesta_Cliente respuesta_Cliente = viewModel.Respuesta_Cliente;
            Queja queja = db.Queja.Find(viewModel.QuejaViewModel.Queja.ID_Queja);

            if (ModelState.IsValid)
            {
                respuesta_Cliente.Id_Queja = queja.ID_Queja;
                respuesta_Cliente.Fecha = DateTime.Today;
                respuesta_Cliente.Hora = DateTime.Now.TimeOfDay;


                
                queja.ID_Estado_QR = respuesta_Cliente.ID_Estado_Destino;

                db.Respuesta_Cliente.Add(respuesta_Cliente);
                db.Entry(queja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Cliente.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Cliente.Id_Reclamacion);
            return View(viewModel);
        }


        // GET: Respuesta_Empleado/Create
        public ActionResult CreateFromReclamacion(int? id)
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
            RespuestaClienteReclamacionViewModel viewmodel = new RespuestaClienteReclamacionViewModel()
            {
                ReclamacionViewModel = new ReclamacionViewModel { Reclamacion = reclamacion, Respuestas = new List<IRespuesta>() },
                Respuesta_Cliente = new Respuesta_Cliente
                {
                    Id_Reclamacion = reclamacion.ID_Reclamacion,
                    ID_Estado_Origen = reclamacion.ID_Estado_QR
                }
            };
            int id_reclamacion = reclamacion.ID_Reclamacion;
            List<Respuesta_Empleado> respuesta_Empleados = db.Respuesta_Empleado.Where(e => e.Id_Reclamacion == id_reclamacion).ToList();
            List<Respuesta_Cliente> respuesta_Clientes = db.Respuesta_Cliente.Where(e => e.Id_Reclamacion == id_reclamacion).ToList();
            viewmodel.ReclamacionViewModel.Respuestas.AddRange(respuesta_Clientes);
            viewmodel.ReclamacionViewModel.Respuestas.AddRange(respuesta_Empleados);
            viewmodel.ReclamacionViewModel.Respuestas.Sort(ModelsHelpers.CompareRespuestas);
            Respuesta_Cliente respuesta_Cliente = viewmodel.Respuesta_Cliente;


            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);

            return View(viewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromReclamacion(RespuestaClienteReclamacionViewModel viewModel)
        {

            Respuesta_Cliente respuesta_Cliente = viewModel.Respuesta_Cliente;
            Reclamacion reclamacion = db.Reclamacion.Find(viewModel.ReclamacionViewModel.Reclamacion.ID_Reclamacion);

            if (ModelState.IsValid)
            {
                respuesta_Cliente.Id_Reclamacion = reclamacion.ID_Reclamacion;
                respuesta_Cliente.Fecha = DateTime.Today;
                respuesta_Cliente.Hora = DateTime.Now.TimeOfDay;



                reclamacion.ID_Estado_QR = respuesta_Cliente.ID_Estado_Destino;

                db.Respuesta_Cliente.Add(respuesta_Cliente);
                db.Entry(reclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Cliente.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Cliente.Id_Reclamacion);
            return View(viewModel);
        }






        // GET: Respuesta_Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Cliente respuesta_Cliente = db.Respuesta_Cliente.Find(id);
            if (respuesta_Cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Cliente.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Cliente.Id_Reclamacion);
            return View(respuesta_Cliente);
        }

        // POST: Respuesta_Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Respuesta_Cliente,Id_Queja,Id_Reclamacion,ID_Estado_Origen,ID_Estado_Destino,Valoracion,Fecha,Detalle,Hora")] Respuesta_Cliente respuesta_Cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta_Cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Cliente.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Cliente.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Cliente.Id_Reclamacion);
            return View(respuesta_Cliente);
        }

        // GET: Respuesta_Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Cliente respuesta_Cliente = db.Respuesta_Cliente.Find(id);
            if (respuesta_Cliente == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Cliente);
        }

        // POST: Respuesta_Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta_Cliente respuesta_Cliente = db.Respuesta_Cliente.Find(id);
            db.Respuesta_Cliente.Remove(respuesta_Cliente);
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
