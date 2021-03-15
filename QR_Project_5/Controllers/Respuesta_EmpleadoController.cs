using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QR_Project_5.Models;
using Microsoft.AspNet.Identity;

namespace QR_Project_5.Controllers
{
    [Authorize]
    public class Respuesta_EmpleadoController : Controller
    {
        private DB_QR_PEntities db = new DB_QR_PEntities();

        // GET: Respuesta_Empleado
        public ActionResult Index()
        {
            var respuesta_Empleado = db.Respuesta_Empleado.Include(r => r.Departamento).Include(r => r.Departamento1).Include(r => r.Empleado).Include(r => r.Empleado1).Include(r => r.Estado_QR).Include(r => r.Estado_QR1).Include(r => r.Queja).Include(r => r.Reclamacion).Include(r => r.Sucursal).Include(r => r.Sucursal1);
            return View(respuesta_Empleado.ToList());
        }

        // GET: Respuesta_Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Empleado respuesta_Empleado = db.Respuesta_Empleado.Find(id);
            if (respuesta_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Empleado);
        }

        // GET: Respuesta_Empleado/Create
        public ActionResult Create()
        {
            ViewBag.ID_Departamento_Origen = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre");
            ViewBag.ID_Empleado_Origen = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja");
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion");
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            ViewBag.ID_Sucursal_Origen = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            return View();
        }

        // POST: Respuesta_Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Respuesta_QR,Id_Queja,Id_Reclamacion,ID_Empleado_Origen,ID_Empleado_Destino,ID_Departamento_Origen,ID_Departamento_Destino,ID_Estado_Origen,ID_Estado_Destino,Fecha,Detalle,Hora,ID_Sucursal_Origen,ID_Sucursal_Destino")] Respuesta_Empleado respuesta_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Respuesta_Empleado.Add(respuesta_Empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Departamento_Origen = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Origen);
            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Destino);
            ViewBag.ID_Empleado_Origen = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Origen);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Destino);
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Empleado.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Empleado.Id_Reclamacion);
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Destino);
            ViewBag.ID_Sucursal_Origen = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Origen);
            return View(respuesta_Empleado);
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
            RespuestaEmpleadoQuejaViewModel viewmodel = new RespuestaEmpleadoQuejaViewModel()
            {
                QuejaViewModel = new QuejaViewModel { 
                    Queja = queja,
                    Respuestas = new List<IRespuesta>()
                },
                Respuesta_Empleado = new Respuesta_Empleado
                {
                    Id_Queja = queja.ID_Queja,
                    ID_Departamento_Origen = queja.ID_Departamento,
                    ID_Empleado_Origen = queja.Id_Empleado,
                    ID_Sucursal_Origen = queja.ID_Sucursal,
                    ID_Estado_Origen = queja.ID_Estado_QR
                }
            };
            int id_queja = queja.ID_Queja;
            List<Respuesta_Empleado> respuesta_Empleados = db.Respuesta_Empleado.Where(e => e.Id_Queja == id_queja).ToList();
            List<Respuesta_Cliente> respuesta_Clientes = db.Respuesta_Cliente.Where(e => e.Id_Queja == id_queja).ToList();
            viewmodel.QuejaViewModel.Respuestas.AddRange(respuesta_Clientes);
            viewmodel.QuejaViewModel.Respuestas.AddRange(respuesta_Empleados);
            viewmodel.QuejaViewModel.Respuestas.Sort(ModelsHelpers.CompareRespuestas);
            Respuesta_Empleado respuesta_Empleado = viewmodel.Respuesta_Empleado;
            List<Estado_QR> disabled = new List<Estado_QR>();
            disabled.Add(db.Estado_QR.Find(Estado_QR.GetIdByDescripcion(Estado_QR.REABIERTO_DISCONFORMIDAD)));
            disabled.Add(db.Estado_QR.Find(Estado_QR.GetIdByDescripcion(Estado_QR.ABIERTO)));

            SelectList listItems = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Origen);
            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Origen);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Origen);
            ViewBag.ID_Estado_Destino = listItems;
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Origen);

            //ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre",);
            //ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
            //ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            //ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            return View(viewmodel);
        }

        private int? CheckNull(int? destino, int? origen)
        {
            return destino == null ? origen : destino;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromQueja(RespuestaEmpleadoQuejaViewModel viewModel)
        {
            string id = User.Identity.GetUserId();
            Empleado empleado = db.Empleado.Where(e => e.Id_UserName == id).FirstOrDefault<Empleado>();
            Respuesta_Empleado respuesta_Empleado = viewModel.Respuesta_Empleado;
            Queja queja = db.Queja.Find(viewModel.QuejaViewModel.Queja.ID_Queja);
            
            if (ModelState.IsValid)
            {
                respuesta_Empleado.Id_Queja = queja.ID_Queja;
                respuesta_Empleado.Fecha = DateTime.Today;
                respuesta_Empleado.Hora = DateTime.Now.TimeOfDay;
                if (respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.PENDIENTE_VALORACION))
                {
                    respuesta_Empleado.ID_Empleado_Destino = empleado.ID_Empleado;
                    respuesta_Empleado.ID_Departamento_Destino = empleado.ID_Departamento;
                    respuesta_Empleado.ID_Sucursal_Destino = empleado.Id_Sucursal;
                }
                else if(respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.REDIRIGIDO_DEPARTAMENTO))
                {
                    respuesta_Empleado.ID_Sucursal_Destino = empleado.Id_Sucursal;
                    respuesta_Empleado.ID_Empleado_Destino = null;
                }
                else if(respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.REDIRIGIDO_SUCURSAL))
                {
                    respuesta_Empleado.ID_Departamento_Destino = CheckNull(respuesta_Empleado.ID_Departamento_Destino, respuesta_Empleado.ID_Departamento_Destino);
                    respuesta_Empleado.ID_Empleado_Destino = null;
                }
                else if(respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.REDIRIGIDO_EMPLEADO))
                {
                    Empleado empleado_Destino = db.Empleado.Find(respuesta_Empleado.ID_Empleado_Destino);
                    respuesta_Empleado.ID_Departamento_Destino = empleado_Destino.ID_Departamento;
                    respuesta_Empleado.ID_Sucursal_Destino = empleado_Destino.Id_Sucursal;
                }
                else if(respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.CERRADO))
                {
                    respuesta_Empleado.ID_Empleado_Destino = empleado.ID_Empleado;
                    respuesta_Empleado.ID_Departamento_Destino = empleado.ID_Departamento;
                    respuesta_Empleado.ID_Sucursal_Destino = empleado.Id_Sucursal;
                }

                
                //respuesta_Empleado.ID_Empleado_Destino = CheckNull(respuesta_Empleado.ID_Empleado_Destino, respuesta_Empleado.ID_Empleado_Origen);
                //respuesta_Empleado.ID_Departamento_Destino = CheckNull(respuesta_Empleado.ID_Departamento_Destino, respuesta_Empleado.ID_Departamento_Destino);
                //respuesta_Empleado.ID_Sucursal_Destino = CheckNull(respuesta_Empleado.ID_Sucursal_Destino, respuesta_Empleado.ID_Sucursal_Origen);
                respuesta_Empleado.ID_Empleado_Origen = empleado.ID_Empleado;
                queja.ID_Estado_QR = respuesta_Empleado.ID_Estado_Destino;
                queja.ID_Sucursal = respuesta_Empleado.ID_Sucursal_Destino;
                queja.ID_Departamento = respuesta_Empleado.ID_Departamento_Destino;
                queja.Id_Empleado = respuesta_Empleado.ID_Empleado_Destino;
                db.Respuesta_Empleado.Add(respuesta_Empleado);
                db.Entry(queja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Destino);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Destino);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Destino);
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Destino);
            return View(viewModel);
        }



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
            RespuestaEmpleadoReclamacionViewModel viewmodel = new RespuestaEmpleadoReclamacionViewModel()
            {
                ReclamacionViewModel = new ReclamacionViewModel
                {
                    Reclamacion = reclamacion,
                    Respuestas = new List<IRespuesta>()
                },
                Respuesta_Empleado = new Respuesta_Empleado
                {
                    Id_Reclamacion = reclamacion.ID_Reclamacion,
                    ID_Departamento_Origen = reclamacion.ID_Departamento,
                    ID_Empleado_Origen = reclamacion.Id_Empleado,
                    ID_Sucursal_Origen = reclamacion.ID_Sucursal,
                    ID_Estado_Origen = reclamacion.ID_Estado_QR
                }
            };
            int id_reclamacion = reclamacion.ID_Reclamacion;
            List<Respuesta_Empleado> respuesta_Empleados = db.Respuesta_Empleado.Where(e => e.Id_Reclamacion == id_reclamacion).ToList();
            List<Respuesta_Cliente> respuesta_Clientes = db.Respuesta_Cliente.Where(e => e.Id_Reclamacion == id_reclamacion).ToList();
            viewmodel.ReclamacionViewModel.Respuestas.AddRange(respuesta_Clientes);
            viewmodel.ReclamacionViewModel.Respuestas.AddRange(respuesta_Empleados);
            viewmodel.ReclamacionViewModel.Respuestas.Sort(ModelsHelpers.CompareRespuestas);
            Respuesta_Empleado respuesta_Empleado = viewmodel.Respuesta_Empleado;
            List<Estado_QR> disabled = new List<Estado_QR>();
            disabled.Add(db.Estado_QR.Find(Estado_QR.GetIdByDescripcion(Estado_QR.REABIERTO_DISCONFORMIDAD)));
            disabled.Add(db.Estado_QR.Find(Estado_QR.GetIdByDescripcion(Estado_QR.ABIERTO)));

            SelectList listItems = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Origen);
            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Origen);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Origen);
            ViewBag.ID_Estado_Destino = listItems;
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Origen);

            //ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre",);
            //ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion");
            //ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion");
            //ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre");
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFromReclamacion(RespuestaEmpleadoReclamacionViewModel viewModel)
        {
            string id = User.Identity.GetUserId();
            Empleado empleado = db.Empleado.Where(e => e.Id_UserName == id).FirstOrDefault<Empleado>();
            Respuesta_Empleado respuesta_Empleado = viewModel.Respuesta_Empleado;
            Reclamacion reclamacion = db.Reclamacion.Find(viewModel.ReclamacionViewModel.Reclamacion.ID_Reclamacion);

            if (ModelState.IsValid)
            {
                respuesta_Empleado.Id_Reclamacion = reclamacion.ID_Reclamacion;
                respuesta_Empleado.Fecha = DateTime.Today;
                respuesta_Empleado.Hora = DateTime.Now.TimeOfDay;
                if (respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.PENDIENTE_VALORACION))
                {
                    respuesta_Empleado.ID_Empleado_Destino = empleado.ID_Empleado;
                    respuesta_Empleado.ID_Departamento_Destino = empleado.ID_Departamento;
                    respuesta_Empleado.ID_Sucursal_Destino = empleado.Id_Sucursal;
                }
                else if (respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.REDIRIGIDO_DEPARTAMENTO))
                {
                    respuesta_Empleado.ID_Sucursal_Destino = empleado.Id_Sucursal;
                    respuesta_Empleado.ID_Empleado_Destino = null;
                }
                else if (respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.REDIRIGIDO_SUCURSAL))
                {
                    respuesta_Empleado.ID_Departamento_Destino = CheckNull(respuesta_Empleado.ID_Departamento_Destino, respuesta_Empleado.ID_Departamento_Destino);
                    respuesta_Empleado.ID_Empleado_Destino = null;
                }
                else if (respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.REDIRIGIDO_EMPLEADO))
                {
                    Empleado empleado_Destino = db.Empleado.Find(respuesta_Empleado.ID_Empleado_Destino);
                    respuesta_Empleado.ID_Departamento_Destino = empleado_Destino.ID_Departamento;
                    respuesta_Empleado.ID_Sucursal_Destino = empleado_Destino.Id_Sucursal;
                }
                else if (respuesta_Empleado.ID_Estado_Destino == Estado_QR.GetIdByDescripcion(Estado_QR.CERRADO))
                {
                    respuesta_Empleado.ID_Empleado_Destino = empleado.ID_Empleado;
                    respuesta_Empleado.ID_Departamento_Destino = empleado.ID_Departamento;
                    respuesta_Empleado.ID_Sucursal_Destino = empleado.Id_Sucursal;
                }


                respuesta_Empleado.ID_Empleado_Origen = empleado.ID_Empleado;
                reclamacion.ID_Estado_QR = respuesta_Empleado.ID_Estado_Destino;
                reclamacion.ID_Sucursal = respuesta_Empleado.ID_Sucursal_Destino;
                reclamacion.ID_Departamento = respuesta_Empleado.ID_Departamento_Destino;
                reclamacion.Id_Empleado = respuesta_Empleado.ID_Empleado_Destino;
                db.Respuesta_Empleado.Add(respuesta_Empleado);
                db.Entry(reclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Destino);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Destino);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Destino);
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Destino);
            return View(viewModel);
        }



        // GET: Respuesta_Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Empleado respuesta_Empleado = db.Respuesta_Empleado.Find(id);
            if (respuesta_Empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Departamento_Origen = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Origen);
            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Destino);
            ViewBag.ID_Empleado_Origen = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Origen);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Destino);
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Empleado.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Empleado.Id_Reclamacion);
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Destino);
            ViewBag.ID_Sucursal_Origen = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Origen);
            return View(respuesta_Empleado);
        }

        // POST: Respuesta_Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Respuesta_QR,Id_Queja,Id_Reclamacion,ID_Empleado_Origen,ID_Empleado_Destino,ID_Departamento_Origen,ID_Departamento_Destino,ID_Estado_Origen,ID_Estado_Destino,Fecha,Detalle,Hora,ID_Sucursal_Origen,ID_Sucursal_Destino")] Respuesta_Empleado respuesta_Empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta_Empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Departamento_Origen = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Origen);
            ViewBag.ID_Departamento_Destino = new SelectList(db.Departamento, "ID_Departamento", "Nombre", respuesta_Empleado.ID_Departamento_Destino);
            ViewBag.ID_Empleado_Origen = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Origen);
            ViewBag.ID_Empleado_Destino = new SelectList(db.Empleado, "ID_Empleado", "Identificacion", respuesta_Empleado.ID_Empleado_Destino);
            ViewBag.ID_Estado_Origen = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Origen);
            ViewBag.ID_Estado_Destino = new SelectList(db.Estado_QR, "ID_Estado_QR", "Descripcion", respuesta_Empleado.ID_Estado_Destino);
            ViewBag.Id_Queja = new SelectList(db.Queja, "ID_Queja", "ID_Queja", respuesta_Empleado.Id_Queja);
            ViewBag.Id_Reclamacion = new SelectList(db.Reclamacion, "ID_Reclamacion", "ID_Reclamacion", respuesta_Empleado.Id_Reclamacion);
            ViewBag.ID_Sucursal_Destino = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Destino);
            ViewBag.ID_Sucursal_Origen = new SelectList(db.Sucursal, "ID_Sucursal", "Nombre", respuesta_Empleado.ID_Sucursal_Origen);
            return View(respuesta_Empleado);
        }

        // GET: Respuesta_Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta_Empleado respuesta_Empleado = db.Respuesta_Empleado.Find(id);
            if (respuesta_Empleado == null)
            {
                return HttpNotFound();
            }
            return View(respuesta_Empleado);
        }

        // POST: Respuesta_Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta_Empleado respuesta_Empleado = db.Respuesta_Empleado.Find(id);
            db.Respuesta_Empleado.Remove(respuesta_Empleado);
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
