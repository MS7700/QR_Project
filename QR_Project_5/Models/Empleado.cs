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
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Departamento = new HashSet<Departamento>();
            this.Queja = new HashSet<Queja>();
            this.Reclamacion = new HashSet<Reclamacion>();
            this.Respuesta_Empleado = new HashSet<Respuesta_Empleado>();
            this.Respuesta_Empleado1 = new HashSet<Respuesta_Empleado>();
            this.Sucursal1 = new HashSet<Sucursal>();
            this.Transaccion = new HashSet<Transaccion>();
        }
    
        public int ID_Empleado { get; set; }
        public Nullable<int> Id_Tipo_Identificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> Id_Estado_Cliente { get; set; }
        public Nullable<int> Id_Direccion { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public string Telefono { get; set; }
        public string Id_UserName { get; set; }
        public Nullable<int> Id_Sucursal { get; set; }
        public Nullable<int> ID_Departamento { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departamento> Departamento { get; set; }
        public virtual Departamento Departamento1 { get; set; }
        public virtual Direccion Direccion { get; set; }
        public virtual Estado_Cliente Estado_Cliente { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Tipo_Identificacion Tipo_Identificacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Queja> Queja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclamacion> Reclamacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Respuesta_Empleado> Respuesta_Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Respuesta_Empleado> Respuesta_Empleado1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sucursal> Sucursal1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaccion> Transaccion { get; set; }
    }
}
