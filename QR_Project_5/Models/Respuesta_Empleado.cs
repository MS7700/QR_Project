//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QR_Project_5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Respuesta_Empleado
    {
        public int ID_Respuesta_QR { get; set; }
        public Nullable<int> Id_Queja { get; set; }
        public Nullable<int> Id_Reclamacion { get; set; }
        public Nullable<int> ID_Empleado_Origen { get; set; }
        public Nullable<int> ID_Empleado_Destino { get; set; }
        public Nullable<int> ID_Departamento_Origen { get; set; }
        public Nullable<int> ID_Departamento_Destino { get; set; }
        public Nullable<int> ID_Estado_Origen { get; set; }
        public Nullable<int> ID_Estado_Destino { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Detalle { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public Nullable<int> ID_Sucursal_Origen { get; set; }
        public Nullable<int> ID_Sucursal_Destino { get; set; }
    
        public virtual Departamento Departamento { get; set; }
        public virtual Departamento Departamento1 { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Empleado Empleado1 { get; set; }
        public virtual Estado_QR Estado_QR { get; set; }
        public virtual Estado_QR Estado_QR1 { get; set; }
        public virtual Queja Queja { get; set; }
        public virtual Reclamacion Reclamacion { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Sucursal Sucursal1 { get; set; }
    }
}
