using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR_Project_5.Models
{
    public class EmpleadoViewModel
    {
        public Empleado Empleado { get; set; }
        public Direccion Direccion { get; set; }
    }

    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public Direccion Direccion { get; set; }
    }

    public class QuejaViewModel
    {
        public Queja Queja { get; set; }
        public List<IRespuesta> Respuestas { get; set; }
        //TODO: Lista de tipo respuesta interfaz con las respuestas de empleados y clientes
    }
    
    public class RespuestaEmpleadoQuejaViewModel
    {
        public QuejaViewModel QuejaViewModel { get; set; }
        public Respuesta_Empleado Respuesta_Empleado { get; set; }
    }
    public class RespuestaClienteQuejaViewModel
    {
        public QuejaViewModel QuejaViewModel { get; set; }
        public Respuesta_Cliente Respuesta_Cliente { get; set; }
    }
    public class ReclamacionViewModel
    {
        public Reclamacion Reclamacion { get; set; }
        public List<IRespuesta> Respuestas { get; set; }
        //TODO: Lista de tipo respuesta interfaz con las respuestas de empleados y clientes
    }

    public class RespuestaEmpleadoReclamacionViewModel
    {
        public ReclamacionViewModel ReclamacionViewModel { get; set; }
        public Respuesta_Empleado Respuesta_Empleado { get; set; }
    }
    public class RespuestaClienteReclamacionViewModel
    {
        public ReclamacionViewModel ReclamacionViewModel { get; set; }
        public Respuesta_Cliente Respuesta_Cliente { get; set; }
    }
}